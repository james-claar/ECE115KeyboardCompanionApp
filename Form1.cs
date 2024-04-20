using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;

namespace ECE115
{
    public partial class Form1 : Form
    {
        string dataRecieved = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames(); // Gets available ports and allows computer to pick
            comboBoxPort.Items.AddRange(ports);
           
        }

        private void buttonPort_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBoxPort.Text;
                serialPort1.BaudRate = 115200;
                serialPort1.Open();
                connected.Text = "Connected";
                //serialPort1.Write(textBox1.Text);
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Dictionary<int, string> data = new Dictionary<int, string> { }
            if (serialPort1.IsOpen)
            {
                dataRecieved = serialPort1.ReadLine();

                string check = ".exe";
                if (dataRecieved.Contains(check))
                {
                    Process.Start(dataRecieved);
                }
                else
                {
                    SendKeys.SendWait(dataRecieved);
                    serialPort1.Write(dataRecieved);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // label1.Text = dataRecieved;
        }
    }
}
