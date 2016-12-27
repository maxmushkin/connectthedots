using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SimulatedSensors.Contracts;

namespace SimulatedSensors
{
    public class DeviceSimulator : IDeviceEmulator
    {
        public bool SendingData { get; private set; }
        private Dictionary<string, Asset> Assets = new Dictionary<string, Asset>();
        private DeviceGateway _deviceGateway = new DeviceGateway();
        public int SendTelemetryFreq { get; set; } = 500;
        public bool Connected => _deviceGateway.Connected;

        // Event Handler for notifying the sent message state to the IoT Hub
        public event EventHandler SentMessageEventHandler;

        // Event Handler for notifying the reception of a new message from IoT Hub
        public event EventHandler ReceivedMessageEventHandler;

        public bool Pause()
        {
            return SendingData = false;
        }

        public bool Resume()
        {
            if (_deviceGateway.Connected)
            {
                return SendingData = true;
            }
            return false;
        }

        public void UpdateAsset(Asset asset)
        {
            if (Assets.ContainsKey(asset.GatewayId + asset.DeviceId))
            {
                Assets[asset.GatewayId + asset.DeviceId] = asset;
            }
            else
            {
                Assets.Add(asset.GatewayId + asset.DeviceId, asset);
            }
        }

        public bool DeleteAsset(Asset asset)
        {
            if (Assets.ContainsKey(asset.GatewayId + asset.DeviceId))
            {
                Assets.Remove(asset.GatewayId + asset.DeviceId);
                return true;
            }
            return false;
        }

        public bool Connect(string connectionString)
        {
            if (_deviceGateway.Connect(connectionString))
                SendMessages();
            return Connected;
        }

        public bool Disconnect()
        {
            return _deviceGateway.Disconnect();
        }

        public void EnqueMessage(Message msg)
        {
            _deviceGateway.EnqueMessage(msg);
        }

        private async void SendMessages()
        {
            Random rnd = new Random(1234432);
            while (Connected)
            {
                if (SendingData)
                    foreach (var asset in Assets.Values)
                    {
                        try
                        {
                            var d2hMessage = new D2HMessage(asset);
                            //if (d2hMessage.Asset.Value > 30 || d2hMessage.Asset.Value < 16)
                            //    d2hMessage.Asset.Value = 22;
                            d2hMessage.Asset.Value = d2hMessage.Asset.Value + rnd.Next(-10, 11) / 10.0;
                            var messages = new D2HMessage[] { d2hMessage };

                            var msg = new Message(Serialize(messages));
                            if (_deviceGateway.Connected)
                            {
                                EnqueMessage(msg);
                                var logmsg = "Sent telemetry data to IoT Hub\n";

                                SentMessageEventHandler?.Invoke(this, new ReceivedMessageEventArgs(
                                    new C2DMessage()
                                    {
                                        message = logmsg,
                                        value = d2hMessage.Asset.Value,
                                        alerttype = "sent",
                                        timecreated = d2hMessage.Timestamp.Substring(0, 19),
                                        unitofmeasure = d2hMessage.Asset.ObjectTypeInstance
                                    }));
                                Debug.WriteLine(logmsg);
                            }
                            else Debug.WriteLine("Connection To IoT Hub is not established. Cannot send message now");

                        }
                        catch (System.Exception e)
                        {
                            Debug.WriteLine("Exception while sending device telemetry data :\n" + e.Message.ToString(), "DE");
                        }
                    }
                await Task.Delay(SendTelemetryFreq);
            }
        }

        /// <summary>
        /// Serialize message
        /// </summary>
        private byte[] Serialize(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(json);

        }
    }
}