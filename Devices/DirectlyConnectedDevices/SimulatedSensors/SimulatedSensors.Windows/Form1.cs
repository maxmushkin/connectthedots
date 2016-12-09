using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectTheDotsHelper;
using SimulatedSensors;

namespace SimulatedSensors.Windows
{
    public partial class Form1 : Form
    {
        ConnectTheDots Device;

        private delegate void AppendAlert(string AlertText);

        public Form1()
        {
            InitializeComponent();

            // Initialize IoT Hub client
            Device = new ConnectTheDots();

            // Prepare UI elements
            buttonConnect.Enabled = false;
            buttonConnect.Click += ButtonConnect_Click; ;

            buttonSend.Enabled = false;
            buttonSend.Click += ButtonSend_Click; ;

            textDeviceName.TextChanged += TextDeviceName_TextChanged;
            textDeviceName.Text = Properties.Settings.Default.DeviceId;

            textConnectionString.TextChanged += TextConnectionString_TextChanged;
            textConnectionString.Text = Properties.Settings.Default.ConnectionString;

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
            Properties.Settings.Default["ConnectionString"] = textConnectionString.Text;
            Properties.Settings.Default.Save();
            buttonConnect.Enabled = CheckConfig(Device);
        }

        private void TextDeviceName_TextChanged(object sender, EventArgs e)
        {
            Device.DeviceId = textDeviceName.Text;
            Properties.Settings.Default["DeviceId"] = textDeviceName.Text;
            Properties.Settings.Default.Save();
            buttonConnect.Enabled = CheckConfig(Device);
        }

        private bool CheckConfig(ConnectTheDots device)
        {
            if(!string.IsNullOrEmpty(device.DeviceId) && !string.IsNullOrEmpty(device.ConnectionString))
            {
                device.AddSensor(device.DeviceId, device.ConnectionString);
                return true;
            }

            return false;
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
