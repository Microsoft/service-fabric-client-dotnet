# Get-SFQuorumLossProgress
Gets the progress of a quorum loss operation on a partition started using the StartQuorumLoss API.
## Description

Gets the progress of a quorum loss operation started with StartQuorumLoss, using the provided OperationId.



## Required Parameters
#### -ServiceId

The identity of the service. This ID is typically the full name of the service without the 'fabric:' URI scheme.
                    Starting from version 6.0, hierarchical names are delimited with the "~" character.
                    For example, if the service name is "fabric:/myapp/app1/svc1", the service identity would be 
"myapp~app1~svc1" in 6.0+ and "myapp/app1/svc1" in previous versions.



#### -PartitionId

The identity of the partition.



#### -OperationId

A GUID that identifies a call of this API.  This is passed into the corresponding GetProgress API



