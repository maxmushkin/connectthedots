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
        DeviceEmulator DeviceInstance;
        Dictionary<string, DeviceEntity> Devices = new Dictionary<string, DeviceEntity>();
        private DeviceEntity SelectedDevice;

        private delegate void AppendAlert(string AlertText);

        private string ConnectionString => SelectedDevice?.ConnectionString;

        public Form1()
        {
            InitializeComponent();

            // Initialize IoT Hub client
            DeviceInstance = new DeviceEmulator();
            
            buttonSend.Enabled = false;
            buttonSend.Click += ButtonSend_Click; ;

            textGatewayId.Text = Properties.Settings.Default.GatewayId;
            textDeviceId.Text = Properties.Settings.Default.DeviceId;
            textObjectTypeInstance.Text = Properties.Settings.Default.ObjectTypeInstance;

            textConnectionString.TextChanged += TextConnectionString_TextChanged;
            textConnectionString.Text = Properties.Settings.Default.ConnectionString;

            trackBarTemperature.ValueChanged += TrackBarTemperature_ValueChanged;

            TrackBarTemperature_ValueChanged(null, null);
           
            // Attach receive callback for alerts
            DeviceInstance.ReceivedMessageEventHandler += DeviceInstanceReceivedMessage;
            //if (CheckConfig(textConnectionString.Text))
            //    Task.Run(() => this.GetDevices(textConnectionString.Text)).Wait();
        }

        private void DeviceInstanceReceivedMessage(object sender, EventArgs e)
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
            if (DeviceInstance.Connected)
            {
                DeviceInstance.UpdateAsset(new Asset {DeviceId = textDeviceId.Text, GatewayId = textGatewayId.Text, ObjectTypeInstance = textObjectTypeInstance.Text, Value = trackBarTemperature.Value});
            }
        }

        private void TextConnectionString_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["ConnectionString"] = textConnectionString.Text;
            Properties.Settings.Default.Save();
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
            if (DeviceInstance.SendingData)
            {
                DeviceInstance.Pause();
                textGatewayId.Enabled =
                textDeviceId.Enabled =
                textObjectTypeInstance.Enabled = true;
                buttonSend.Text = "Press to send telemetry data";
            }
            else
            {
                if (CheckConfig(textConnectionString.Text))
                {
                    if (DeviceInstance.Connected)
                        DeviceInstance.Resume();

                    textGatewayId.Enabled =
                    textDeviceId.Enabled =
                    textObjectTypeInstance.Enabled = false;

                    buttonSend.Text = "Sending telemetry data";
                }
            }
        }

        private async void btnGetDevices_Click(object sender, EventArgs e)
        {
            await GetDevices(textConnectionString.Text);
        }

        public async Task GetDevices(string connectionString)
        {
            try
            {
                var devicesProcessor = new DevicesProcessor(connectionString, 1000, string.Empty);
                var devices = await devicesProcessor.GetDevices();

                Devices.Clear();

                foreach (var device in devices)
                {
                    Devices.Add(device.Id, device);
                }
                cmbDevices.DataSource = Devices.Keys.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid IoTHub connection string. " + ex.Message);
            }
        }

        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Devices.ContainsKey(cmbDevices.SelectedValue.ToString()))
                Connect(Devices[cmbDevices.SelectedValue.ToString()].ConnectionString);
        }

        private void Connect(string deviceConnectionString)
        {
            if (DeviceInstance.Connected)
            {
                if (DeviceInstance.Disconnect())
                {
                    buttonSend.Enabled = false;
                    textConnectionString.Enabled = true;
                }
            }
            else
            {
                if (DeviceInstance.Connect(deviceConnectionString))
                {
                    buttonSend.Enabled = true;
                    textConnectionString.Enabled = false;
                }
            }
        }

    }
}
