# BACnetAddressMapping SQL Queries #
The SQL files in this folder are as follows 

1. **dbo.BACmap.Table.sql** Creates dbo.BACmap, the SQL table for storing the data that the LogAllEvents Stream Analytics job uses to lookup incoming BACnet data. 
2. **InsertValuesIntoBACmap.sql** Inserts values (records) into dbo.BACmap
3. **InsertValuesIntoBACmap.sql** Inserts records into dbo.BACmap from a SQL table output from Iconics
4. **InsertValuesIntoBACmap.sql** Lists records in dbo.BACmap
5. **InsertValuesIntoBACmap.sql** Replaces fields in dbo.BACmap if needed to edit records

Note - since Azure Stream Analytics cannot join a SQL table, the records in dbo.BACmap have to be exported to a .CSV format blob in Azure for ASA to access. That part 
of the workflow is covered by the pipeline discussed in the AzureDataFactory folder of this project.

## Prerequisites ##
Workflow as described in the project readme.md.


