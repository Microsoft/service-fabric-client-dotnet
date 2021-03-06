# Get-SFPropertyInfoList
Gets information on all Service Fabric properties under a given name.
## Description

A Service Fabric name can have one or more named properties that store custom information. This operation gets the 
information about these properties in a paged list. The information includes name, value, and metadata about each of 
the properties.



## Optional Parameters
#### -IncludeValues

Allows specifying whether to include the values of the properties returned. True if values should be returned with the 
metadata; False to return only property metadata.



#### -ServerTimeout

The server timeout for performing the operation in seconds. This timeout specifies the time duration that the client 
is willing to wait for the requested operation to complete. The default value for this parameter is 60 seconds.



