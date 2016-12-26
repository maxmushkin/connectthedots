using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using SimulatedSensors.Contracts;
using IotHubConnectionStringBuilder = Microsoft.Azure.Devices.Client.IotHubConnectionStringBuilder;

namespace SimulatedSensors
{
    public class HubGateway
    {
        private const int MAX_COUNT_OF_DEVICES = 1000;
        public async Task<List<DeviceEntity>> GetDevices(string connectionString)
        {
            try
            {
                var devicesProcessor = new DevicesProcessor(connectionString, MAX_COUNT_OF_DEVICES, string.Empty);
                var results = await devicesProcessor.GetDevices();
                return results;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid IoTHub connection string. " + ex.Message);
            }
        }

        private string SanitizeConnectionString(string connectionString)
        {
            // Does the following:
            //  - trim leading/trailing white space from the connection string
            //  - scan and remove CR and LF characters
            return connectionString.Trim().Replace("\r", "").Replace("\n", "");
        }

        private IotHubConnectionStringBuilder ParseIoTHubConnectionString(string connectionString, bool skipException = false)
        {
            try
            {
                var builder = IotHubConnectionStringBuilder.Create(connectionString);

                //string iotHubName = builder.HostName.Split('.')[0];
                return builder;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid IoTHub connection string. " + ex.Message);
            }
        }
    }
}