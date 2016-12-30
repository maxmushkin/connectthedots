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
        Random rnd = new Random();
        
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
                Assets.Clear(); // ToDo: remove when UI will allow multiple sensors at the same time
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
            while (Connected)
            {
                if (SendingData)
                    foreach (var asset in Assets.Values)
                    {
                        try
                        {
                            var d2hMessage = new D2HMessage(asset);
                            double variation = 0.0;
                            if (d2hMessage.Asset.Variation)
                            {
                                variation = rnd.Next(-10, 11)/10.0;
                                d2hMessage.Asset.Value = d2hMessage.Asset.Value + variation;
                            }
                            
                            var messages = new D2HMessage[] { d2hMessage };
                            var demoMessage = JsonConvert.SerializeObject(messages);
                            var msg = new Message(Serialize(messages));

                            d2hMessage.Asset.Value = d2hMessage.Asset.Value - variation;

                            if (_deviceGateway.Connected)
                            {
                                EnqueMessage(msg);
                                var logmsg = "Sent telemetry data to IoT Hub\n";

                                SentMessageEventHandler?.Invoke(this, new ReceivedMessageEventArgs(
                                    new C2DMessage()
                                    {
                                        message = demoMessage,
                                        alerttype = "sent"
                                    }));
                                Debug.WriteLine(logmsg);
                            }
                            else Debug.WriteLine("Connection To IoT Hub is not established. Cannot send message now");

                        }
                        catch (System.Exception e)
                        {
                            Debug.WriteLine("Exception while sending device telemetry data :\n" + e.Message.ToString(), "DE");
                            SentMessageEventHandler?.Invoke(this, new ReceivedMessageEventArgs(
                                   new C2DMessage()
                                   {
                                       message = "Exception while sending device telemetry data :\n" + e.Message.ToString(),
                                       alerttype = "Error"
                                   }));
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