using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        private void connectToArduino()
        {
            string[] ports = SerialPort.GetPortNames(); // Gets available ports and allows computer to pick
            serialPort1.BaudRate = 115200;

            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }

            foreach (string port in ports)
            {
                try
                {
                    serialPort1.PortName = port;
                    serialPort1.Open();

                    connected.Text = "Connected on " + port;
                    break;
                }
                catch { } // Do nothing on fail, check next port
            }

            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("Could not find Arduino", "Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames(); // Gets available ports and allows computer to pick
            comboBoxPort.Items.AddRange(ports);
            connected.Text = "";


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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            List<string> programs = new List<string>()
            {
                "notepad.exe",
                "mspaint.exe",
                "systemsettings.exe",
                "Go cats!",
                " ",
                "K",
                "S",
                "U",
            };

            if (serialPort1.IsOpen)
            {

                dataRecieved = serialPort1.ReadLine();
                int r = Int32.Parse(dataRecieved);
                // dataRecieved = data



                switch (r)
                {
                    case 1:
                        Process.Start("notepad.exe");
                        break;
                    case 2:
                        Process.Start("mspaint.exe");
                        break;
                    case 3:
                        Process.Start("Excel.exe");
                        break;
                    case 4:
                        serialPort1.Write("Go Cats!");
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    default:
                        break;
                }


                /*  if (r == 1 ||)
                  {
                      MessageBox.Show("Hey");
                  }*/
                /*string a = data[dataRecieved];
                MessageBox.Show(dataRecieved);
                if (a.Equals("notepad.exe") || a.Equals("mspaint.exe") || a.Equals("systemsettings.exe"))
                {
                    //string temp = data[dataRecieved];
                    Process.Start(a);                             
                }
                else
                {
                    string temp = data[dataRecieved];
                    SendKeys.SendWait(temp);
                    serialPort1.Write(temp);
                }*/

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // label1.Text = dataRecieved;
            // label1.Text = dataRecieved;
        }

        private void serialSendClick(object sender, EventArgs e)
        {
            serialPort1.WriteLine(serialSendBox.Text);
        }
    }
}
