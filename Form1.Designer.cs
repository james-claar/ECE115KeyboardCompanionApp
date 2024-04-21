namespace ECE115
{
    partial class Form1
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.buttonPort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1Label = new System.Windows.Forms.Label();
            this.connected = new System.Windows.Forms.Label();
            this.serialSendBox = new System.Windows.Forms.TextBox();
            this.button1IsProgram = new System.Windows.Forms.CheckBox();
            this.button1DropDown = new System.Windows.Forms.ComboBox();
            this.button2DropDown = new System.Windows.Forms.ComboBox();
            this.button2IsProgram = new System.Windows.Forms.CheckBox();
            this.button2Label = new System.Windows.Forms.Label();
            this.button4DropDown = new System.Windows.Forms.ComboBox();
            this.button4IsProgram = new System.Windows.Forms.CheckBox();
            this.button4Label = new System.Windows.Forms.Label();
            this.button3DropDown = new System.Windows.Forms.ComboBox();
            this.button3IsProgram = new System.Windows.Forms.CheckBox();
            this.button3Label = new System.Windows.Forms.Label();
            this.button8DropDown = new System.Windows.Forms.ComboBox();
            this.button8IsProgram = new System.Windows.Forms.CheckBox();
            this.button8Label = new System.Windows.Forms.Label();
            this.button7DropDown = new System.Windows.Forms.ComboBox();
            this.button7IsProgram = new System.Windows.Forms.CheckBox();
            this.button7Label = new System.Windows.Forms.Label();
            this.button6DropDown = new System.Windows.Forms.ComboBox();
            this.button6IsProgram = new System.Windows.Forms.CheckBox();
            this.button6Label = new System.Windows.Forms.Label();
            this.button5DropDown = new System.Windows.Forms.ComboBox();
            this.button5IsProgram = new System.Windows.Forms.CheckBox();
            this.button5Label = new System.Windows.Forms.Label();
            this.serialLabel = new System.Windows.Forms.Label();
            this.serialSendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DtrEnable = true;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(135, 21);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(122, 28);
            this.comboBoxPort.TabIndex = 0;
            // 
            // buttonPort
            // 
            this.buttonPort.Location = new System.Drawing.Point(31, 55);
            this.buttonPort.Name = "buttonPort";
            this.buttonPort.Size = new System.Drawing.Size(226, 35);
            this.buttonPort.TabIndex = 1;
            this.buttonPort.Text = "Connect to Keyboard";
            this.buttonPort.UseVisualStyleBackColor = true;
            this.buttonPort.Click += new System.EventHandler(this.buttonPort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select A Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Button Configuration";
            // 
            // button1Label
            // 
            this.button1Label.AutoSize = true;
            this.button1Label.Location = new System.Drawing.Point(47, 173);
            this.button1Label.Name = "button1Label";
            this.button1Label.Size = new System.Drawing.Size(70, 20);
            this.button1Label.TabIndex = 4;
            this.button1Label.Text = "Button 1";
            // 
            // connected
            // 
            this.connected.AutoSize = true;
            this.connected.Location = new System.Drawing.Point(263, 62);
            this.connected.Name = "connected";
            this.connected.Size = new System.Drawing.Size(113, 20);
            this.connected.TabIndex = 21;
            this.connected.Text = "Not connected";
            // 
            // serialSendBox
            // 
            this.serialSendBox.Location = new System.Drawing.Point(462, 57);
            this.serialSendBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.serialSendBox.Name = "serialSendBox";
            this.serialSendBox.Size = new System.Drawing.Size(148, 26);
            this.serialSendBox.TabIndex = 24;
            // 
            // button1IsProgram
            // 
            this.button1IsProgram.AutoSize = true;
            this.button1IsProgram.Enabled = false;
            this.button1IsProgram.Location = new System.Drawing.Point(51, 208);
            this.button1IsProgram.Name = "button1IsProgram";
            this.button1IsProgram.Size = new System.Drawing.Size(104, 24);
            this.button1IsProgram.TabIndex = 26;
            this.button1IsProgram.Text = "Program?";
            this.button1IsProgram.UseVisualStyleBackColor = true;
            this.button1IsProgram.CheckedChanged += new System.EventHandler(this.button1IsProgramCheckedChanged);
            // 
            // button1DropDown
            // 
            this.button1DropDown.Enabled = false;
            this.button1DropDown.FormattingEnabled = true;
            this.button1DropDown.Location = new System.Drawing.Point(51, 238);
            this.button1DropDown.Name = "button1DropDown";
            this.button1DropDown.Size = new System.Drawing.Size(168, 28);
            this.button1DropDown.TabIndex = 27;
            this.button1DropDown.SelectedIndexChanged += new System.EventHandler(this.button1DropDown_SelectedIndexChanged);
            // 
            // button2DropDown
            // 
            this.button2DropDown.Enabled = false;
            this.button2DropDown.FormattingEnabled = true;
            this.button2DropDown.Location = new System.Drawing.Point(226, 238);
            this.button2DropDown.Name = "button2DropDown";
            this.button2DropDown.Size = new System.Drawing.Size(168, 28);
            this.button2DropDown.TabIndex = 30;
            this.button2DropDown.SelectedIndexChanged += new System.EventHandler(this.button2DropDown_SelectedIndexChanged);
            // 
            // button2IsProgram
            // 
            this.button2IsProgram.AutoSize = true;
            this.button2IsProgram.Enabled = false;
            this.button2IsProgram.Location = new System.Drawing.Point(226, 208);
            this.button2IsProgram.Name = "button2IsProgram";
            this.button2IsProgram.Size = new System.Drawing.Size(104, 24);
            this.button2IsProgram.TabIndex = 29;
            this.button2IsProgram.Text = "Program?";
            this.button2IsProgram.UseVisualStyleBackColor = true;
            this.button2IsProgram.CheckedChanged += new System.EventHandler(this.button2IsProgramCheckedChanged);
            // 
            // button2Label
            // 
            this.button2Label.AutoSize = true;
            this.button2Label.Location = new System.Drawing.Point(222, 173);
            this.button2Label.Name = "button2Label";
            this.button2Label.Size = new System.Drawing.Size(70, 20);
            this.button2Label.TabIndex = 28;
            this.button2Label.Text = "Button 2";
            // 
            // button4DropDown
            // 
            this.button4DropDown.Enabled = false;
            this.button4DropDown.FormattingEnabled = true;
            this.button4DropDown.Location = new System.Drawing.Point(574, 238);
            this.button4DropDown.Name = "button4DropDown";
            this.button4DropDown.Size = new System.Drawing.Size(168, 28);
            this.button4DropDown.TabIndex = 36;
            this.button4DropDown.SelectedIndexChanged += new System.EventHandler(this.button4DropDown_SelectedIndexChanged);
            // 
            // button4IsProgram
            // 
            this.button4IsProgram.AutoSize = true;
            this.button4IsProgram.Enabled = false;
            this.button4IsProgram.Location = new System.Drawing.Point(574, 208);
            this.button4IsProgram.Name = "button4IsProgram";
            this.button4IsProgram.Size = new System.Drawing.Size(104, 24);
            this.button4IsProgram.TabIndex = 35;
            this.button4IsProgram.Text = "Program?";
            this.button4IsProgram.UseVisualStyleBackColor = true;
            this.button4IsProgram.CheckedChanged += new System.EventHandler(this.button4IsProgramCheckedChanged);
            // 
            // button4Label
            // 
            this.button4Label.AutoSize = true;
            this.button4Label.Location = new System.Drawing.Point(570, 173);
            this.button4Label.Name = "button4Label";
            this.button4Label.Size = new System.Drawing.Size(70, 20);
            this.button4Label.TabIndex = 34;
            this.button4Label.Text = "Button 4";
            // 
            // button3DropDown
            // 
            this.button3DropDown.Enabled = false;
            this.button3DropDown.FormattingEnabled = true;
            this.button3DropDown.Location = new System.Drawing.Point(400, 238);
            this.button3DropDown.Name = "button3DropDown";
            this.button3DropDown.Size = new System.Drawing.Size(168, 28);
            this.button3DropDown.TabIndex = 33;
            this.button3DropDown.SelectedIndexChanged += new System.EventHandler(this.button3DropDown_SelectedIndexChanged);
            // 
            // button3IsProgram
            // 
            this.button3IsProgram.AutoSize = true;
            this.button3IsProgram.Enabled = false;
            this.button3IsProgram.Location = new System.Drawing.Point(400, 208);
            this.button3IsProgram.Name = "button3IsProgram";
            this.button3IsProgram.Size = new System.Drawing.Size(104, 24);
            this.button3IsProgram.TabIndex = 32;
            this.button3IsProgram.Text = "Program?";
            this.button3IsProgram.UseVisualStyleBackColor = true;
            this.button3IsProgram.CheckedChanged += new System.EventHandler(this.button3IsProgramCheckedChanged);
            // 
            // button3Label
            // 
            this.button3Label.AutoSize = true;
            this.button3Label.Location = new System.Drawing.Point(396, 173);
            this.button3Label.Name = "button3Label";
            this.button3Label.Size = new System.Drawing.Size(70, 20);
            this.button3Label.TabIndex = 31;
            this.button3Label.Text = "Button 3";
            // 
            // button8DropDown
            // 
            this.button8DropDown.Enabled = false;
            this.button8DropDown.FormattingEnabled = true;
            this.button8DropDown.Location = new System.Drawing.Point(574, 375);
            this.button8DropDown.Name = "button8DropDown";
            this.button8DropDown.Size = new System.Drawing.Size(168, 28);
            this.button8DropDown.TabIndex = 48;
            this.button8DropDown.SelectedIndexChanged += new System.EventHandler(this.button8DropDown_SelectedIndexChanged);
            // 
            // button8IsProgram
            // 
            this.button8IsProgram.AutoSize = true;
            this.button8IsProgram.Enabled = false;
            this.button8IsProgram.Location = new System.Drawing.Point(574, 345);
            this.button8IsProgram.Name = "button8IsProgram";
            this.button8IsProgram.Size = new System.Drawing.Size(104, 24);
            this.button8IsProgram.TabIndex = 47;
            this.button8IsProgram.Text = "Program?";
            this.button8IsProgram.UseVisualStyleBackColor = true;
            this.button8IsProgram.CheckedChanged += new System.EventHandler(this.button8IsProgramCheckedChanged);
            // 
            // button8Label
            // 
            this.button8Label.AutoSize = true;
            this.button8Label.Location = new System.Drawing.Point(570, 310);
            this.button8Label.Name = "button8Label";
            this.button8Label.Size = new System.Drawing.Size(70, 20);
            this.button8Label.TabIndex = 46;
            this.button8Label.Text = "Button 8";
            // 
            // button7DropDown
            // 
            this.button7DropDown.Enabled = false;
            this.button7DropDown.FormattingEnabled = true;
            this.button7DropDown.Location = new System.Drawing.Point(400, 375);
            this.button7DropDown.Name = "button7DropDown";
            this.button7DropDown.Size = new System.Drawing.Size(168, 28);
            this.button7DropDown.TabIndex = 45;
            this.button7DropDown.SelectedIndexChanged += new System.EventHandler(this.button7DropDown_SelectedIndexChanged);
            // 
            // button7IsProgram
            // 
            this.button7IsProgram.AutoSize = true;
            this.button7IsProgram.Enabled = false;
            this.button7IsProgram.Location = new System.Drawing.Point(400, 345);
            this.button7IsProgram.Name = "button7IsProgram";
            this.button7IsProgram.Size = new System.Drawing.Size(104, 24);
            this.button7IsProgram.TabIndex = 44;
            this.button7IsProgram.Text = "Program?";
            this.button7IsProgram.UseVisualStyleBackColor = true;
            this.button7IsProgram.CheckedChanged += new System.EventHandler(this.button7IsProgramCheckedChanged);
            // 
            // button7Label
            // 
            this.button7Label.AutoSize = true;
            this.button7Label.Location = new System.Drawing.Point(396, 310);
            this.button7Label.Name = "button7Label";
            this.button7Label.Size = new System.Drawing.Size(70, 20);
            this.button7Label.TabIndex = 43;
            this.button7Label.Text = "Button 7";
            // 
            // button6DropDown
            // 
            this.button6DropDown.Enabled = false;
            this.button6DropDown.FormattingEnabled = true;
            this.button6DropDown.Location = new System.Drawing.Point(226, 375);
            this.button6DropDown.Name = "button6DropDown";
            this.button6DropDown.Size = new System.Drawing.Size(168, 28);
            this.button6DropDown.TabIndex = 42;
            this.button6DropDown.SelectedIndexChanged += new System.EventHandler(this.button6DropDown_SelectedIndexChanged);
            // 
            // button6IsProgram
            // 
            this.button6IsProgram.AutoSize = true;
            this.button6IsProgram.Enabled = false;
            this.button6IsProgram.Location = new System.Drawing.Point(226, 345);
            this.button6IsProgram.Name = "button6IsProgram";
            this.button6IsProgram.Size = new System.Drawing.Size(104, 24);
            this.button6IsProgram.TabIndex = 41;
            this.button6IsProgram.Text = "Program?";
            this.button6IsProgram.UseVisualStyleBackColor = true;
            this.button6IsProgram.CheckedChanged += new System.EventHandler(this.button6IsProgramCheckedChanged);
            // 
            // button6Label
            // 
            this.button6Label.AutoSize = true;
            this.button6Label.Location = new System.Drawing.Point(222, 310);
            this.button6Label.Name = "button6Label";
            this.button6Label.Size = new System.Drawing.Size(70, 20);
            this.button6Label.TabIndex = 40;
            this.button6Label.Text = "Button 6";
            // 
            // button5DropDown
            // 
            this.button5DropDown.Enabled = false;
            this.button5DropDown.FormattingEnabled = true;
            this.button5DropDown.Location = new System.Drawing.Point(51, 375);
            this.button5DropDown.Name = "button5DropDown";
            this.button5DropDown.Size = new System.Drawing.Size(168, 28);
            this.button5DropDown.TabIndex = 39;
            this.button5DropDown.SelectedIndexChanged += new System.EventHandler(this.button5DropDown_SelectedIndexChanged);
            // 
            // button5IsProgram
            // 
            this.button5IsProgram.AutoSize = true;
            this.button5IsProgram.Enabled = false;
            this.button5IsProgram.Location = new System.Drawing.Point(51, 345);
            this.button5IsProgram.Name = "button5IsProgram";
            this.button5IsProgram.Size = new System.Drawing.Size(104, 24);
            this.button5IsProgram.TabIndex = 38;
            this.button5IsProgram.Text = "Program?";
            this.button5IsProgram.UseVisualStyleBackColor = true;
            this.button5IsProgram.CheckedChanged += new System.EventHandler(this.button5IsProgramCheckedChanged);
            // 
            // button5Label
            // 
            this.button5Label.AutoSize = true;
            this.button5Label.Location = new System.Drawing.Point(47, 310);
            this.button5Label.Name = "button5Label";
            this.button5Label.Size = new System.Drawing.Size(70, 20);
            this.button5Label.TabIndex = 37;
            this.button5Label.Text = "Button 5";
            // 
            // serialLabel
            // 
            this.serialLabel.AutoSize = true;
            this.serialLabel.Location = new System.Drawing.Point(550, 29);
            this.serialLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.serialLabel.Name = "serialLabel";
            this.serialLabel.Size = new System.Drawing.Size(128, 20);
            this.serialLabel.TabIndex = 25;
            this.serialLabel.Text = "Serial debugging";
            // 
            // serialSendButton
            // 
            this.serialSendButton.Enabled = false;
            this.serialSendButton.Location = new System.Drawing.Point(621, 54);
            this.serialSendButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.serialSendButton.Name = "serialSendButton";
            this.serialSendButton.Size = new System.Drawing.Size(112, 35);
            this.serialSendButton.TabIndex = 22;
            this.serialSendButton.Text = "send";
            this.serialSendButton.UseVisualStyleBackColor = true;
            this.serialSendButton.Click += new System.EventHandler(this.serialSendClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 475);
            this.Controls.Add(this.button8DropDown);
            this.Controls.Add(this.button8IsProgram);
            this.Controls.Add(this.button8Label);
            this.Controls.Add(this.button7DropDown);
            this.Controls.Add(this.button7IsProgram);
            this.Controls.Add(this.button7Label);
            this.Controls.Add(this.button6DropDown);
            this.Controls.Add(this.button6IsProgram);
            this.Controls.Add(this.button6Label);
            this.Controls.Add(this.button5DropDown);
            this.Controls.Add(this.button5IsProgram);
            this.Controls.Add(this.button5Label);
            this.Controls.Add(this.button4DropDown);
            this.Controls.Add(this.button4IsProgram);
            this.Controls.Add(this.button4Label);
            this.Controls.Add(this.button3DropDown);
            this.Controls.Add(this.button3IsProgram);
            this.Controls.Add(this.button3Label);
            this.Controls.Add(this.button2DropDown);
            this.Controls.Add(this.button2IsProgram);
            this.Controls.Add(this.button2Label);
            this.Controls.Add(this.button1DropDown);
            this.Controls.Add(this.button1IsProgram);
            this.Controls.Add(this.serialLabel);
            this.Controls.Add(this.serialSendBox);
            this.Controls.Add(this.serialSendButton);
            this.Controls.Add(this.connected);
            this.Controls.Add(this.button1Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPort);
            this.Controls.Add(this.comboBoxPort);
            this.Name = "Form1";
            this.Text = "  ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Button buttonPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label button1Label;
        private System.Windows.Forms.Label connected;
        private System.Windows.Forms.TextBox serialSendBox;
        private System.Windows.Forms.CheckBox button1IsProgram;
        private System.Windows.Forms.ComboBox button1DropDown;
        private System.Windows.Forms.ComboBox button2DropDown;
        private System.Windows.Forms.CheckBox button2IsProgram;
        private System.Windows.Forms.Label button2Label;
        private System.Windows.Forms.ComboBox button4DropDown;
        private System.Windows.Forms.CheckBox button4IsProgram;
        private System.Windows.Forms.Label button4Label;
        private System.Windows.Forms.ComboBox button3DropDown;
        private System.Windows.Forms.CheckBox button3IsProgram;
        private System.Windows.Forms.Label button3Label;
        private System.Windows.Forms.ComboBox button8DropDown;
        private System.Windows.Forms.CheckBox button8IsProgram;
        private System.Windows.Forms.Label button8Label;
        private System.Windows.Forms.ComboBox button7DropDown;
        private System.Windows.Forms.CheckBox button7IsProgram;
        private System.Windows.Forms.Label button7Label;
        private System.Windows.Forms.ComboBox button6DropDown;
        private System.Windows.Forms.CheckBox button6IsProgram;
        private System.Windows.Forms.Label button6Label;
        private System.Windows.Forms.ComboBox button5DropDown;
        private System.Windows.Forms.CheckBox button5IsProgram;
        private System.Windows.Forms.Label button5Label;
        private System.Windows.Forms.Label serialLabel;
        private System.Windows.Forms.Button serialSendButton;
    }
}

