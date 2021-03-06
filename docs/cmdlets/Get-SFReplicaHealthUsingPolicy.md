# Get-SFReplicaHealthUsingPolicy
Gets the health of a Service Fabric stateful service replica or stateless service instance using the specified policy.
## Description

Gets the health of a Service Fabric stateful service replica or stateless service instance.
                Use EventsHealthStateFilter to filter the collection of health events reported on the cluster based on 
the health state.
                Use ApplicationHealthPolicy to optionally override the health policies used to evaluate the health. 
This API only uses 'ConsiderWarningAsError' field of the ApplicationHealthPolicy. The rest of the fields are ignored 
while evaluating the health of the replica.



## Required Parameters
#### -PartitionId

The identity of the partition.



#### -ReplicaId

The identifier of the replica.



## Optional Parameters
#### -EventsHealthStateFilter

Allows filtering the collection of HealthEvent objects returned based on health state.
                    The possible values for this parameter include integer value of one of the following health states.
                    Only events that match the filter are returned. All events are used to evaluate the aggregated 
health state.
                    If not specified, all entries are returned. The state values are flag-based enumeration, so the 
value could be a combination of these values, obtained using the bitwise 'OR' operator. For example, If the provided 
value is 6 then all of the events with HealthState value of OK (2) and Warning (4) are returned.
                    
                    - Default - Default value. Matches any HealthState. The value is zero.
                    - None - Filter that doesn't match any HealthState value. Used in order to return no results on a 
given collection of states. The value is 1.
                    - Ok - Filter that matches input with HealthState value Ok. The value is 2.
                    - Warning - Filter that matches input with HealthState value Warning. The value is 4.
                    - Error - Filter that matches input with HealthState value Error. The value is 8.
                    - All - Filter that matches input with any HealthState value. The value is 65535.



#### -ConsiderWarningAsError

Indicates whether warnings are treated with the same severity as errors.



#### -MaxPercentUnhealthyDeployedApplications

The maximum allowed percentage of unhealthy deployed applications. Allowed values are Byte values from zero to 100.
                    The percentage represents the maximum tolerated percentage of deployed applications that can be 
unhealthy before the application is considered in error.
                    This is calculated by dividing the number of unhealthy deployed applications over the number of 
nodes where the application is currently deployed on in the cluster.
                    The computation rounds up to tolerate one failure on small numbers of nodes. Default percentage is 
zero.



#### -MaxPercentUnhealthyPartitionsPerService

The maximum allowed percentage of unhealthy partitions per service. Allowed values are Byte values from zero to 100
                    
                    The percentage represents the maximum tolerated percentage of partitions that can be unhealthy 
before the service is considered in error.
                    If the percentage is respected but there is at least one unhealthy partition, the health is 
evaluated as Warning.
                    The percentage is calculated by dividing the number of unhealthy partitions over the total number 
of partitions in the service.
                    The computation rounds up to tolerate one failure on small numbers of partitions. Default 
percentage is zero.



#### -MaxPercentUnhealthyReplicasPerPartition

The maximum allowed percentage of unhealthy replicas per partition. Allowed values are Byte values from zero to 100.
                    
                    The percentage represents the maximum tolerated percentage of replicas that can be unhealthy 
before the partition is considered in error.
                    If the percentage is respected but there is at least one unhealthy replica, the health is 
evaluated as Warning.
                    The percentage is calculated by dividing the number of unhealthy replicas over the total number of 
replicas in the partition.
                    The computation rounds up to tolerate one failure on small numbers of replicas. Default percentage 
is zero.



#### -MaxPercentUnhealthyServices

The maximum maximum allowed percentage of unhealthy services. Allowed values are Byte values from zero to 100.
                    
                    The percentage represents the maximum tolerated percentage of services that can be unhealthy 
before the application is considered in error.
                    If the percentage is respected but there is at least one unhealthy service, the health is 
evaluated as Warning.
                    This is calculated by dividing the number of unhealthy services of the specific service type over 
the total number of services of the specific service type.
                    The computation rounds up to tolerate one failure on small numbers of services. Default percentage 
is zero.



#### -ServiceTypeHealthPolicyMap

The map with service type health policy per service type name. The map is empty by default.



#### -ServerTimeout

The server timeout for performing the operation in seconds. This timeout specifies the time duration that the client 
is willing to wait for the requested operation to complete. The default value for this parameter is 60 seconds.



