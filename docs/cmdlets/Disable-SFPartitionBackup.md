# Disable-SFPartitionBackup
Disables periodic backup of Service Fabric partition which was previously enabled.
## Description

Disables periodic backup of partition which was previously enabled. Backup must be explicitly enabled before it can be 
disabled. 
                In case the backup is enabled for the Service Fabric application or service, which this partition is 
part of, this partition would continue to be periodically backed up as per the policy mapped at the higher level 
entity.



## Required Parameters
#### -PartitionId

The identity of the partition.



#### -CleanBackup

Boolean flag to delete backups. It can be set to true for deleting all the backups which were created for the backup 
entity that is getting disabled for backup.



