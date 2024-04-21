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
        List<string> allPrograms = new List<string>()
        {
            "notepad.exe",
            "mspaint.exe",
            "systemsettings.exe",
        };
        List<int> selectedPrograms = new List<int>() // Which index in allPrograms each button points to
        {
            0,
            1,
            2,
            0,
            0,
            0,
            0,
            0
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
        List<string> allCharacters = new List<string>()
        {
            "a",
            "b",
            "c",
            "d"
        };

        string dataRecieved = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void getArduinoConfiguration()
        {
            serialPort1.WriteLine("C"); // Tell Arduino to print configuration
        }

        private void setProgramOpener(int buttonNo, bool programOpener)
        {
            isProgramOpener[buttonNo - 1] = programOpener;
            string command = "O" + buttonNo.ToString() + (programOpener ? "1" : "0");
            serialPort1.WriteLine(command);
        }

        private void setKeyASCII(int buttonNo, string asciiValue)
        {
            configuredKeys[buttonNo - 1] = (byte) asciiValue[0];
            string command = "O" + buttonNo.ToString() + asciiValue[0];
            serialPort1.WriteLine(command);
        }

        private void setKeyHex(int buttonNo, byte hexValue)
        {
            configuredKeys[buttonNo - 1] = hexValue;
            string command = "H" + buttonNo.ToString() + hexValue.ToString("X2");
            serialPort1.WriteLine(command);
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
                        Process.Start(allPrograms[selectedPrograms[r]]);
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

        private void updateCheckbox(CheckBox checkBox, ComboBox dropdown)
        {
            // Updates Arduino and dropdown given a checkbox that changed.
            bool isChecked = checkBox.Checked;
            setProgramOpener(1, isChecked);
            if (isChecked)
            {
                setDropDownList(dropdown, allPrograms);
            }
            else
            {
                setDropDownList(dropdown, allCharacters);
            }
        }

        private void setDropDownList(ComboBox dropdown, List<string> selectList)
        {
            dropdown.Items.Clear();
            foreach (string item in selectList)
            {
                dropdown.Items.Add(item);
            }
        }

        private void button1IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckbox(button1IsProgram, button1DropDown);
        }

        private void button2IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckbox(button2IsProgram, button2DropDown);
        }

        private void button3IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckbox(button3IsProgram, button3DropDown);
        }

        private void button4IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckbox(button4IsProgram, button4DropDown);
        }

        private void button5IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckbox(button5IsProgram, button5DropDown);
        }

        private void button6IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckbox(button6IsProgram, button6DropDown);
        }

        private void button7IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckbox(button7IsProgram, button7DropDown);
        }

        private void button8IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckbox(button8IsProgram, button8DropDown);
        }

        private void button1DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
