# Resolve-SFService
Resolve a Service Fabric partition.
## Description

Resolve a Service Fabric service partition to get the endpoints of the service replicas.



## Optional Parameters
#### -PartitionKeyType

Key type for the partition. This parameter is required if the partition scheme for the service is Int64Range or Named. 
The possible values are following.
                    - None (1) - Indicates that the PartitionKeyValue parameter is not specified. This is valid for 
the partitions with partitioning scheme as Singleton. This is the default value. The value is 1.
                    - Int64Range (2) - Indicates that the PartitionKeyValue parameter is an int64 partition key. This 
is valid for the partitions with partitioning scheme as Int64Range. The value is 2.
                    - Named (3) - Indicates that the PartitionKeyValue parameter is a name of the partition. This is 
valid for the partitions with partitioning scheme as Named. The value is 3.



#### -PartitionKeyValue

Partition key. This is required if the partition scheme for the service is Int64Range or Named. 
                    This is not the partition ID, but rather, either the integer key value, or the name of the 
partition ID.
                    For example, if your service is using ranged partitions from 0 to 10, then they PartitionKeyValue 
would be an
                    integer in that range. Query service description to see the range or name.



#### -PreviousRspVersion

The value in the Version field of the response that was received previously. This is required if the user knows that 
the result that was gotten previously is stale.



#### -ServerTimeout

The server timeout for performing the operation in seconds. This timeout specifies the time duration that the client 
is willing to wait for the requested operation to complete. The default value for this parameter is 60 seconds.



