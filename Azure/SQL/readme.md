# SQL Queries #
The folders in the SQL director contain SQL queries that peform functions necessary to move and store data from the IoT Hub in the Smart Buildings PCS. Readme.md files in 
each of the subdirectories explain the functions. The workflow proceeds in the following order:

1. BACmapAdressProcessing
2. EventHistorian
3. EventProcessing
4. FaultProcessing

## Prerequisites ##
SQL Database

## Create Azure SQL Database ##
* Open the Azure Management Portal, and create a new SQL Database `WO_Procs`: `+` in top left corner > `Databases` > `SQL Database` >
	* `Database name`: `WO_Procs`.
	* `Subscription`: same as the one used for the other parts of the solution.
	* `Resource Group`: same as the one used for the other parts of the solution.
	* `Select source`: Blank database
	* `Server`: Create new server
		* `Server name`: The name of your choice, must be unique within Azure SQL Server names
		* `Server admin login`: `WO_Admin`
		* `Password`: The password used to connect to the server, make sure you're using secure enough password
		* `Password confirmation`: Type password one more time
		* `Location`: your choice, considering it is always better to have the various services of a solution in the same region.
		* `Create V12 server (Latest update)`: `Yes`
		* `Allow azure services to access server`: `Yes`
		* Click on `Create`
	* Want to use `SQL elastic pool?`: `Not now`
	* `Pricing tier`: `S2 Standard`
	* `Collation`: `SQL_Latin1_General_CP1_CI_AS` (default)
	* Click on `Create`




