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
using Microsoft.Azure.Devices.Client;
using SimulatedSensors;
using SimulatedSensors.Contracts;

namespace SimulatedSensors.Windows
{
    public partial class MainForm : Form
    {
        ConnectTheDots Device = null;

        private delegate void AppendAlert(string AlertText);

        private string activeIoTHubConnectionString = "";

        public MainForm()
        {
            InitializeComponent();

            // Initialize IoT Hub client

            // Prepare UI elements
            buttonConnect.Enabled = false;
            buttonConnect.Click += ButtonConnect_Click; ;

            buttonSend.Enabled = false;
            buttonSend.Click += ButtonSend_Click; ;

            textDeviceName.TextChanged += TextDeviceName_TextChanged;
            textDeviceName.Text = Properties.Settings.Default.DeviceId;

            textConnectionString.TextChanged += TextConnectionString_TextChanged;
            textConnectionString.Text = Properties.Settings.Default.IoTHubConnectionString;

            trackBarTemperature.ValueChanged += TrackBarTemperature_ValueChanged;

            TrackBarTemperature_ValueChanged(null, null);

            // Set focus to the connect button
            buttonConnect.Focus();

            // Attach receive callback for alerts
            Device.ReceivedMessage += Device_ReceivedMessage;
        }

        private void Device_ReceivedMessage(object sender, EventArgs e)
        {
            C2DMessage message = ((ReceivedMessageEventArgs)e).Message;
            var textToDisplay = message.timecreated + " - Alert received:" + message.message + ": " + message.value + " " + message.unitofmeasure + "\r\n";
            this.BeginInvoke(new AppendAlert(Target), textToDisplay);
        }

        private void Target(string text)
        {
            textAlerts.AppendText(text);
            //textAlerts.SelectedText = text;
        }

        private void TrackBarTemperature_ValueChanged(object sender, EventArgs e)
        {
            labelTemperature.Text = "Value: " + trackBarTemperature.Value;
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
            if(!string.IsNullOrEmpty(device.ConnectionString))
            {
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

        private void buttonConnect_Click_1(object sender, EventArgs e)
        {
            parseIoTHubConnectionString(textConnectionString.Text);
        }

        private void parseIoTHubConnectionString(string cs)
        {
            try
            {
                IotHubConnectionStringBuilder builder = IotHubConnectionStringBuilder.Create(cs);
                activeIoTHubConnectionString = cs;
            }
            catch (Exception exception)
            {
                throw new ArgumentException("Invalid IoTHub connection string. " + exception.Message);
            }
        }
    }
}
