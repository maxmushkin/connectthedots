using System;
using System.Text;
using System.Diagnostics;
using System.Linq;
using ConnectTheDotsHelper;
using SimulatedSensors.Helpers;

namespace SimulatedSensors
{
    public class MyClass:ConnectTheDots
    {
        public MyClass(string deviceId)
        {
            this.DeviceId = Settings.DisplayName;
            this.ConnectionString = Settings.ConnectionString;
            
            this.AddSensor(deviceId);
        }

        public bool checkConfig()
        {
            if (((this.DeviceId != null) && (this.ConnectionString != null) &&
                        (this.DeviceId != "") && (this.ConnectionString != "")))
            {
                Settings.DisplayName = this.DeviceId;
                Settings.ConnectionString = this.ConnectionString;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateSensorData(string SensorName, double value)
        {
            //if (this.Sensors.ContainsKey(SensorName))
            //    this.Sensors[SensorName].value = value;
            foreach (var sensor in Sensors)
            {
                sensor.Value.value = value;
            }
        }
    }
}

