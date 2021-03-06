# Get-SFApplicationType
Gets the list of application types in the Service Fabric cluster.
## Description

Returns the information about the application types that are provisioned or in the process of being provisioned in the 
Service Fabric cluster. Each version of an application type is returned as one application type. The response includes 
the name, version, status, and other details about the application type. This is a paged query, meaning that if not 
all of the application types fit in a page, one page of results is returned as well as a continuation token, which can 
be used to get the next page. For example, if there are 10 application types but a page only fits the first three 
application types, or if max results is set to 3, then three is returned. To access the rest of the results, retrieve 
subsequent pages by using the returned continuation token in the next query. An empty continuation token is returned 
if there are no subsequent pages.



## Optional Parameters
#### -ApplicationTypeDefinitionKindFilter

Used to filter on ApplicationTypeDefinitionKind which is the mechanism used to define a Service Fabric application 
type.
                    - Default - Default value, which performs the same function as selecting "All". The value is 0.
                    - All - Filter that matches input with any ApplicationTypeDefinitionKind value. The value is 65535.
                    - ServiceFabricApplicationPackage - Filter that matches input with ApplicationTypeDefinitionKind 
value ServiceFabricApplicationPackage. The value is 1.
                    - Compose - Filter that matches input with ApplicationTypeDefinitionKind value Compose. The value 
is 2.



#### -ExcludeApplicationParameters

The flag that specifies whether application parameters will be excluded from the result.



#### -MaxResults

The maximum number of results to be returned as part of the paged queries. This parameter defines the upper bound on 
the number of results returned. The results returned can be less than the specified maximum results if they do not fit 
in the message as per the max message size restrictions defined in the configuration. If this parameter is zero or not 
specified, the paged query includes as many results as possible that fit in the return message.



#### -ServerTimeout

The server timeout for performing the operation in seconds. This timeout specifies the time duration that the client 
is willing to wait for the requested operation to complete. The default value for this parameter is 60 seconds.



#### -ApplicationTypeVersion

The version of the application type.



#### -ContinuationToken

The continuation token to obtain next set of results



