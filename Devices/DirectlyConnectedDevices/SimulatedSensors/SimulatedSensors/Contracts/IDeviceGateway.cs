using System;
using System.Diagnostics.Contracts;
using Microsoft.Azure.Devices.Client;

namespace SimulatedSensors.Contracts
{
    interface IDeviceGateway
    {
       bool Connect(string connectionString);

        bool Disconnect();
      
        void EnqueMessage(Message msg);
    }
}