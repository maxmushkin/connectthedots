# Stream Analytics setup #
The instructions below will help you setup the Stream Analytics queries in the Smart Buildings project in the Azure portal. This document assumes that the Azure IoT Hub and incoming JSON data conforms with that specified in  the Smart Building project.

## Prerequisites ##

These queries are hard-coded to the data streams defined in the getting started walkthrough in this project, meaning the same JSON string contents, etc. Also note that the SQL queries ARE CASE SENSITIVE, so that "temperature" <> "TEMPERATURE". You should make sure that the spelling and case of the incoming measure names are the same as in the SQL queries.

## Create Azure Stream Analytics (ASA) jobs ##

* If you have used the ARM template to deploy the Smart Building solution, then you can edit the Stream Analytics job directly in the portal, in the Resource Group created during the deployment of the solution.
* If you are creating a new job, read this:
    * Open the [Azure Management Portal](http://portal.azure.com), and create a new job “Log All Events”:
        * "+” in top left corner > Internet Of Things > Stream Analytics >
            * Job name: “Log All Events”.
            * Subscription: same as the one used for the other parts of the solution.
            * Resource Group: same as the one used for the other parts of the solution.
            * Location: your choice, considering it is always better to have the various services of a solution in the same region.
            * Click on Create
    * Create two inputs
        * In the Resource Groups list, select your solution's resource group.
        * Select the stream analytics job "Log All Events"
        * Click on the Inputs tile in the Aggregates job.
        * *Inputs blade > Add >*
            * Input Alias: “SBHubv2”
            * Source Type: "Data Stream"
            * Source: "IoT Hub"
            * Subscription: pick the current subscription
            * IoTHub: pick the IoT Hub name of your solution
            * Shared access policy name: "iothubowner"
            * Event serialization format: "JSON"
            * Encoding: "UTF-8"
			
# CONTINUE EDITING FROM HERE (SPYROS NOTE #)			
			
    * Create a query 
        * Select the Query tile in the Aggregates job blade
        * Copy/paste contents `Aggregates.sql` found in the `ConnectTheDots\Azure\StreamAnalyticsQueries` folder in Windows Explorer
        * Save
    * Create an output
        * Select the Output tile in the Aggregates job blade
        * *Output tile > Add >*
            * Output Alias: your choice
            * Sink: "Event Hub"
            * Subscription: pick the current subscription
            * Service bus namespace: Pick the one named after the solution name you entered during the deployment of the ARM template
            * Event Hub Name: "ehalerts"
            * Event Hub policy name: "RootManageSharedAccessKey"
            * Event Serialization format: "JSON"
            * Encoding: "UTF-8"
            * Click on Create
        * **Note** You will likely get an error just about the same container being used as input and output. This is OK, the job will still work.

    * Start the Job
        * *Dashboard > Start* on the bottom bar.
