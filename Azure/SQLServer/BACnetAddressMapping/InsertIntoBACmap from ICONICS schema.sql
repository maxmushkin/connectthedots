insert into BACmap
(
	[GatewayName]
      ,[DeviceName]
      ,[ObjectType]
      ,[Instance]
      ,[Region]
      ,[Campus]
      ,[Building]
      ,[Floor]
      ,[Unit]
	  ,[EquipmentClass]
      ,[TagName]
)
select
	'B19Gateway'
      ,[DeviceID]
	  , case [ObjectType]
		when 'AnalogInput' then 'AI'
		when 'AnalogOutput' then 'AO'
		when 'AnalogValue' then 'AV'
		when 'BinaryInput' then 'BI'
		when 'BinaryOutput' then 'BO'
		when 'BinaryValue' then 'BV'
		else 'Other'
		end

      ,[ObjectID]
      ,[Region]
      ,[Campus]
      ,[Building]
      ,[Floor]
      ,[Unit]
      ,[Equipment]
      ,[TagName]
from
TrevorB19BACnetMapping