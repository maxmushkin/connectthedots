update bacmap
set ObjectType = replace(ObjectType, 'AnalogInput', 'AI')
update bacmap
set ObjectType = replace(ObjectType, 'AnalogValue', 'AV')
select * from bacmap where gatewayname like '%power%' order by objecttype