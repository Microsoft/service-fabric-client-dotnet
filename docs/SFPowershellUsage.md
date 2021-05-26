# Microsoft.ServiceFabric.Powershell.Http Powershell Module
The new Service Fabric Powershell module works over HTTP with the service Fabric HTTP Gateway. The module can be used with following:
- [Powershell Core](https://github.com/powershell/powershell) on Windows, Linux and MacOS.
 For a full list of systems supported by PowerShell Core see [Installing Powershell Core](https://docs.microsoft.com/en-us/powershell/scripting/setup/installing-powershell?view=powershell-6)
- [Windows Powershell](https://docs.microsoft.com/en-us/powershell/scripting/setup/installing-windows-powershell?view=powershell-6)

## Getting the module
The module is available in Powershell Gallery, for more information on downloading packages from Powershell Gallery, please see [Downloading packages from the PowerShell Gallery](https://docs.microsoft.com/en-us/powershell/scripting/gallery/getting-started#downloading-packages-from-the-powershell-gallery).

### Powershell Core
Service Fabric REST Powershell module is available in Powershell Gallery and can be installed as
```PowerShell
Install-Module -Name Microsoft.ServiceFabric.Powershell.Http -AllowPrerelease
Import-Module -Name Microsoft.ServiceFabric.Powershell.Http
```
### Windows Powershell
Service Fabric REST Powershell module is available in Powershell Gallery and can be installed as
```PowerShell
Install-Module -Name Microsoft.ServiceFabric.Powershell.Http -AllowPrerelease
```
Note: You might have to update the PowerShellGet module (if its version is less than 1.6.0) to get support for [-AllowPrerelease flag](https://blogs.msdn.microsoft.com/powershell/2017/12/05/prerelease-versioning-added-to-powershellget-and-powershell-gallery/). It can be updated as:
```PowerShell
Install-Module -Name PowerShellGet -Force
```
## PS Module and Service Fabric Runtime Compatibility
Module Version | Compatible Service Fabric Runtime version
-|-
1.4.4-preview* | >= 8.0.*
1.4.2-preview* | >= 7.2.*
1.4.1-preview* | >= 7.1.*
1.4.0-preview* | >= 7.0.*
1.0.3-preview* | >= 6.4.*

## Connecting to Cluster
### Connecting to unsecured cluster
```PowerShell
Connect-SFCluster -ConnectionEndpoint http://<cluster_fqdn>:<httgateway_port>
```

### Connecting to cluster secured with X509 certificate and Azure Active Directory
Please see [Connect-SFCluster](cmdlets/Connect-SFCluster.md) cmdlet for information on how to connect to a secured cluster.

## Commands
Following is the list of commands available in this module:

Command | Summary
-|-
[Add-SFMeshSecretValue](cmdlets/Add-SFMeshSecretValue.md)|Adds the specified value as a new version of the specified secret resource.
[Backup-SFPartition](cmdlets/Backup-SFPartition.md)|Triggers backup of the partition's state.
[Connect-SFCluster](cmdlets/Connect-SFCluster.md)|Cmdlet to connect to Service Fabric cluster.
[Copy-SFApplicationPackage](cmdlets/Copy-SFApplicationPackage.md)|Uploads application package to image store.
[Copy-SFImageStoreContent](cmdlets/Copy-SFImageStoreContent.md)|Copies image store content internally
[Copy-SFServicePackageToNode](cmdlets/Copy-SFServicePackageToNode.md)|Downloads all of the code packages associated with specified service manifest on the specified node.
[Disable-SFApplicationBackup](cmdlets/Disable-SFApplicationBackup.md)|Disables periodic backup of Service Fabric application.
[Disable-SFNode](cmdlets/Disable-SFNode.md)|Deactivate a Service Fabric cluster node with the specified deactivation intent.
[Disable-SFPartitionBackup](cmdlets/Disable-SFPartitionBackup.md)|Disables periodic backup of Service Fabric partition which was previously enabled.
[Disable-SFServiceBackup](cmdlets/Disable-SFServiceBackup.md)|Disables periodic backup of Service Fabric service which was previously enabled.
[Enable-SFApplicationBackup](cmdlets/Enable-SFApplicationBackup.md)|Enables periodic backup of stateful partitions under this Service Fabric application.
[Enable-SFNode](cmdlets/Enable-SFNode.md)|Activate a Service Fabric cluster node that is currently deactivated.
[Enable-SFPartitionBackup](cmdlets/Enable-SFPartitionBackup.md)|Enables periodic backup of the stateful persisted partition.
[Enable-SFServiceBackup](cmdlets/Enable-SFServiceBackup.md)|Enables periodic backup of stateful partitions under this Service Fabric service.
[Get-SFAadMetadata](cmdlets/Get-SFAadMetadata.md)|Gets the Azure Active Directory metadata used for secured connection to cluster.
[Get-SFAllEntitiesBackedUpByPolicy](cmdlets/Get-SFAllEntitiesBackedUpByPolicy.md)|Gets the list of backup entities that are associated with this policy.
[Get-SFApplication](cmdlets/Get-SFApplication.md)|Gets the list of applications created in the Service Fabric cluster that match the specified filters.
[Get-SFApplicationBackupConfigurationInfo](cmdlets/Get-SFApplicationBackupConfigurationInfo.md)|Gets the Service Fabric application backup configuration information.
[Get-SFApplicationBackupList](cmdlets/Get-SFApplicationBackupList.md)|Gets the list of backups available for every partition in this application.
[Get-SFApplicationHealth](cmdlets/Get-SFApplicationHealth.md)|Gets the health of the service fabric application.
[Get-SFApplicationHealthUsingPolicy](cmdlets/Get-SFApplicationHealthUsingPolicy.md)|Gets the health of a Service Fabric application using the specified policy.
[Get-SFApplicationLoadInfo](cmdlets/Get-SFApplicationLoadInfo.md)|Gets load information about a Service Fabric application.
[Get-SFApplicationManifest](cmdlets/Get-SFApplicationManifest.md)|Gets the manifest describing an application type.
[Get-SFApplicationNameInfo](cmdlets/Get-SFApplicationNameInfo.md)|Gets the name of the Service Fabric application for a service.
[Get-SFApplicationsEvent](cmdlets/Get-SFApplicationsEvent.md)|Gets all Applications-related events.
[Get-SFApplicationType](cmdlets/Get-SFApplicationType.md)|Gets the list of application types in the Service Fabric cluster.
[Get-SFApplicationUpgrade](cmdlets/Get-SFApplicationUpgrade.md)|Gets details for the latest upgrade performed on this application.
[Get-SFBackupPolicy](cmdlets/Get-SFBackupPolicy.md)|Gets all the backup policies configured.
[Get-SFBackupsFromBackupLocation](cmdlets/Get-SFBackupsFromBackupLocation.md)|Gets the list of backups available for the specified backed up entity at the specified backup location.
[Get-SFChaos](cmdlets/Get-SFChaos.md)|Get the status of Chaos.
[Get-SFChaosEvents](cmdlets/Get-SFChaosEvents.md)|Gets the next segment of the Chaos events based on the continuation token or the time range.
[Get-SFChaosSchedule](cmdlets/Get-SFChaosSchedule.md)|Get the Chaos Schedule defining when and how to run Chaos.
[Get-SFClusterConfiguration](cmdlets/Get-SFClusterConfiguration.md)|Get the Service Fabric standalone cluster configuration.
[Get-SFClusterConfigurationUpgradeStatus](cmdlets/Get-SFClusterConfigurationUpgradeStatus.md)|Get the cluster configuration upgrade status of a Service Fabric standalone cluster.
[Get-SFClusterEventList](cmdlets/Get-SFClusterEventList.md)|Gets all Cluster-related events.
[Get-SFClusterHealth](cmdlets/Get-SFClusterHealth.md)|Gets the health of a Service Fabric cluster.
[Get-SFClusterHealthChunk](cmdlets/Get-SFClusterHealthChunk.md)|Gets the health of a Service Fabric cluster using health chunks.
[Get-SFClusterHealthChunkUsingPolicyAndAdvancedFilters](cmdlets/Get-SFClusterHealthChunkUsingPolicyAndAdvancedFilters.md)|Gets the health of a Service Fabric cluster using health chunks.
[Get-SFClusterHealthUsingPolicy](cmdlets/Get-SFClusterHealthUsingPolicy.md)|Gets the health of a Service Fabric cluster using the specified policy.
[Get-SFClusterManifest](cmdlets/Get-SFClusterManifest.md)|Get the Service Fabric cluster manifest.
[Get-SFClusterUpgradeProgress](cmdlets/Get-SFClusterUpgradeProgress.md)|Gets the progress of the current cluster upgrade.
[Get-SFClusterVersion](cmdlets/Get-SFClusterVersion.md)|Get the current Service Fabric cluster version.
[Get-SFComposeDeploymentStatus](cmdlets/Get-SFComposeDeploymentStatus.md)|Gets information about a Service Fabric compose deployment.
[Get-SFComposeDeploymentStatusList](cmdlets/Get-SFComposeDeploymentStatusList.md)|Gets the list of compose deployments created in the Service Fabric cluster.
[Get-SFComposeDeploymentUpgradeProgress](cmdlets/Get-SFComposeDeploymentUpgradeProgress.md)|Gets details for the latest upgrade performed on this Service Fabric compose deployment.
[Get-SFContainerLogsDeployedOnNode](cmdlets/Get-SFContainerLogsDeployedOnNode.md)|Gets the container logs for container deployed on a Service Fabric node.
[Get-SFContainerLogsMeshCodePackage](cmdlets/Get-SFContainerLogsMeshCodePackage.md)|Gets the logs from the container.
[Get-SFContainersEventList](cmdlets/Get-SFContainersEventList.md)|Gets all Containers-related events.
[Get-SFCorrelatedEventList](cmdlets/Get-SFCorrelatedEventList.md)|Gets all correlated events for a given event.
[Get-SFDataLossProgress](cmdlets/Get-SFDataLossProgress.md)|Gets the progress of a partition data loss operation started using the StartDataLoss API.
[Get-SFDeployedApplication](cmdlets/Get-SFDeployedApplication.md)|Gets the list of applications deployed on a Service Fabric node.
[Get-SFDeployedApplicationHealth](cmdlets/Get-SFDeployedApplicationHealth.md)|Gets the information about health of an application deployed on a Service Fabric node.
[Get-SFDeployedApplicationHealthUsingPolicy](cmdlets/Get-SFDeployedApplicationHealthUsingPolicy.md)|Gets the information about health of an application deployed on a Service Fabric node. using the specified policy.
[Get-SFDeployedCodePackageInfoList](cmdlets/Get-SFDeployedCodePackageInfoList.md)|Gets the list of code packages deployed on a Service Fabric node.
[Get-SFDeployedServicePackage](cmdlets/Get-SFDeployedServicePackage.md)|Gets the list of service packages deployed on a Service Fabric node.
[Get-SFDeployedServicePackageHealth](cmdlets/Get-SFDeployedServicePackageHealth.md)|Gets the information about health of a service package for a specific application deployed for a Service Fabric node and application.
[Get-SFDeployedServicePackageHealthUsingPolicy](cmdlets/Get-SFDeployedServicePackageHealthUsingPolicy.md)|Gets the information about health of service package for a specific application deployed on a Service Fabric node using the specified policy.
[Get-SFDeployedServiceReplicaDetail](cmdlets/Get-SFDeployedServiceReplicaDetail.md)|Gets the details of replica deployed on a Service Fabric node.
[Get-SFDeployedServiceReplicaInfoList](cmdlets/Get-SFDeployedServiceReplicaInfoList.md)|Gets the list of replicas deployed on a Service Fabric node.
[Get-SFDeployedServiceType](cmdlets/Get-SFDeployedServiceType.md)|Gets the list containing the information about service types from the applications deployed on a node in a Service Fabric cluster.
[Get-SFFaultOperationList](cmdlets/Get-SFFaultOperationList.md)|Gets a list of user-induced fault operations filtered by provided input.
[Get-SFImageStoreContent](cmdlets/Get-SFImageStoreContent.md)|Gets the image store content information.
[Get-SFImageStoreRootContent](cmdlets/Get-SFImageStoreRootContent.md)|Gets the content information at the root of the image store.
[Get-SFImageStoreUploadSessionById](cmdlets/Get-SFImageStoreUploadSessionById.md)|Get the image store upload session by ID.
[Get-SFImageStoreUploadSessionByPath](cmdlets/Get-SFImageStoreUploadSessionByPath.md)|Get the image store upload session by relative path.
[Get-SFMeshApplication](cmdlets/Get-SFMeshApplication.md)|Lists all the application resources.
[Get-SFMeshGateway](cmdlets/Get-SFMeshGateway.md)|Lists all the gateway resources.
[Get-SFMeshNetwork](cmdlets/Get-SFMeshNetwork.md)|Lists all the network resources.
[Get-SFMeshSecret](cmdlets/Get-SFMeshSecret.md)|Lists all the secret resources.
[Get-SFMeshSecretValue](cmdlets/Get-SFMeshSecretValue.md)|List names of all values of the the specified secret resource.
[Get-SFMeshService](cmdlets/Get-SFMeshService.md)|Lists all the service resources.
[Get-SFMeshServiceReplica](cmdlets/Get-SFMeshServiceReplica.md)|Lists all the replicas of a service.
[Get-SFMeshVolume](cmdlets/Get-SFMeshVolume.md)|Lists all the volume resources.
[Get-SFNameExistsInfo](cmdlets/Get-SFNameExistsInfo.md)|Returns whether the Service Fabric name exists.
[Get-SFNode](cmdlets/Get-SFNode.md)|Gets the list of nodes in the Service Fabric cluster.
[Get-SFNodeHealth](cmdlets/Get-SFNodeHealth.md)|Gets the health of a Service Fabric node.
[Get-SFNodeHealthUsingPolicy](cmdlets/Get-SFNodeHealthUsingPolicy.md)|Gets the health of a Service Fabric node, by using the specified health policy.
[Get-SFNodeLoadInfo](cmdlets/Get-SFNodeLoadInfo.md)|Gets the load information of a Service Fabric node.
[Get-SFNodesEvent](cmdlets/Get-SFNodesEvent.md)|Gets all Nodes-related Events.
[Get-SFNodeTransitionProgress](cmdlets/Get-SFNodeTransitionProgress.md)|Gets the progress of an operation started using StartNodeTransition.
[Get-SFPartition](cmdlets/Get-SFPartition.md)|Gets the list of partitions of a Service Fabric service.
[Get-SFPartitionBackupConfigurationInfo](cmdlets/Get-SFPartitionBackupConfigurationInfo.md)|Gets the partition backup configuration information
[Get-SFPartitionBackupList](cmdlets/Get-SFPartitionBackupList.md)|Gets the list of backups available for the specified partition.
[Get-SFPartitionBackupProgress](cmdlets/Get-SFPartitionBackupProgress.md)|Gets details for the latest backup triggered for this partition.
[Get-SFPartitionHealth](cmdlets/Get-SFPartitionHealth.md)|Gets the health of the specified Service Fabric partition.
[Get-SFPartitionHealthUsingPolicy](cmdlets/Get-SFPartitionHealthUsingPolicy.md)|Gets the health of the specified Service Fabric partition, by using the specified health policy.
[Get-SFPartitionLoadInformation](cmdlets/Get-SFPartitionLoadInformation.md)|Gets the load information of the specified Service Fabric partition.
[Get-SFPartitionReplicasEvent](cmdlets/Get-SFPartitionReplicasEvent.md)|Gets all Replicas-related events for a Partition.
[Get-SFPartitionRestartProgress](cmdlets/Get-SFPartitionRestartProgress.md)|Gets the progress of a PartitionRestart operation started using StartPartitionRestart.
[Get-SFPartitionRestoreProgress](cmdlets/Get-SFPartitionRestoreProgress.md)|Gets details for the latest restore operation triggered for this partition.
[Get-SFPartitionsEvent](cmdlets/Get-SFPartitionsEvent.md)|Gets all Partitions-related events.
[Get-SFPropertyInfo](cmdlets/Get-SFPropertyInfo.md)|Gets the specified Service Fabric property.
[Get-SFPropertyInfoList](cmdlets/Get-SFPropertyInfoList.md)|Gets information on all Service Fabric properties under a given name.
[Get-SFProvisionedFabricCodeVersionInfoList](cmdlets/Get-SFProvisionedFabricCodeVersionInfoList.md)|Gets a list of fabric code versions that are provisioned in a Service Fabric cluster.
[Get-SFProvisionedFabricConfigVersionInfoList](cmdlets/Get-SFProvisionedFabricConfigVersionInfoList.md)|Gets a list of fabric config versions that are provisioned in a Service Fabric cluster.
[Get-SFQuorumLossProgress](cmdlets/Get-SFQuorumLossProgress.md)|Gets the progress of a quorum loss operation on a partition started using the StartQuorumLoss API.
[Get-SFRepairTaskList](cmdlets/Get-SFRepairTaskList.md)|Gets a list of repair tasks matching the given filters.
[Get-SFReplica](cmdlets/Get-SFReplica.md)|Gets the information about replicas of a Service Fabric service partition.
[Get-SFReplicaHealth](cmdlets/Get-SFReplicaHealth.md)|Gets the health of a Service Fabric stateful service replica or stateless service instance.
[Get-SFReplicaHealthUsingPolicy](cmdlets/Get-SFReplicaHealthUsingPolicy.md)|Gets the health of a Service Fabric stateful service replica or stateless service instance using the specified policy.
[Get-SFService](cmdlets/Get-SFService.md)|Gets the information about all services belonging to the application specified by the application ID.
[Get-SFServiceBackupConfigurationInfo](cmdlets/Get-SFServiceBackupConfigurationInfo.md)|Gets the Service Fabric service backup configuration information.
[Get-SFServiceBackupList](cmdlets/Get-SFServiceBackupList.md)|Gets the list of backups available for every partition in this service.
[Get-SFServiceDescription](cmdlets/Get-SFServiceDescription.md)|Gets the description of an existing Service Fabric service.
[Get-SFServiceHealth](cmdlets/Get-SFServiceHealth.md)|Gets the health of the specified Service Fabric service.
[Get-SFServiceHealthUsingPolicy](cmdlets/Get-SFServiceHealthUsingPolicy.md)|Gets the health of the specified Service Fabric service, by using the specified health policy.
[Get-SFServiceManifest](cmdlets/Get-SFServiceManifest.md)|Gets the manifest describing a service type.
[Get-SFServiceNameInfo](cmdlets/Get-SFServiceNameInfo.md)|Gets the name of the Service Fabric service for a partition.
[Get-SFServicesEvent](cmdlets/Get-SFServicesEvent.md)|Gets all Services-related events.
[Get-SFServiceType](cmdlets/Get-SFServiceType.md)|Gets the list containing the information about service types that are supported by a provisioned application type in a Service Fabric cluster.
[Get-SFSubNameInfoList](cmdlets/Get-SFSubNameInfoList.md)|Enumerates all the Service Fabric names under a given name.
[Get-SFUpgradeOrchestrationServiceState](cmdlets/Get-SFUpgradeOrchestrationServiceState.md)|Get the service state of Service Fabric Upgrade Orchestration Service.
[New-SFApplication](cmdlets/New-SFApplication.md)|Creates a Service Fabric application.
[New-SFApplicationHealth](cmdlets/New-SFApplicationHealth.md)|Sends a health report on the Service Fabric application.
[New-SFApplicationUpgrade](cmdlets/New-SFApplicationUpgrade.md)|Starts rolling back the currently on-going upgrade of an application in the Service Fabric cluster.
[New-SFApproveRepairTask](cmdlets/New-SFApproveRepairTask.md)|Forces the approval of the given repair task.
[New-SFBackupPolicy](cmdlets/New-SFBackupPolicy.md)|Creates a backup policy.
[New-SFChaosSchedule](cmdlets/New-SFChaosSchedule.md)|Set the schedule used by Chaos.
[New-SFClusterHealth](cmdlets/New-SFClusterHealth.md)|Sends a health report on the Service Fabric cluster.
[New-SFClusterUpgrade](cmdlets/New-SFClusterUpgrade.md)|Roll back the upgrade of a Service Fabric cluster.
[New-SFComposeDeployment](cmdlets/New-SFComposeDeployment.md)|Creates a Service Fabric compose deployment.
[New-SFContainerApi](cmdlets/New-SFContainerApi.md)|Invoke container API on a container deployed on a Service Fabric node.
[New-SFDeployedApplicationHealth](cmdlets/New-SFDeployedApplicationHealth.md)|Sends a health report on the Service Fabric application deployed on a Service Fabric node.
[New-SFDeployedServicePackageHealth](cmdlets/New-SFDeployedServicePackageHealth.md)|Sends a health report on the Service Fabric deployed service package.
[New-SFImageStoreUploadSession](cmdlets/New-SFImageStoreUploadSession.md)|Commit an image store upload session.
[New-SFInfrastructureCommand](cmdlets/New-SFInfrastructureCommand.md)|Invokes an administrative command on the given Infrastructure Service instance.
[New-SFInfrastructureQuery](cmdlets/New-SFInfrastructureQuery.md)|Invokes a read-only query on the given infrastructure service instance.
[New-SFMeshApplication](cmdlets/New-SFMeshApplication.md)|Creates mesh application resource in service fabric cluster.
[New-SFMeshGateway](cmdlets/New-SFMeshGateway.md)|Creates mesh gateway resource in service fabric cluster.
[New-SFMeshNetwork](cmdlets/New-SFMeshNetwork.md)|Creates mesh network resource in service fabric cluster.
[New-SFMeshResourceDeployment](cmdlets/New-SFMeshResourceDeployment.md)|Deploys mesh resources in a Service Fabric cluster.
[New-SFMeshSecret](cmdlets/New-SFMeshSecret.md)|Creates mesh secret resource in service fabric cluster.
[New-SFMeshVolume](cmdlets/New-SFMeshVolume.md)|Creates mesh volume resource in service fabric cluster.
[New-SFName](cmdlets/New-SFName.md)|Creates a Service Fabric name.
[New-SFNodeHealth](cmdlets/New-SFNodeHealth.md)|Sends a health report on the Service Fabric node.
[New-SFPartitionHealth](cmdlets/New-SFPartitionHealth.md)|Sends a health report on the Service Fabric partition.
[New-SFProperty](cmdlets/New-SFProperty.md)|Creates or updates a Service Fabric property.
[New-SFRepairTask](cmdlets/New-SFRepairTask.md)|Creates a new repair task.
[New-SFReplicaHealth](cmdlets/New-SFReplicaHealth.md)|Sends a health report on the Service Fabric replica.
[New-SFService](cmdlets/New-SFService.md)|Creates the specified Service Fabric service.
[New-SFServiceFromTemplate](cmdlets/New-SFServiceFromTemplate.md)|Creates a Service Fabric service from the service template.
[New-SFServiceHealth](cmdlets/New-SFServiceHealth.md)|Sends a health report on the Service Fabric service.
[Register-SFApplicationType](cmdlets/Register-SFApplicationType.md)|Provisions or registers a Service Fabric application type with the cluster using the '.sfpkg' package in the external store or using the application package in the image store.
[Register-SFCluster](cmdlets/Register-SFCluster.md)|Provision the code or configuration packages of a Service Fabric cluster.
[Remove-SFApplication](cmdlets/Remove-SFApplication.md)|Deletes an existing Service Fabric application.
[Remove-SFBackupPolicy](cmdlets/Remove-SFBackupPolicy.md)|Deletes the backup policy.
[Remove-SFComposeDeployment](cmdlets/Remove-SFComposeDeployment.md)|Deletes an existing Service Fabric compose deployment from cluster.
[Remove-SFImageStoreContent](cmdlets/Remove-SFImageStoreContent.md)|Deletes existing image store content.
[Remove-SFImageStoreUploadSession](cmdlets/Remove-SFImageStoreUploadSession.md)|Cancels an image store upload session.
[Remove-SFMeshApplication](cmdlets/Remove-SFMeshApplication.md)|Deletes the Application resource.
[Remove-SFMeshGateway](cmdlets/Remove-SFMeshGateway.md)|Deletes the Gateway resource.
[Remove-SFMeshNetwork](cmdlets/Remove-SFMeshNetwork.md)|Deletes the Network resource.
[Remove-SFMeshSecret](cmdlets/Remove-SFMeshSecret.md)|Deletes the Secret resource.
[Remove-SFMeshSecretValue](cmdlets/Remove-SFMeshSecretValue.md)|Deletes the specified  value of the named secret resource.
[Remove-SFMeshVolume](cmdlets/Remove-SFMeshVolume.md)|Deletes the Volume resource.
[Remove-SFName](cmdlets/Remove-SFName.md)|Deletes a Service Fabric name.
[Remove-SFNodeState](cmdlets/Remove-SFNodeState.md)|Notifies Service Fabric that the persisted state on a node has been permanently removed or lost.
[Remove-SFProperty](cmdlets/Remove-SFProperty.md)|Deletes the specified Service Fabric property.
[Remove-SFRepairTask](cmdlets/Remove-SFRepairTask.md)|Deletes a completed repair task.
[Remove-SFReplica](cmdlets/Remove-SFReplica.md)|Removes a service replica running on a node.
[Remove-SFService](cmdlets/Remove-SFService.md)|Deletes an existing Service Fabric service.
[Repair-SFAllPartitions](cmdlets/Repair-SFAllPartitions.md)|Indicates to the Service Fabric cluster that it should attempt to recover any services (including system services) which are currently stuck in quorum loss.
[Repair-SFPartition](cmdlets/Repair-SFPartition.md)|Indicates to the Service Fabric cluster that it should attempt to recover a specific partition that is currently stuck in quorum loss.
[Repair-SFServicePartitions](cmdlets/Repair-SFServicePartitions.md)|Indicates to the Service Fabric cluster that it should attempt to recover the specified service that is currently stuck in quorum loss.
[Repair-SFSystemPartitions](cmdlets/Repair-SFSystemPartitions.md)|Indicates to the Service Fabric cluster that it should attempt to recover the system services that are currently stuck in quorum loss.
[Reset-SFPartitionLoad](cmdlets/Reset-SFPartitionLoad.md)|Resets the current load of a Service Fabric partition.
[Resolve-SFService](cmdlets/Resolve-SFService.md)|Resolve a Service Fabric partition.
[Restart-SFDeployedCodePackage](cmdlets/Restart-SFDeployedCodePackage.md)|Restarts a code package deployed on a Service Fabric node in a cluster.
[Restart-SFNode](cmdlets/Restart-SFNode.md)|Restarts a Service Fabric cluster node.
[Restart-SFReplica](cmdlets/Restart-SFReplica.md)|Restarts a service replica of a persisted service running on a node.
[Restore-SFPartition](cmdlets/Restore-SFPartition.md)|Triggers restore of the state of the partition using the specified restore partition description.
[Resume-SFApplicationBackup](cmdlets/Resume-SFApplicationBackup.md)|Resumes periodic backup of a Service Fabric application which was previously suspended.
[Resume-SFApplicationUpgrade](cmdlets/Resume-SFApplicationUpgrade.md)|Resumes upgrading an application in the Service Fabric cluster.
[Resume-SFClusterUpgrade](cmdlets/Resume-SFClusterUpgrade.md)|Make the cluster upgrade move on to the next upgrade domain.
[Resume-SFPartitionBackup](cmdlets/Resume-SFPartitionBackup.md)|Resumes periodic backup of partition which was previously suspended.
[Resume-SFServiceBackup](cmdlets/Resume-SFServiceBackup.md)|Resumes periodic backup of a Service Fabric service which was previously suspended.
[Set-SFUpgradeOrchestrationServiceState](cmdlets/Set-SFUpgradeOrchestrationServiceState.md)|Update the service state of Service Fabric Upgrade Orchestration Service.
[Show-SFMeshSecretValue](cmdlets/Show-SFMeshSecretValue.md)|Lists the specified value of the secret resource.
[Start-SFApplicationUpgrade](cmdlets/Start-SFApplicationUpgrade.md)|Starts upgrading an application in the Service Fabric cluster.
[Start-SFChaos](cmdlets/Start-SFChaos.md)|Starts Chaos in the cluster.
[Start-SFClusterConfigurationUpgrade](cmdlets/Start-SFClusterConfigurationUpgrade.md)|Start upgrading the configuration of a Service Fabric standalone cluster.
[Start-SFClusterUpgrade](cmdlets/Start-SFClusterUpgrade.md)|Start upgrading the code or configuration version of a Service Fabric cluster.
[Start-SFComposeDeploymentUpgrade](cmdlets/Start-SFComposeDeploymentUpgrade.md)|Starts upgrading a compose deployment in the Service Fabric cluster.
[Start-SFDataLoss](cmdlets/Start-SFDataLoss.md)|This API will induce data loss for the specified partition. It will trigger a call to the OnDataLossAsync API of the partition.
[Start-SFNodeTransition](cmdlets/Start-SFNodeTransition.md)|Starts or stops a cluster node.
[Start-SFPartitionRestart](cmdlets/Start-SFPartitionRestart.md)|This API will restart some or all replicas or instances of the specified partition.
[Start-SFQuorumLoss](cmdlets/Start-SFQuorumLoss.md)|Induces quorum loss for a given stateful service partition.
[Start-SFRollbackComposeDeploymentUpgrade](cmdlets/Start-SFRollbackComposeDeploymentUpgrade.md)|Starts rolling back a compose deployment upgrade in the Service Fabric cluster.
[Stop-SFChaos](cmdlets/Stop-SFChaos.md)|Stops Chaos if it is running in the cluster and put the Chaos Schedule in a stopped state.
[Stop-SFOperation](cmdlets/Stop-SFOperation.md)|Cancels a user-induced fault operation.
[Stop-SFRepairTask](cmdlets/Stop-SFRepairTask.md)|Requests the cancellation of the given repair task.
[Submit-SFPropertyBatch](cmdlets/Submit-SFPropertyBatch.md)|Submits a property batch.
[Suspend-SFApplicationBackup](cmdlets/Suspend-SFApplicationBackup.md)|Suspends periodic backup for the specified Service Fabric application.
[Suspend-SFPartitionBackup](cmdlets/Suspend-SFPartitionBackup.md)|Suspends periodic backup for the specified partition.
[Suspend-SFServiceBackup](cmdlets/Suspend-SFServiceBackup.md)|Suspends periodic backup for the specified Service Fabric service.
[Test-SFClusterConnection](cmdlets/Test-SFClusterConnection.md)|Tests connection to Service Fabric cluster. 
[Unregister-SFApplicationType](cmdlets/Unregister-SFApplicationType.md)|Removes or unregisters a Service Fabric application type from the cluster.
[Unregister-SFCluster](cmdlets/Unregister-SFCluster.md)|Unprovision the code or configuration packages of a Service Fabric cluster.
[Update-SFApplicationUpgrade](cmdlets/Update-SFApplicationUpgrade.md)|Updates an ongoing application upgrade in the Service Fabric cluster.
[Update-SFBackupPolicy](cmdlets/Update-SFBackupPolicy.md)|Updates the backup policy.
[Update-SFClusterUpgrade](cmdlets/Update-SFClusterUpgrade.md)|Update the upgrade parameters of a Service Fabric cluster upgrade.
[Update-SFMeshApplication](cmdlets/Update-SFMeshApplication.md)|Updates mesh application resource in service fabric cluster.
[Update-SFMeshGateway](cmdlets/Update-SFMeshGateway.md)|Updates mesh gateway resource in service fabric cluster.
[Update-SFMeshNetwork](cmdlets/Update-SFMeshNetwork.md)|Updates mesh network resource in service fabric cluster.
[Update-SFMeshSecret](cmdlets/Update-SFMeshSecret.md)|Updates mesh secret resource in service fabric cluster.
[Update-SFMeshVolume](cmdlets/Update-SFMeshVolume.md)|Updates mesh volume resource in service fabric cluster.
[Update-SFRepairExecutionState](cmdlets/Update-SFRepairExecutionState.md)|Updates the execution state of a repair task.
[Update-SFRepairTaskHealthPolicy](cmdlets/Update-SFRepairTaskHealthPolicy.md)|Updates the health policy of the given repair task.
[Update-SFService](cmdlets/Update-SFService.md)|Updates a Service Fabric service using the specified update description.

