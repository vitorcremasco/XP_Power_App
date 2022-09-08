using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.IO;

namespace XP_Power_Control
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void serialPortNameComboBox_DropDown(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            serialPortNameComboBox.Items.Clear();
            foreach (string p in ports)
            {
                serialPortNameComboBox.Items.Add(p);
            }
        }

        private void serialPortConnectBtn_Click(object sender, EventArgs e)
        {
            if (serialPortConnectBtn.Text == "CONNECT")
            {

                serialPort1.PortName = serialPortNameComboBox.Text;
                serialPort1.Open();
                serialPort1.BaudRate = Convert.ToInt32(BaudTB.Text);
                switch (ParityTB.Text)
                {
                    case ("NONE"):
                        serialPort1.Parity = System.IO.Ports.Parity.None;
                        break;
                    case ("ODD"):
                        serialPort1.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    case ("EVEN"):
                        serialPort1.Parity = System.IO.Ports.Parity.Even;
                        break;
                    default:
                        serialPort1.Parity = System.IO.Ports.Parity.None;
                        break;
                }
                switch (HandshakeTB.Text)
                {
                    case ("NONE"):
                        serialPort1.Handshake = System.IO.Ports.Handshake.None;
                        serialPort1.DtrEnable = true;
                        rtsCheckBox.Enabled = true;
                        dtrCheckBox.Enabled = true;
                        Thread.Sleep(200);
                        serialPort1.RtsEnable = rtsCheckBox.Checked;
                        Thread.Sleep(200);
                        serialPort1.DtrEnable = dtrCheckBox.Checked;
                        break;
                    case ("XONXOFF"):
                        rtsCheckBox.Enabled = false;
                        dtrCheckBox.Enabled = false;
                        serialPort1.Handshake = System.IO.Ports.Handshake.XOnXOff;
                        break;
                    case ("RTS"):
                        rtsCheckBox.Enabled = false;
                        dtrCheckBox.Enabled = false;
                        serialPort1.Handshake = System.IO.Ports.Handshake.RequestToSend;
                        break;
                    case ("RTS+XONXOFF"):
                        rtsCheckBox.Enabled = false;
                        dtrCheckBox.Enabled = false;
                        serialPort1.Handshake = System.IO.Ports.Handshake.RequestToSendXOnXOff;
                        break;
                    default:
                        serialPort1.DtrEnable = true;
                        rtsCheckBox.Enabled = true;
                        dtrCheckBox.Enabled = true;
                        Thread.Sleep(200);
                        serialPort1.RtsEnable = rtsCheckBox.Checked;
                        Thread.Sleep(200);
                        serialPort1.DtrEnable = dtrCheckBox.Checked;
                        serialPort1.Handshake = System.IO.Ports.Handshake.None;

                        break;
                }
                serialPortPooling.Enabled = true;
                serialPortConnectBtn.Text = "DISCONNECT";

                SetRemote();

                serialPort1.ReadExisting();//to empty the RX Buffer
                String SetVolt= ReadOutSetVoltage().Replace("=>", "");
                String SetCurr= ReadOutSetCurrent().Replace("=>", "");
                SetVoltageTB.Text = SetVolt.Replace("V","").Replace("\r\n","");
                SetCurrentTB.Text = SetCurr.Replace("A", "").Replace("\r\n", "");
                if (logEnableCheckBox.Checked)
                {
                    string directoryName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "XP_Power_App", "_Logs");
                    System.IO.Directory.CreateDirectory(directoryName);
                    g_LogFileName = directoryName + "\\" + DateTime.Now.Date.ToString("yyyy_MM_dd_") + DateTime.Now.ToString("h_mm_ss_tt") + "_LOG.csv";
                }
            }
            else
            {
                serialPort1.Close();
                serialPortPooling.Enabled = false;
                serialPortConnectBtn.Text = "CONNECT";
                StatusPicture.BackColor = Color.Transparent;
                g_LogFileName = null;
            }
        }

        string g_LogFileName = null;

        private void serialPortPooling_Tick(object sender, EventArgs e)
        {
            if (ReadStatus().Contains("3"))
            {
                StatusPicture.BackColor = Color.Green;
            }
            else if (ReadStatus().Contains("2"))
            {
                StatusPicture.BackColor = Color.Red;
            }
            OutVoltageRead.Text = ReadOutVoltage().Replace("\r\n=>\r\n", "");
            OutCurrentRead.Text = ReadOutCurrent().Replace("\r\n=>\r\n", "");
            if (g_LogFileName!=null)
            {
                string msgLog = DateTime.Now.Date.ToString("yyyy_MM_dd_") + DateTime.Now.ToString("h_mm_ss_tt;")+
                    OutVoltageRead.Text.Replace("V", "") + ";"+ OutCurrentRead.Text.Replace("A", "") + Environment.NewLine;
                if (File.Exists(g_LogFileName))
                {
                    File.AppendAllText(g_LogFileName, msgLog);
                }
                else//create header
                {
                    File.WriteAllText(g_LogFileName, "Date;OutVoltage;OutCurrent" + Environment.NewLine + msgLog);
                }
            }
        }

        private void SetRemote()
        {
            serialPort1.WriteLine("REMS 1");
            Thread.Sleep(100);
            serialPort1.ReadExisting();
        }

        private String ReadOutVoltage()
        {
            serialPort1.WriteLine("RV?");
            Thread.Sleep(100);
            return serialPort1.ReadExisting();
        }
        private String ReadOutCurrent()
        {
            serialPort1.WriteLine("RI?");
            Thread.Sleep(100);
            return serialPort1.ReadExisting();
        }
        private String ReadOutSetVoltage()
        {
            serialPort1.WriteLine("SV?");
            Thread.Sleep(100);
            return serialPort1.ReadExisting();
        }
        private String ReadOutSetCurrent()
        {
            serialPort1.WriteLine("SI?");
            Thread.Sleep(100);
            return serialPort1.ReadExisting();
        }

        private String ReadStatus()
        {
            serialPort1.WriteLine("POWER 2");
            Thread.Sleep(100);
            String sts= serialPort1.ReadExisting();
            return sts;
        }

        private void SetVoltageTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string SetV = "SV "+ SetVoltageTB.Text;
                serialPort1.WriteLine(SetV);
                Thread.Sleep(100);
                serialPort1.ReadExisting();
                e.Handled = true;
            }
        }

        private void SetCurrentTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string SetCurr = "SI " + SetCurrentTB.Text;
                serialPort1.WriteLine(SetCurr);
                Thread.Sleep(100);
                serialPort1.ReadExisting();
                e.Handled = true;
            }
        }

        private void TurnOnOffBtn_Click(object sender, EventArgs e)
        {
            if (StatusPicture.BackColor == Color.Red)
            {
                serialPort1.WriteLine("POWER 1");
                Thread.Sleep(100);
                serialPort1.ReadExisting();
            }
            else if (StatusPicture.BackColor == Color.Green)
            {
                serialPort1.WriteLine("POWER 0");
                Thread.Sleep(100);
                serialPort1.ReadExisting();
            }
        }
    }
}
