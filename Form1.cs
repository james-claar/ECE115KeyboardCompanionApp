/*
 * ECE115Keyboard
 * 
 * Configurable using serial, and stores configuration in EEPROM.
 * 
 * Command formatting:
 * <COMMAND_CHARACTER><SWITCH NUMBER (1-8)><VALUE><newline character>
 * 
 * Example:
 * V1N\n
 * where \n is a newline character and not '\' followed by 'n'
 * 
 * Command List:
 * 
 * - P (Note: this is just a 'P' followed by a newline)
 *   - Pings the Arduino. Arduino will send back "P\n" over serial
 * 
 * - C (Note: this is just a 'C' followed by a newline)
 *   - Prints out configuration over serial in the form ABCDEFGH10011010\n
 *   - This is just the configured values of each button, followed by 0 or 1 for
 *   - each switch, representing whether or not it is configured to open a program.
 * 
 * - O
 *   - Sets whether Open Program Mode is on for a key. If this is set to 1 (true) for a key, pressing the key 
 *   - sends the key's number (1-8) over serial, instead of sending its configured value through the Keyboard library.
 *   - Example:
 *   -   O31\n
 *   -   sets key #3 to open a program since the last character is 1 and not 0.
 *   -   
 *   -   O30\n
 *   -   would turn off Open Program Mode for key #3.
 * 
 * - V
 *   - Sets a key to a specified ASCII value. For example,
 *   - Example:
 *   -   V6H
 *   -   sets key #6 to the ASCII value 'H', so when you press key #6, it types 'H' through the Keyboard library.
 * 
 * - H
 *   - Sets a key to a specified hex value. This is useful for keyboard modifiers, like F1, that don't have
 *   - an ascii value. See https://www.arduino.cc/reference/en/language/functions/usb/keyboard/keyboardmodifiers/ for a
 *   - list of hex codes for keyboard modifiers.
 *   - Example:
 *   -   H4C2
 *   -   sets H4 to the binary value of 0xC2, which will be sent through the Keyboard library when
 *   -   the key is pressed.
 */

#include <Keyboard.h>
#include <EEPROM.h>

// Pin configuration
#define PIN_SW1 2
#define PIN_SW2 3
#define PIN_SW3 4
#define PIN_SW4 5
#define PIN_SW5 6
#define PIN_SW6 7
#define PIN_SW7 8
#define PIN_SW8 9

// Configuration
#define NUM_BUTTONS 8 // How many buttons to use
#define DEBOUNCE_THRESHOLD 10 // How long (in ms) to wait before checking for more button presses
#define BAUD_RATE 115200

const int buttonPins[] = {
  PIN_SW1,
  PIN_SW2,
  PIN_SW3,
  PIN_SW4,
  PIN_SW5,
  PIN_SW6,
  PIN_SW7,
  PIN_SW8
};

// Sent by serial when we want to open a program
const char buttonSerialOut[] = {
  '1',
  '2',
  '3',
  '4',
  '5',
  '6',
  '7',
  '8'
};

// Sent using Keyboard library when we want to press/release a key
unsigned char buttonKeyboardCharacters[] = {
    'A',
  'B',
  'C',
  'D',
  'E',
  'F',
  'G',
  'H'
};

bool isProgramOpener[] = {
  false,
  false,
  false,
  false,
  false,
  false,
  false,
  false
};

const int EEPROMKeysAddress = 0;
const int EEPROMProgramOpenerAddress = EEPROMKeysAddress + sizeof(buttonKeyboardCharacters);

bool buttonState[NUM_BUTTONS]; // For each button, whether it is currently pressed.
unsigned long lastEdge[NUM_BUTTONS] ; // Time of last edge in ms (that we acted upon)

void setup()
{
    Serial.begin(BAUD_RATE); // Serial
    Keyboard.begin(); // Keyboard

    // Initial values for button debouncer
    for (int i = 0; i < NUM_BUTTONS; i++)
    {
        buttonState[i] = false;
        lastEdge[i] = 0;
    }

    // Set up pins
    for (int i = 0; i < NUM_BUTTONS; i++)
    {
        pinMode(buttonPins[i], INPUT_PULLUP);
    }

    getConfigurationFromEEPROM();
}

void loop()
{
    updateButtons(); // Handle button state changes / debouncing
    checkSerial();   // Handle incoming serial messages
}

void saveConfigurationToEEPROM()
{
    EEPROM.put(EEPROMKeysAddress, buttonKeyboardCharacters);
    EEPROM.put(EEPROMProgramOpenerAddress, isProgramOpener);
}

void getConfigurationFromEEPROM()
{
    EEPROM.get(EEPROMKeysAddress, buttonKeyboardCharacters);
    EEPROM.get(EEPROMProgramOpenerAddress, isProgramOpener);
}

char asciiHexCharToNibble(char asciiHex)
{
    if (asciiHex >= '0' && asciiHex <= '9')
    {
        return asciiHex - '0';
    }
    else if (asciiHex >= 'a' && asciiHex <= 'f')
    {
        return asciiHex - 'a' + 10;
    }
    else if (asciiHex >= 'A' && asciiHex <= 'F')
    {
        return asciiHex - 'A' + 10;
    }
    else
    {
        return 0;
    }
}

char commandChar;
char switchNo;
char commandValue[10];
char commandValueSize = 0;
bool isCommandCharValid;
bool isSwitchNoValid;
bool isCommandValid;
void checkSerial()
{
    // Handles incoming serial messages.
    if (Serial.available() >= 1)
    { // Message in serial buffer
        commandChar = Serial.read();

        if (commandChar == 'P')
        {
            while (!Serial.available()) { }
            Serial.read(); // Remove the newline

            Serial.println("P");
            return;
        }
        else if (commandChar == 'C')
        { // One-character command, process and end immediately
            while (!Serial.available()) { }
            Serial.read(); // Remove the newline

            for (int i = 0; i < 8; i++)
            {
                Serial.write(buttonKeyboardCharacters[i]); // Write raw character data over serial
            }
            for (int i = 0; i < 8; i++)
            {
                Serial.print(isProgramOpener[i]);
            }
            Serial.println(); // Newline

            return;
        }

        // Get switch number
        while (Serial.available() == 0) { } // Wait for another character
        switchNo = Serial.read() - '0' - 1;

        commandValueSize = 0;
        while (commandValueSize <= 9)
        {
            if (Serial.available())
            {
                commandValue[commandValueSize] = Serial.read();
                if (commandValue[commandValueSize] == '\n')
                { // End of value
                    commandValueSize++;
                    break;
                }
                commandValueSize++;
            }
        }
    }

    if (commandChar == 'O')
    { // Open command - tells whether a switch should open a program
        isProgramOpener[switchNo] = (commandValue[0] != '0');
    }
    else if (commandChar == 'V')
    { // Value command - tells a switch to mimic a particular character
        buttonKeyboardCharacters[switchNo] = commandValue[0];
        saveConfigurationToEEPROM();
    }
    else if (commandChar == 'H')
    { // H value command - tells a switch to use an 8-bit binary value sent in ascii-encoded hex form.
        buttonKeyboardCharacters[switchNo] = (asciiHexCharToNibble(commandValue[0]) << 4) | (asciiHexCharToNibble(commandValue[1]));
        saveConfigurationToEEPROM();
    }
}

bool isPressingKey;
void handleButtonPress(int index)
{
    // Called from updateButtons when a debounced button press or release is detected.
    isPressingKey = buttonState[index];
    if (isProgramOpener[index])
    {
        if (isPressingKey)
        { // Send only on press, not release
            Serial.println(buttonSerialOut[index]);
        }
    }
    else
    {
        sendKeyChange(buttonKeyboardCharacters[index], isPressingKey);
    }
}

void sendKeyChange(char character, bool isPressing)
{
    // Presses or releases the specified character using the Keyboard library
    if (isPressing)
    {
        Keyboard.press(character);
    }
    else
    {
        Keyboard.release(character);
    }
}

unsigned long currentMillis;
bool buttonStatus;
bool hasChanged;
bool longEnoughSinceLastEdge;
void updateButtons()
{
    // Checks the state of each button, debounces them, and sends any changes to handleButtonPress()
    for (int i = 0; i < NUM_BUTTONS; i++)
    {
        currentMillis = millis();
        buttonStatus = digitalRead(buttonPins[i]) == LOW; // True if button is pressed, false otherwise

        hasChanged = buttonStatus != buttonState[i];
        longEnoughSinceLastEdge = currentMillis >= (lastEdge[i] + DEBOUNCE_THRESHOLD);
        if (hasChanged && longEnoughSinceLastEdge)
        {
            buttonState[i] = buttonStatus; // Record the change
            lastEdge[i] = currentMillis;

            handleButtonPress(i);
        }
    }
}












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

            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                {"1" , "notepad.exe" },
                {"2" , "mspaint.exe" },
                {"3" , "systemsettings.exe"},
                {"4" , "Go cats!"},
                {"5" , " "},
                {"6" , "K"},
                {"7" , "S"},
                {"8" , "U"},


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
                        SendKeys.SendWait(" ");
                        serialPort1.Write(" ");
                        break;
                    case 6:
                        SendKeys.SendWait("K");
                        serialPort1.Write("K");
                        break;
                    case 7:
                        SendKeys.SendWait("S");
                        serialPort1.Write("S");
                        break;
                    case 8:
                        SendKeys.SendWait("U");
                        serialPort1.Write("U");
                        break;
                    default:
                        SendKeys.SendWait(" ");
                        serialPort1.Write(" ");
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
    }
}
