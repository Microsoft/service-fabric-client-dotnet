# Repair-SFServicePartitions
Indicates to the Service Fabric cluster that it should attempt to recover the specified service that is currently stuck in quorum loss.
## Description

Indicates to the Service Fabric cluster that it should attempt to recover the specified service that is currently 
stuck in quorum loss. This operation should only be performed if it is known that the replicas that are down cannot be 
recovered. Incorrect use of this API can cause potential data loss.



