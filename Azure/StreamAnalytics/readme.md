# Stream Analytics setup #
The instructions below will help you setup the Stream Analytics queries in the Smart Buildings project in the Azure portal. This document assumes that the Azure IoT Hub and incoming JSON data conforms with that specified in  the Smart Building project.

## Prerequisites ##

These queries are hard-coded to the data streams defined in the getting started walkthrough in this project, meaning the same JSON string contents, etc. Also note that the SQL queries ARE CASE SENSITIVE, so that "temperature" <> "TEMPERATURE". You should make sure that the spelling and case of the incoming measure names are the same as in the SQL queries.

## Create Azure Stream Analytics (ASA) jobs ##

* If you have used the ARM template to deploy the Smart Building solution, then you can edit the Stream Analytics job directly in the portal, in the Resource Group created during the deployment of the solution.
* If you are creating a new job, read this:
    * Open the [Azure Management Portal](http://portal.azure.com), and create a new job “LogAllEvents”:
        * "+” in top left corner > `Internet Of Thing`s > `Stream Analytics job` >
            * `Job name`: `LogAllEvents`.
            * `Subscription`: same as the one used for the other parts of the solution.
            * `Resource Group`: same as the one used for the other parts of the solution.
            * `Location`: your choice, considering it is always better to have the various services of a solution in the same region.
            * Click on `Create`
    * In the `Resource Groups` list, select your solution's resource group.
    * Select the stream analytics job `LogAllEvents`
    * Create two inputs
        * Click on the `Inputs` tile in the `Job Topology` section
        * *Inputs blade > `Add` >*
            * `Input Alias`: `SBHubv2`
            * `Source Type`: `Data Stream`
            * `Source`: `IoT Hub`
            * `Subscription`: `Use IoT hub from current subscription`
            * `IoTHub`: pick the IoT Hub name of your solution
            * `Endpoint`: `Messaging`
            * `Shared access policy name`: `iothubowner`
            * `Consumer group`: `$Default`
            * `Event serialization format`: `JSON`
            * `Encoding`: `UTF-8`
            * Click on `Create`
        * *Inputs blade > `Add` >*
	        * `Input Alias`: `BACmap`
	        * `Source Type`: `Reference data`
            * `Subscription`: `Use blob storage from current subscription`
            * `Storage account`: `tr24smartbuilding`
            * `Container`: `refdata`
            * `Path pattern`: `bacmap/{date}/{time}/BACmap.csv`
            * `Date format`: `YYYY\MM\DD`
            * `Time format`: `HH`
            * `Event serialization format`: `CSV`
            * `Delimiter`: `comma(,)`
            * `Encoding`: `UTF-8`
            * Click on `Create`
	* Create a query 
        * Click on the `Query` tile in the `Job Topology` section
        * Copy/paste contents `LogAllEvents.sql` found in the `ConnectTheDots\Azure\StreamAnalytics` folder in Windows Explorer
        * Click on `Save`   
    * Create two outputs
        * Select the `Outputs` tile in the `Job Topology` section
        * *`Outputs` blade > `Add` >*
            * `Output Alias`: `EventHistorian`
            * `Sink`: `SQL database`
            * `Subscription`: `Use SQL database from current subscription`
            * `Database`: your choice
            * `Username`: DB user name
            * `Password`: DB user password
            * `Table`: `EventHistorian`
            * Click on `Create`
        * *`Outputs` blade > `Add` >*
            * `Output Alias`: `MissingBACmapEntries`
            * `Sink`: `SQL database`
            * `Subscription`: `Use SQL database from current subscription`
            * `Database`: your choice
            * `Username`: DB user name
            * `Password`: DB user password
            * `Table`: `MissingBACmapEntries`
            * Click on `Create`
    * Start the Job
        * *LogAllEvents blade > `Start`* on the top bar.
        * `Job output start time`: `Now`
        * Click on `Start`
