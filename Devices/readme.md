# Device setup  #
The basic premise of this project is that data from sensing devices can be sent upstream and received in a prescribed JSON format. This might be achieved by programming the devices themselves (e.g. compiling and uploading a Wiring script to an Arduino UNO), or by reading the data from the device and formatting it accordingly (e.g. using a Python script on a Raspberry Pi to read USB output from a commercial Sound Level Meter). 

## Creating devices IDs for Azure IoT Hub ##
The ConnecttheDots project uses Azure IoT Hub to connect devices to the Cloud.
When [deploying the full solution using the ARM template](../Azure/ARMTemplate/Readme.md) an Azure IoT Hub is deployed as part of your solution.

You can find connection information for managing the IoT Hub instance in the [Azure portal](http://portal.azure.com). Search for the Resource Group with the name you used for the solution when deploying the services using the script.
For each of the devices that you want to connect to your ConnectTheDots solution, you will need to create a new device ID.
You will find all the instructions to create device IDs and retrieve connection strings [here](https://github.com/Azure/azure-iot-sdks/blob/master/doc/manage_iot_hub.md).

## Getting started project using Windows Device Simulator ##
This simulator mimics real devices output and sends data to the IoTHub. To start working with it, just get the latest sources and build SimulatedSensors project. Main thing that needs to be set is IoTHub connection string.

![](http://content.screencast.com/users/Asperwin/folders/Jing/media/2663da14-b4ab-408e-8a19-cf54ec921746/2017-01-08_2334.png)

In addition to the IoTHub connection string user may enter Connection string to the DB where telemetry data will be saved. This can be done via application configuration file or using corresponding textbox on the UI. 
When Get IoTHub Devices button is pressed application will connect to the IoTHub and download list of devices associated with it. User has to select one of them. Application will perform persistent connection to the selected device.

If DB connection string is set, the rest of drop down lists will be filled with values expected by the system, otherwise user will need to type them manually. When "Send Data" button is pressed simulator starts to send 2 messages per second to the IoTHub. Sample of the sent message:
*`[{"GatewayName":"RedWestIoTGateway","Timestamp":"2017-01-08T21:51:34.9279678Z","Asset":{"DeviceName":"7810","ObjectType_Instance":"A_01","PresentValue":46.4}}]`*

Trackbar position defines value from 1 to 100, to add some 10% variation appropriate checkbox needs to be checked.
Trackbar value can be modified even when connection is already established and data are sending to the Hub.
 


## ConnectTheDots getting started project using Raspberry Pi and Arduino ##
For this project, follow the instructions for configuring the following:

1. [Arduino UNO with weather shield](GatewayConnectedDevices/Arduino%20UNO/Weather/WeatherShieldJson/Arduino-and-Weather-Shield-setup.md) 
2. [Raspberry Pi](Gateways/GatewayService/RaspberryPi-Gateway-setup.md) 

## Connect The Dots with all the other devices ##

To build your own end-to-end configuration you need to identify and configure the device(s) that will be producing the data to be pushed to Azure and displayed/analyzed. Devices fall generally into two categories - those that can connect directly to the Internet, and those that need to connect to the Internet through some intermediate device or gateway. Sample code and documentation can be found in the following folders:

1. [Simple devices requiring a gateway](GatewayConnectedDevices/) - Devices too small or basic to support a secure IP connection, or which need to be aggregated before sending to Azure
2. [Devices connecting directly to Azure](DirectlyConnectedDevices/) - Devices powerful enough to support a secure IP connection
3. [Gateways or other intermediary devices](Gateways/) - Devices which collect data from other devices and upload to Azure. These can be very simple (e.g. just package and send the data securely to Azure without changes), or very sophisticated (e.g. allow for device authentication, provisioning, management, and communications). 


### Build a sensor infrastructure ###
For additional scenarios, or more advanced configurations, follow the setup instructions in the folders for the devices or gateways listed above.