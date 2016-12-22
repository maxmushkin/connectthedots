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
using SimulatedSensors.Contracts;

namespace SimulatedSensors.Windows
{
    public partial class Form1 : Form
    {
        DeviceEmulator Device;

        private delegate void AppendAlert(string AlertText);

        public Form1()
        {
            InitializeComponent();

            // Initialize IoT Hub client
            Device = new DeviceEmulator();
            
            // Prepare UI elements
            buttonConnect.Enabled = false;
            buttonConnect.Click += ButtonConnect_Click; ;

            buttonSend.Enabled = false;
            buttonSend.Click += ButtonSend_Click; ;

            textGatewayId.Text = Properties.Settings.Default.GatewayId;
            textDeviceId.Text = Properties.Settings.Default.DeviceId;
            textObjectTypeInstance.Text = Properties.Settings.Default.ObjectTypeInstance;

            textConnectionString.TextChanged += TextConnectionString_TextChanged;
            textConnectionString.Text = Properties.Settings.Default.ConnectionString;

            trackBarTemperature.ValueChanged += TrackBarTemperature_ValueChanged;

            TrackBarTemperature_ValueChanged(null, null);

            // Set focus to the connect button
            buttonConnect.Focus();

            // Attach receive callback for alerts
            Device.ReceivedMessageEventHandler += Device_ReceivedMessage;
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
            if (Device.Connected)
            {
                Device.UpdateAsset(new Asset {DeviceId = textDeviceId.Text, GatewayId = textGatewayId.Text, ObjectTypeInstance = textObjectTypeInstance.Text, Value = trackBarTemperature.Value});
            }
        }

        private void TextConnectionString_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["ConnectionString"] = textConnectionString.Text;
            Properties.Settings.Default.Save();
            buttonConnect.Enabled = CheckConfig(textConnectionString.Text);
        }

        private void textGatewayId_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["GatewayId"] = textGatewayId.Text;
            Properties.Settings.Default.Save();
        }
        private void textDeviceId_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["DeviceId"] = textDeviceId.Text;
            Properties.Settings.Default.Save();
        }
        private void textObjectTypeInstance_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["ObjectTypeInstance"] = textObjectTypeInstance.Text;
            Properties.Settings.Default.Save();
        }

        private bool CheckConfig(string connectionString)
        {
            if(!string.IsNullOrEmpty(connectionString))
            {
                // ToDo: Add validation here
                return true;
            }

            return false;
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (Device.SendingData)
            {
                Device.Pause();
                textGatewayId.Enabled =
                textDeviceId.Enabled =
                textObjectTypeInstance.Enabled = true;
                buttonSend.Text = "Press to send telemetry data";
            }
            else
            {
                if (CheckConfig(textConnectionString.Text))
                {
                    if (Device.Connected)
                        Device.Resume();

                    textGatewayId.Enabled =
                    textDeviceId.Enabled =
                    textObjectTypeInstance.Enabled = false;

                    buttonSend.Text = "Sending telemetry data";
                }
            }
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            if(CheckConfig(textConnectionString.Text))
            {
                if (Device.Connected)
                {
                    if (Device.Disconnect())
                    {
                        buttonSend.Enabled = false;
                        textConnectionString.Enabled = true;
                        buttonConnect.Text = "Press to connect the dots";
                    }
                }
                else
                {
                    if (Device.Connect(textConnectionString.Text))
                    {
                        buttonSend.Enabled = true;
                        textConnectionString.Enabled = false;
                        buttonConnect.Text = "Dots connected";

                    }
                }
            }
        }
    }
}
