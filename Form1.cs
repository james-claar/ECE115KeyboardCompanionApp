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
        List<string> programs = new List<string>()
        {
            "notepad.exe",
            "mspaint.exe",
            "systemsettings.exe",
            " ",
            " ",
            "K",
            "S",
            "U",
        };
        List<byte> configuredKeys = new List<byte>()
        {
            (byte) 'A',
            (byte) 'B',
            (byte) 'C',
            (byte) 'D',
            (byte) 'E',
            (byte) 'F',
            (byte) 'G',
            (byte) 'H'
        };
        List<bool> isProgramOpener = new List<bool>()
        {
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false
        };

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
            if (serialPort1.IsOpen)
            {
                List<byte> inputBuffer = new List<byte>();

                // Read until we hit a newline
                int count = 0;
                byte inputByte;
                while (true)
                {
                    while (serialPort1.BytesToRead == 0) { };
                    inputByte = (byte) serialPort1.ReadByte();
                    if (inputByte == '\r')
                    {
                        continue;
                    }
                    else if (inputByte == '\n')
                    {
                        break;
                    }
                    else
                    {
                        inputBuffer.Add(inputByte);
                        count++;
                    }
                }

                if (count == 1)
                {
                    int r = inputBuffer[0] - '0' - 1; // Go through 0-7 instead of 1-8

                    if (r >= 0 && r <= 7)
                    {
                        Process.Start(programs[r]);
                    }
                }
                else if (count == 16)
                {
                    // Binary / ASCII values each key is configured for
                    for (int i = 0; i < 8; i++)
                    {
                        configuredKeys[i] = inputBuffer[i];
                    }

                    // Boolean values of whether each button opens a program
                    for (int i = 0; i < 8; i++)
                    {
                        isProgramOpener[i] = inputBuffer[i + 8] == '1';
                    }
                }
                else
                {
                    MessageBox.Show("Received serial message from Arduino of incorrect length.", "Error");
                }
            }
        }

        private void serialSendClick(object sender, EventArgs e)
        {
            serialPort1.WriteLine(serialSendBox.Text);
        }

        private void button1IsProgramCheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2IsProgramCheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3IsProgramCheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4IsProgramCheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5IsProgramCheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6IsProgramCheckedChanged(object sender, EventArgs e)
        {

        }

        private void button7IsProgramCheckedChanged(object sender, EventArgs e)
        {

        }

        private void button8IsProgramCheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
