using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Dapper;
using Newtonsoft.Json;
using SimulatedSensors.Contracts;
using Timer = System.Windows.Forms.Timer;

namespace SimulatedSensors.Windows
{
    public partial class Form1 : Form
    {
        DeviceSimulator DeviceInstance = new DeviceSimulator();
        Dictionary<string, DeviceEntity> Devices = new Dictionary<string, DeviceEntity>();
        private DeviceEntity SelectedDevice;

        private List<BACmap> RefData = new List<BACmap>();

        private delegate void AppendAlert(string AlertText);

        private StringBuilder errorsList = new StringBuilder();
        private int SentMessagesCount = 0;

        public string SelectedGatewayId => cmbGatewayId.Text;

        public string SelectedHubDeviceId => cmbHubDevices.SelectedValue.ToString();

        public string SelectedDeviceId => cmbDeviceId.SelectedItem.ToString();

        public string SelectedObjectType => cmbObjectType.Text;

        private string dbcs
        {
            get
            {
                if (!string.IsNullOrEmpty(textDBConnectionString.Text))
                    return textDBConnectionString.Text;
                if (ConfigurationManager.ConnectionStrings["RefData"] != null)
                    return ConfigurationManager.ConnectionStrings["RefData"].ConnectionString;
                else return string.Empty;
            }
        }

        public Form1()
        {
            InitializeComponent();

            buttonSend.Enabled = false;

            textConnectionString.TextChanged += TextConnectionString_TextChanged;
            textConnectionString.Text = Properties.Settings.Default.IoTHubConnectionString;

            trackBarTemperature.ValueChanged += TrackBarTemperature_ValueChanged;

            TrackBarTemperature_ValueChanged(null, null);
        }

        private void DeviceInstance_SentMessageEventHandler(object sender, EventArgs e)
        {
            C2DMessage message = ((ReceivedMessageEventArgs)e).Message;
            if (SentMessagesCount % 10 == 0 || message.alerttype.ToLower() == "error")
            {
                if (message.alerttype.ToLower() == "error")
                    errorsList.AppendLine(message.message);
                this.BeginInvoke(new AppendAlert(Target), message.alerttype + " - " + message.message);
            }

            SentMessagesCount++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (1000);
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void DeviceInstanceReceivedMessage(object sender, EventArgs e)
        {
            C2DMessage message = ((ReceivedMessageEventArgs)e).Message;
            var textToDisplay = message.timecreated + " - Alert received:" + message.message + ": " + message.value + " " + message.unitofmeasure;
            this.BeginInvoke(new AppendAlert(Target), textToDisplay);
        }

        private void Target(string text)
        {
            if (textAlerts.Text.Length > 4096)
                textAlerts.Clear();

            textAlerts.AppendText(text + "\r\n");
        }

        private void TrackBarTemperature_ValueChanged(object sender, EventArgs e)
        {
            labelTemperature.Text = "Value: " + trackBarTemperature.Value;
            UpdateAsset();
        }

        private void UpdateAsset()
        {
            if (DeviceInstance.Connected)
            {
                DeviceInstance.UpdateAsset(new Asset
                {
                    DeviceId = cmbDeviceId.Text,
                    GatewayName = cmbGatewayId.Text,
                    ObjectType = cmbObjectType.Text,
                    Instance = cmbInstance.Text,
                    Value = trackBarTemperature.Value,
                    Variation = checkBoxVariation.Checked
                });
            }
        }

        private void TextConnectionString_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["IoTHubConnectionString"] = textConnectionString.Text;
            Properties.Settings.Default.Save();
        }

        private bool CheckConfig(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                // ToDo: Add validation here
                return true;
            }

            return false;
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            ToggleSendingData();
        }

        private void ToggleSendingData()
        {
            if (DeviceInstance.SendingData)
            {
                DeviceInstance.Pause();
                btnGetDevices.Enabled =
                cmbHubDevices.Enabled =
                cmbGatewayId.Enabled =
                    cmbDeviceId.Enabled =
                        cmbObjectType.Enabled =
                            checkBoxVariation.Enabled = true;
                buttonSend.Text = "Press to send telemetry data";
            }
            else
            {
                if (CheckConfig(textConnectionString.Text))
                {
                    if (DeviceInstance.Connected)
                        DeviceInstance.Resume();

                    UpdateAsset();

                    btnGetDevices.Enabled =
                    cmbHubDevices.Enabled =
                    cmbGatewayId.Enabled =
                        cmbDeviceId.Enabled =
                            cmbObjectType.Enabled =
                                checkBoxVariation.Enabled = false;

                    buttonSend.Text = "Sending telemetry data";
                }
            }
        }

        private async void btnGetDevices_Click(object sender, EventArgs e)
        {
            try
            {
                btnGetDevices.Enabled = false;
                await GetDevices(textConnectionString.Text);
            }
            catch (Exception ex)
            {
                Target(ex.Message);
            }
            finally
            {
                btnGetDevices.Enabled = true;
            }
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
                cmbHubDevices.DataSource = Devices.Keys.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid IoTHub connection string. " + ex.Message);
            }
        }


        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((SelectedDevice == null) || (Devices.ContainsKey(SelectedHubDeviceId) && SelectedDevice.Id != SelectedHubDeviceId))
            {
                if (DeviceInstance.Connected)
                {
                    if (DeviceInstance.Disconnect())
                    {
                        buttonSend.Enabled = false;
                    }
                }

                // Initialize IoT Hub client
                DeviceInstance = new DeviceSimulator();

                // Attach receive callback for alerts
                DeviceInstance.ReceivedMessageEventHandler += DeviceInstanceReceivedMessage;
                DeviceInstance.SentMessageEventHandler += DeviceInstance_SentMessageEventHandler;

                SelectedDevice = Devices[SelectedHubDeviceId];
                Connect(SelectedDevice.ConnectionString);
            }
            else
            {
                buttonSend.Enabled = true;
            }
        }

        private void Connect(string deviceConnectionString)
        {
            if (DeviceInstance.Connect(deviceConnectionString))
            {
                buttonSend.Enabled = true;
            }

            if (!string.IsNullOrEmpty(dbcs))
            {
                RefData = GetData(dbcs);
                var gateways = RefData.Select(d => d.GatewayName).Distinct().ToList();
                cmbGatewayId.DataSource = gateways;
            }
        }

        public List<BACmap> GetData(string connectionString)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<BACmap>("SELECT * FROM BACmap").ToList();
            }
        }


        private void cmbGatewayId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedGatewayId))
            {
                cmbDeviceId.DataSource = null;
                return;
            }

            var devices = RefData.Where(i => i.GatewayName == SelectedGatewayId).Select(d => d.DeviceName).Distinct().ToList();
            cmbDeviceId.DataSource = devices.Count > 0 ? devices : null;
        }


        private void cmbDeviceId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedGatewayId) || string.IsNullOrEmpty(SelectedGatewayId))
            {
                cmbObjectType.DataSource = null;
                return;
            }

            var oti =
                RefData.Where(i => i.GatewayName == SelectedGatewayId && i.DeviceName == SelectedDeviceId)
                    .Select(d => d.ObjectType)
                    .Distinct()
                    .ToList();

            cmbObjectType.DataSource = oti.Count > 0 ? oti : null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DeviceInstance.Connected && DeviceInstance.SendingData)
            {
                lblSentCount.Text = "(" + SentMessagesCount + ")";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E && errorsList.Length > 0)
            {
                textAlerts.Clear();
                textAlerts.Text = errorsList.ToString();
            }
        }

        private void cmbObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedGatewayId) || string.IsNullOrEmpty(SelectedGatewayId) || string.IsNullOrEmpty(SelectedObjectType))
            {
                cmbInstance.DataSource = null;
                return;
            }

            var data =
                RefData.Where(i => i.GatewayName == SelectedGatewayId && i.DeviceName == SelectedDeviceId && i.ObjectType == SelectedObjectType)
                    .Select(d => d.Instance)
                    .Distinct()
                    .OrderBy(value=>value)
                    .ToList();

            cmbInstance.DataSource = data.Count > 0 ? data : null;
        }
    }
}
