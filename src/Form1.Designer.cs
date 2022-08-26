
namespace XP_Power_Control
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPortPooling = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPortNameComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HandshakeTB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ParityTB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BaudTB = new System.Windows.Forms.TextBox();
            this.rtsCheckBox = new System.Windows.Forms.CheckBox();
            this.dtrCheckBox = new System.Windows.Forms.CheckBox();
            this.serialPortConnectBtn = new System.Windows.Forms.Button();
            this.SetVoltageTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SetCurrentTB = new System.Windows.Forms.TextBox();
            this.TurnOnOffBtn = new System.Windows.Forms.Button();
            this.OutVoltageRead = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OutCurrentRead = new System.Windows.Forms.Label();
            this.StatusPicture = new System.Windows.Forms.PictureBox();
            this.logEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPortPooling
            // 
            this.serialPortPooling.Tick += new System.EventHandler(this.serialPortPooling_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.ReadTimeout = 1000;
            this.serialPort1.WriteTimeout = 1000;
            // 
            // serialPortNameComboBox
            // 
            this.serialPortNameComboBox.FormattingEnabled = true;
            this.serialPortNameComboBox.Location = new System.Drawing.Point(11, 11);
            this.serialPortNameComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.serialPortNameComboBox.Name = "serialPortNameComboBox";
            this.serialPortNameComboBox.Size = new System.Drawing.Size(100, 21);
            this.serialPortNameComboBox.TabIndex = 36;
            this.serialPortNameComboBox.DropDown += new System.EventHandler(this.serialPortNameComboBox_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Handshake";
            // 
            // HandshakeTB
            // 
            this.HandshakeTB.FormattingEnabled = true;
            this.HandshakeTB.Items.AddRange(new object[] {
            "NONE",
            "XONXOFF",
            "RTS",
            "RTS+XONXOFF"});
            this.HandshakeTB.Location = new System.Drawing.Point(326, 11);
            this.HandshakeTB.Margin = new System.Windows.Forms.Padding(2);
            this.HandshakeTB.Name = "HandshakeTB";
            this.HandshakeTB.Size = new System.Drawing.Size(96, 21);
            this.HandshakeTB.TabIndex = 50;
            this.HandshakeTB.Text = "NONE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Parity";
            // 
            // ParityTB
            // 
            this.ParityTB.FormattingEnabled = true;
            this.ParityTB.Items.AddRange(new object[] {
            "NONE",
            "ODD",
            "EVEN"});
            this.ParityTB.Location = new System.Drawing.Point(260, 11);
            this.ParityTB.Margin = new System.Windows.Forms.Padding(2);
            this.ParityTB.Name = "ParityTB";
            this.ParityTB.Size = new System.Drawing.Size(62, 21);
            this.ParityTB.TabIndex = 48;
            this.ParityTB.Text = "NONE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Baud";
            // 
            // BaudTB
            // 
            this.BaudTB.Location = new System.Drawing.Point(214, 11);
            this.BaudTB.Margin = new System.Windows.Forms.Padding(2);
            this.BaudTB.Name = "BaudTB";
            this.BaudTB.Size = new System.Drawing.Size(42, 20);
            this.BaudTB.TabIndex = 46;
            this.BaudTB.Text = "4800";
            // 
            // rtsCheckBox
            // 
            this.rtsCheckBox.AutoSize = true;
            this.rtsCheckBox.Location = new System.Drawing.Point(123, 35);
            this.rtsCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.rtsCheckBox.Name = "rtsCheckBox";
            this.rtsCheckBox.Size = new System.Drawing.Size(85, 17);
            this.rtsCheckBox.TabIndex = 45;
            this.rtsCheckBox.Text = "RTS (ISP-N)";
            this.rtsCheckBox.UseVisualStyleBackColor = true;
            // 
            // dtrCheckBox
            // 
            this.dtrCheckBox.AutoSize = true;
            this.dtrCheckBox.Location = new System.Drawing.Point(123, 13);
            this.dtrCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.dtrCheckBox.Name = "dtrCheckBox";
            this.dtrCheckBox.Size = new System.Drawing.Size(91, 17);
            this.dtrCheckBox.TabIndex = 44;
            this.dtrCheckBox.Text = "DTR (RST-N)";
            this.dtrCheckBox.UseVisualStyleBackColor = true;
            // 
            // serialPortConnectBtn
            // 
            this.serialPortConnectBtn.Location = new System.Drawing.Point(11, 32);
            this.serialPortConnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.serialPortConnectBtn.Name = "serialPortConnectBtn";
            this.serialPortConnectBtn.Size = new System.Drawing.Size(100, 20);
            this.serialPortConnectBtn.TabIndex = 52;
            this.serialPortConnectBtn.Text = "CONNECT";
            this.serialPortConnectBtn.UseVisualStyleBackColor = true;
            this.serialPortConnectBtn.Click += new System.EventHandler(this.serialPortConnectBtn_Click);
            // 
            // SetVoltageTB
            // 
            this.SetVoltageTB.Location = new System.Drawing.Point(11, 96);
            this.SetVoltageTB.Name = "SetVoltageTB";
            this.SetVoltageTB.Size = new System.Drawing.Size(100, 20);
            this.SetVoltageTB.TabIndex = 53;
            this.SetVoltageTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetVoltageTB_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Set Voltage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Set Current";
            // 
            // SetCurrentTB
            // 
            this.SetCurrentTB.Location = new System.Drawing.Point(11, 122);
            this.SetCurrentTB.Name = "SetCurrentTB";
            this.SetCurrentTB.Size = new System.Drawing.Size(100, 20);
            this.SetCurrentTB.TabIndex = 55;
            this.SetCurrentTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetCurrentTB_KeyPress);
            // 
            // TurnOnOffBtn
            // 
            this.TurnOnOffBtn.Location = new System.Drawing.Point(187, 99);
            this.TurnOnOffBtn.Name = "TurnOnOffBtn";
            this.TurnOnOffBtn.Size = new System.Drawing.Size(160, 39);
            this.TurnOnOffBtn.TabIndex = 57;
            this.TurnOnOffBtn.Text = "Turn ON / OFF";
            this.TurnOnOffBtn.UseVisualStyleBackColor = true;
            this.TurnOnOffBtn.Click += new System.EventHandler(this.TurnOnOffBtn_Click);
            // 
            // OutVoltageRead
            // 
            this.OutVoltageRead.AutoSize = true;
            this.OutVoltageRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutVoltageRead.Location = new System.Drawing.Point(6, 29);
            this.OutVoltageRead.Name = "OutVoltageRead";
            this.OutVoltageRead.Size = new System.Drawing.Size(95, 73);
            this.OutVoltageRead.TabIndex = 58;
            this.OutVoltageRead.Text = "---";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OutVoltageRead);
            this.groupBox1.Location = new System.Drawing.Point(451, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 118);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Voltage";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OutCurrentRead);
            this.groupBox2.Location = new System.Drawing.Point(805, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 118);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output Current";
            // 
            // OutCurrentRead
            // 
            this.OutCurrentRead.AutoSize = true;
            this.OutCurrentRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutCurrentRead.Location = new System.Drawing.Point(6, 29);
            this.OutCurrentRead.Name = "OutCurrentRead";
            this.OutCurrentRead.Size = new System.Drawing.Size(95, 73);
            this.OutCurrentRead.TabIndex = 58;
            this.OutCurrentRead.Text = "---";
            // 
            // StatusPicture
            // 
            this.StatusPicture.BackColor = System.Drawing.Color.Transparent;
            this.StatusPicture.Location = new System.Drawing.Point(371, 99);
            this.StatusPicture.Name = "StatusPicture";
            this.StatusPicture.Size = new System.Drawing.Size(51, 39);
            this.StatusPicture.TabIndex = 61;
            this.StatusPicture.TabStop = false;
            // 
            // logEnableCheckBox
            // 
            this.logEnableCheckBox.AutoSize = true;
            this.logEnableCheckBox.Checked = true;
            this.logEnableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logEnableCheckBox.Location = new System.Drawing.Point(11, 73);
            this.logEnableCheckBox.Name = "logEnableCheckBox";
            this.logEnableCheckBox.Size = new System.Drawing.Size(80, 17);
            this.logEnableCheckBox.TabIndex = 62;
            this.logEnableCheckBox.Text = "Log Enable";
            this.logEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 152);
            this.Controls.Add(this.logEnableCheckBox);
            this.Controls.Add(this.StatusPicture);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TurnOnOffBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SetCurrentTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SetVoltageTB);
            this.Controls.Add(this.serialPortConnectBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HandshakeTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ParityTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BaudTB);
            this.Controls.Add(this.rtsCheckBox);
            this.Controls.Add(this.dtrCheckBox);
            this.Controls.Add(this.serialPortNameComboBox);
            this.Name = "MainForm";
            this.Text = "XP Power App";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer serialPortPooling;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox serialPortNameComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox HandshakeTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ParityTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BaudTB;
        private System.Windows.Forms.CheckBox rtsCheckBox;
        private System.Windows.Forms.CheckBox dtrCheckBox;
        private System.Windows.Forms.Button serialPortConnectBtn;
        private System.Windows.Forms.TextBox SetVoltageTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SetCurrentTB;
        private System.Windows.Forms.Button TurnOnOffBtn;
        private System.Windows.Forms.Label OutVoltageRead;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label OutCurrentRead;
        private System.Windows.Forms.PictureBox StatusPicture;
        private System.Windows.Forms.CheckBox logEnableCheckBox;
    }
}

