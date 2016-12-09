using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimulatedSensors;

namespace SimulatedSensors.Windows
{
    public partial class Form1 : Form
    {
        MyClass Device;

        private delegate void AppendAlert(string AlertText);

        public Form1()
        {
            InitializeComponent();

            // Initialize IoT Hub client
            Device = new MyClass(textDeviceName.Text);

            // Prepare UI elements
            buttonConnect.Enabled = false;
            buttonConnect.Click += ButtonConnect_Click; ;

            buttonSend.Enabled = false;
            buttonSend.Click += ButtonSend_Click; ;

            textDeviceName.TextChanged += TextDeviceName_TextChanged;
            //textDeviceName.Text = Device.DeviceId;

            textConnectionString.TextChanged += TextConnectionString_TextChanged;
            textConnectionString.Text = Device.ConnectionString;

            trackBarTemperature.ValueChanged += TrackBarTemperature_ValueChanged;

            // Set focus to the connect button
            buttonConnect.Focus();

            // Attach receive callback for alerts
            Device.ReceivedMessage += Device_ReceivedMessage;
        }

        private void Device_ReceivedMessage(object sender, EventArgs e)
        {
            ConnectTheDotsHelper.C2DMessage message = ((ConnectTheDotsHelper.ConnectTheDots.ReceivedMessageEventArgs)e).Message;
            var textToDisplay = message.timecreated + " - Alert received:" + message.message + ": " + message.value + " " + message.unitofmeasure + "\r\n";
            this.BeginInvoke(new AppendAlert((string text) => textAlerts.AppendText(text)), textToDisplay);
        }
        
        private void TrackBarTemperature_ValueChanged(object sender, EventArgs e)
        {
            labelTemperature.Text = "Temperature: " + trackBarTemperature.Value;
            Device.UpdateSensorData(Device.DeviceId, trackBarTemperature.Value);
        }

        private void TextConnectionString_TextChanged(object sender, EventArgs e)
        {
            Device.ConnectionString = textConnectionString.Text;
            buttonConnect.Enabled = Device.checkConfig();
        }

        private void TextDeviceName_TextChanged(object sender, EventArgs e)
        {
            Device.DeviceId = textDeviceName.Text;
            buttonConnect.Enabled = Device.checkConfig();
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (Device.SendTelemetryData)
            {

                Device.SendTelemetryData = false;
                buttonSend.Text = "Press to send telemetry data";
            }
            else
            {
                Device.SendTelemetryData = true;
                buttonSend.Text = "Sending telemetry data";
            }
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            {
                if (Device.IsConnected)
                {
                    Device.SendTelemetryData = false;
                    if (Device.Disconnect())
                    {
                        buttonSend.Enabled = false;
                        textDeviceName.Enabled = true;
                        textConnectionString.Enabled = true;
                        buttonConnect.Text = "Press to connect the dots";
                    }
                }
                else
                {
                    if (Device.Connect())
                    {
                        buttonSend.Enabled = true;
                        textDeviceName.Enabled = false;

                        textConnectionString.Enabled = false;
                        buttonConnect.Text = "Dots connected";

                    }
                }
            }
        }
    }
}
