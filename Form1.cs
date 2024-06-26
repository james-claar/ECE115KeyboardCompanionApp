﻿using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace ECE115
{
    public partial class Form1 : Form
    {
        List<string> allProgramFilePaths = new List<string>() // programs that the keyboard can open
        {
            "notepad.exe",
            "mspaint.exe",
            "calc.exe",
            "Taskmgr.exe",
        };
        List<string> allProgramNames = new List<string>()
        {
            "Notepad",
            "MS Paint",
            "Calculator",
            "Task Manager",
        };
        List<int> selectedPrograms = new List<int>() // Which index in allPrograms each button points to
        {
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0
        };
        List<string> configuredKeys = new List<string>()
        {
            "A",
            "B",
            "C",
            "D",
            "E",    
            "F",
            "G",
            "H"
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
        List<string> allCharacters = new List<string>() // characters user can choose from
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "-", "+", "=", "{", "}", "[", "]", "|", "\\", ":", ";", "'", "\"", "<", ">", ",", ".", "?", "/"
        };

        bool isArduinoConnected = false;
        string dataRecieved = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void getArduinoConfiguration()
        {
            try
            {
                serialPort1.WriteLine("C"); // Tell Arduino to print configuration
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void setProgramOpener(int buttonNo, bool programOpener) // configures buttons when program starts
        {
            isProgramOpener[buttonNo - 1] = programOpener;
            string command = "O" + buttonNo.ToString() + (programOpener ? "1" : "0");
            try
            {
                serialPort1.WriteLine(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void setKeyASCII(int buttonNo, string asciiValue) // sets key to ASCII value
        {
            configuredKeys[buttonNo - 1] = asciiValue;
            string command = "V" + buttonNo.ToString() + asciiValue[0];
            try
            {
                serialPort1.WriteLine(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void enableSerialUI()
        {
            // Enables all serial-based elements
            button1IsProgram.Enabled = true;
            button2IsProgram.Enabled = true;
            button3IsProgram.Enabled = true;
            button4IsProgram.Enabled = true;
            button5IsProgram.Enabled = true;
            button6IsProgram.Enabled = true;
            button7IsProgram.Enabled = true;
            button8IsProgram.Enabled = true;
            button1DropDown.Enabled = true;
            button2DropDown.Enabled = true;
            button3DropDown.Enabled = true;
            button4DropDown.Enabled = true;
            button5DropDown.Enabled = true;
            button6DropDown.Enabled = true;
            button7DropDown.Enabled = true;
            button8DropDown.Enabled = true;
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
                serialPort1.PortName = comboBoxPort.Text; // Connects to Arduino
                serialPort1.BaudRate = 115200;
                serialPort1.Open();
                connected.Text = "Connected";

                enableSerialUI();
                getArduinoConfiguration();
            }
            catch
            {
                MessageBox.Show("Couldn't connect to keyboard.", "Error");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
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
                        inputByte = (byte)serialPort1.ReadByte();
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
                            Process.Start(allProgramFilePaths[selectedPrograms[r]]);
                        }
                    }
                    else if (count == 16)
                    {
                        // Binary / ASCII values each key is configured for
                        for (int i = 0; i < 8; i++)
                        {
                            configuredKeys[i] = Encoding.ASCII.GetString(new[] { inputBuffer[i] });
                        }

                        // Boolean values of whether each button opens a program
                        for (int i = 0; i < 8; i++)
                        {
                            isProgramOpener[i] = inputBuffer[i + 8] == '1';
                            updateCheckboxSafe(i + 1, true, isProgramOpener[i], false);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Received serial message from Arduino of incorrect length.", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void updateCheckboxSafe(int buttonNo, bool setCheckbox = false, bool checkboxValue = false, bool tellArduino = true)
        {
            System.Windows.Forms.CheckBox checkBox; // updates combox when check box is pressed from letters to programs and vice versa
            ComboBox dropdown;
            switch (buttonNo)
            {
                case 1:
                    checkBox = button1IsProgram;
                    dropdown = button1DropDown;
                    break;
                case 2:
                    checkBox = button2IsProgram;
                    dropdown = button2DropDown;
                    break;
                case 3:
                    checkBox = button3IsProgram;
                    dropdown = button3DropDown;
                    break;
                case 4:
                    checkBox = button4IsProgram;
                    dropdown = button4DropDown;
                    break;
                case 5:
                    checkBox = button5IsProgram;
                    dropdown = button5DropDown;
                    break;
                case 6:
                    checkBox = button6IsProgram;
                    dropdown = button6DropDown;
                    break;
                case 7:
                    checkBox = button7IsProgram;
                    dropdown = button7DropDown;
                    break;
                case 8:
                    checkBox = button8IsProgram;
                    dropdown = button8DropDown;
                    break;
                default:
                    return;
            }

            // Updates Arduino and dropdown given a checkbox that changed.
            bool isChecked;
            if (setCheckbox)
            {
                isChecked = checkboxValue;
                Action safeSetCheckBox = delegate { checkBox.Checked = checkboxValue; };
                checkBox.Invoke(safeSetCheckBox);
            }
            else
            {
                isChecked = checkBox.Checked;
            }
            if (tellArduino)
            {
                Action safeCheck = delegate {
                    setProgramOpener(buttonNo, isChecked);
                };
                checkBox.Invoke(safeCheck);
            }
            if (isChecked)
            {
                Action safeSetList = delegate
                {
                    setDropDownList(dropdown, allProgramNames);
                    dropdown.SelectedIndex = selectedPrograms[buttonNo - 1];
                };
                dropdown.Invoke(safeSetList);
            }
            else
            {
                Action safeSetList = delegate {
                    setDropDownList(dropdown, allCharacters);
                    dropdown.SelectedIndex = dropdown.Items.IndexOf(configuredKeys[buttonNo - 1]);
                };
                dropdown.Invoke(safeSetList);
            }
        }

        private void setDropDownList(ComboBox dropdown, List<string> selectList)
        {
            List<string> tempList = new List<string>(selectList); // sets list 
            dropdown.DataSource = tempList;
        }
        // updates each individual checkbox that goes to the switch statement
        private void button1IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckboxSafe(1);
        }

        private void button2IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckboxSafe(2);
        }

        private void button3IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckboxSafe(3);
        }

        private void button4IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckboxSafe(4);
        }

        private void button5IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckboxSafe(5);
        }

        private void button6IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckboxSafe(6);
        }

        private void button7IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckboxSafe(7);
        }

        private void button8IsProgramCheckedChanged(object sender, EventArgs e)
        {
            updateCheckboxSafe(8);
        }

        // when the user changes the combo box
        private void button1DropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (button1IsProgram.Checked)
            {
                selectedPrograms[0] = button1DropDown.SelectedIndex;
            }
            else
            {
                setKeyASCII(1, button1DropDown.SelectedItem.ToString());
            }
        }

        private void button2DropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (button2IsProgram.Checked)
            {
                selectedPrograms[1] = button2DropDown.SelectedIndex;
            }
            else
            {
                setKeyASCII(2, button2DropDown.SelectedItem.ToString());
            }
        }

        private void button3DropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (button3IsProgram.Checked)
            {
                selectedPrograms[2] = button3DropDown.SelectedIndex;
            }
            else
            {
                setKeyASCII(3, button3DropDown.SelectedItem.ToString());
            }
        }

        private void button4DropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (button4IsProgram.Checked)
            {
                selectedPrograms[3] = button4DropDown.SelectedIndex;
            }
            else
            {
                setKeyASCII(4, button4DropDown.SelectedItem.ToString());
            }
        }

        private void button5DropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (button5IsProgram.Checked)
            {
                selectedPrograms[4] = button5DropDown.SelectedIndex;
            }
            else
            {
                setKeyASCII(5, button5DropDown.SelectedItem.ToString());
            }
        }

        private void button6DropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (button6IsProgram.Checked)
            {
                selectedPrograms[5] = button6DropDown.SelectedIndex;
            }
            else
            {
                setKeyASCII(6, button6DropDown.SelectedItem.ToString());
            }
        }

        private void button7DropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (button7IsProgram.Checked)
            {
                selectedPrograms[6] = button7DropDown.SelectedIndex;
            }
            else
            {
                setKeyASCII(7, button7DropDown.SelectedItem.ToString());
            }
        }

        private void button8DropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (button8IsProgram.Checked)
            {
                selectedPrograms[7] = button8DropDown.SelectedIndex;
            }
            else
            {
                setKeyASCII(8, button8DropDown.SelectedItem.ToString());
            }
        }
    }
}
