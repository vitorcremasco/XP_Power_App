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
using System.Text.RegularExpressions;
using System.Globalization;

namespace XP_Power_Control
{
    public partial class MainForm : Form
    {
        private Thread dataPollingThread;
        private bool isPolling;
        private static Mutex serialPortMutex = new Mutex();
        string g_LogFileName = null;
        string lastVolt, lastCurrent;
        string msgLog = "";
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

                serialPortConnectBtn.Text = "DISCONNECT";

                SetRemote();


                isPolling = false;
                dataPollingThread = new Thread(poolingMessages);
                dataPollingThread.IsBackground = true;
                StartDataPolling();

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
                StopDataPolling();
                serialPort1.Close();
                serialPortConnectBtn.Text = "CONNECT";
                StatusPicture.BackColor = Color.Transparent;
                g_LogFileName = null;

            }
        }       

        private void SetVoltageTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SetVoltage(SetVoltageTB.Text);
                e.Handled = true;
            }
        }

        private void SetCurrentTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.SetCurrent(SetCurrentTB.Text);
                e.Handled = true;
            }
        }

        private void TurnOnOffBtn_Click(object sender, EventArgs e)
        {
            if (StatusPicture.BackColor == Color.Red)
            {
                this.writePsu("POWER 1");

            }
            else if (StatusPicture.BackColor == Color.Green)
            {
                this.writePsu("POWER 0");

            }
        }

        private void ReadOutVoltage()
        {
            this.writePsu("RV?");
        }
        private void ReadOutCurrent()
        {
            this.writePsu("RI?");
        }
        private string ReadOutSetVoltage()
        {
            try
            {
                string outPut = "";
                serialPortMutex.WaitOne();
                serialPort1.DiscardInBuffer();
                serialPort1.WriteLine("SV?");
                Thread.Sleep(100);
                outPut = serialPort1.ReadLine();
                serialPortMutex.ReleaseMutex();
                return outPut;

            }
            catch { return "error"; }
        }
        private string ReadOutSetCurrent()
        {
            try
            {
                string outPut = "";
                serialPortMutex.WaitOne();
                serialPort1.DiscardInBuffer();
                serialPort1.WriteLine("SI?");
                Thread.Sleep(100);
                outPut = serialPort1.ReadLine();
                serialPortMutex.ReleaseMutex();
                return outPut;
            }
            catch { return "error"; }
        }

        private void ReadStatus()
        {
            this.writePsu("POWER 2");
        }

        private void SetRemote()
        {
            this.writePsu("REMS 1");
        }

        private void SetVoltage(string value)
        {
            try
            {
                string SetV = "SV " + value;
                this.writePsu(SetV);
            }
            catch { }
        }

        private void SetCurrent(string value)
        {
            try
            {
                string SetCurr = "SI " + value;
                this.writePsu(SetCurr);
            }
            catch { }
        }

        private void writePsu (string msg)
        {
            try
            {
                serialPortMutex.WaitOne();
                serialPort1.DiscardInBuffer();
                serialPort1.WriteLine(msg);
                Thread.Sleep(100);
                serialPortMutex.ReleaseMutex();
                
            }
            catch { }
        }
        
        
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                serialPortMutex.WaitOne();
                string receivedData = serialPort1.ReadLine();
                serialPortMutex.ReleaseMutex();
                if (receivedData.Contains("V\r"))
                {
                    this.lastVolt = receivedData.Replace("\r\n", "");
                    Invoke((MethodInvoker)delegate
                    {
                        OutVoltageRead.Text = this.lastVolt;
                    });
                    //Console.WriteLine("Voltage = " + receivedData);
                }
                else if (receivedData.Contains("A\r"))
                {
                    this.lastCurrent = receivedData.Replace("\r\n", "");
                    Invoke((MethodInvoker)delegate
                    {
                        OutCurrentRead.Text = this.lastCurrent;
                    });
                    //Console.WriteLine("Current = " + receivedData);
                }
                else if (receivedData.Contains("=>\r"))
                {
                }
                else if (receivedData.Contains("?>\r") || receivedData.Contains("!>\r"))
                {
                    Console.WriteLine("PSU command error");
                }
                else
                {
                    char status = receivedData[0];
                    if (status == '2')
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            StatusPicture.BackColor = Color.Red;
                        });
                    }
                    else if (status == '3')
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            StatusPicture.BackColor = Color.Green;
                        });
                    }
                    if (g_LogFileName != null)
                    {
                        msgLog += DateTime.Now.ToString("hh_mm_ss_fff;") +
                            this.lastVolt.Replace("V\r\n", "") + ";" + this.lastCurrent.Replace("A\r\n", "") + ";" + status.ToString() + Environment.NewLine;
                        if (msgLog.Length > 2000)
                        {
                            writeFile(msgLog);
                        }
                    }
                }
                
            }
            catch { }

        }


        private void writeFile(string msgLog)
        {
            try
            {
                if (File.Exists(g_LogFileName))
                {
                    File.AppendAllText(g_LogFileName, msgLog);
                }
                else//create header
                {
                    File.WriteAllText(g_LogFileName, "Date;OutVoltage;OutCurrent;status" + Environment.NewLine + msgLog);
                }
            }
            catch { }
        }
        private void poolingMessages()
        {
            while (this.isPolling) 
            {
                ReadOutVoltage();
                ReadOutCurrent();
                ReadStatus();
            }
        }

        private void StartDataPolling()
        {
            if (!isPolling)
            {
                isPolling = true;
                dataPollingThread.Start();
            }
        }

        private void StopDataPolling()
        {
            if (isPolling)
            {
                isPolling = false;
                dataPollingThread.Join(); // Wait for the thread to finish
            }
        }
    }
}
