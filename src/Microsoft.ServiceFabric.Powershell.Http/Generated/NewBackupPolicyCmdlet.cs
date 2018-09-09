// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.ServiceFabric.Common;

    /// <summary>
    /// Creates a backup policy.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SFBackupPolicy", DefaultParameterSetName = "CreateBackupPolicy")]
    public partial class NewBackupPolicyCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets FrequencyBased flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "CreateBackupPolicy")]
        public SwitchParameter FrequencyBased
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets TimeBased flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "CreateBackupPolicy")]
        public SwitchParameter TimeBased
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets AzureBlobStore flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "CreateBackupPolicy")]
        public SwitchParameter AzureBlobStore
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets FileShare flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "CreateBackupPolicy")]
        public SwitchParameter FileShare
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Basic flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "CreateBackupPolicy")]
        public SwitchParameter Basic
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Name. The unique name identifying this backup policy.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = "CreateBackupPolicy")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets AutoRestoreOnDataLoss. Specifies whether to trigger restore automatically using the latest available
        /// backup in case the partition experiences a data loss event.
        /// </summary>
        [Parameter(Mandatory = true, Position = 4, ParameterSetName = "CreateBackupPolicy")]
        public bool? AutoRestoreOnDataLoss { get; set; }

        /// <summary>
        /// Gets or sets MaxIncrementalBackups. Defines the maximum number of incremental backups to be taken between two full
        /// backups. This is just the upper limit. A full backup may be taken before specified number of incremental backups
        /// are completed in one of the following conditions
        /// - The replica has never taken a full backup since it has become primary,
        /// - Some of the log records since the last backup has been truncated, or
        /// - Replica passed the MaxAccumulatedBackupLogSizeInMB limit.
        /// </summary>
        [Parameter(Mandatory = true, Position = 5, ParameterSetName = "CreateBackupPolicy")]
        public int? MaxIncrementalBackups { get; set; }

        /// <summary>
        /// Gets or sets Interval. Defines the interval with which backups are periodically taken. It should be specified in
        /// ISO8601 format. Timespan in seconds is not supported and will be ignored while creating the policy.
        /// </summary>
        [Parameter(Mandatory = true, Position = 6, ParameterSetName = "CreateBackupPolicy")]
        public TimeSpan? Interval { get; set; }

        /// <summary>
        /// Gets or sets ScheduleFrequencyType. Describes the frequency with which to run the time based backup schedule.
        /// . Possible values include: 'Invalid', 'Daily', 'Weekly'
        /// </summary>
        [Parameter(Mandatory = true, Position = 7, ParameterSetName = "CreateBackupPolicy")]
        public BackupScheduleFrequencyType? ScheduleFrequencyType { get; set; }

        /// <summary>
        /// Gets or sets RunTimes. Represents the list of exact time during the day in ISO8601 format. Like '19:00:00' will
        /// represent '7PM' during the day. Date specified along with time will be ignored.
        /// </summary>
        [Parameter(Mandatory = true, Position = 8, ParameterSetName = "CreateBackupPolicy")]
        public IEnumerable<DateTime?> RunTimes { get; set; }

        /// <summary>
        /// Gets or sets ConnectionString. The connection string to connect to the Azure blob store.
        /// </summary>
        [Parameter(Mandatory = true, Position = 9, ParameterSetName = "CreateBackupPolicy")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets ContainerName. The name of the container in the blob store to store and enumerate backups from.
        /// </summary>
        [Parameter(Mandatory = true, Position = 10, ParameterSetName = "CreateBackupPolicy")]
        public string ContainerName { get; set; }

        /// <summary>
        /// Gets or sets Path. UNC path of the file share where to store or enumerate backups from.
        /// </summary>
        [Parameter(Mandatory = true, Position = 11, ParameterSetName = "CreateBackupPolicy")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets RetentionDuration. It is the minimum duration for which a backup created, will remain stored in the
        /// storage and might get deleted after that span of time. It should be specified in ISO8601 format.
        /// </summary>
        [Parameter(Mandatory = true, Position = 12, ParameterSetName = "CreateBackupPolicy")]
        public TimeSpan? RetentionDuration { get; set; }

        /// <summary>
        /// Gets or sets RunDays. List of days of a week when to trigger the periodic backup. This is valid only when the
        /// backup schedule frequency type is weekly.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ParameterSetName = "CreateBackupPolicy")]
        public IEnumerable<DayOfWeek?> RunDays { get; set; }

        /// <summary>
        /// Gets or sets FriendlyName. Friendly name for this backup storage.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ParameterSetName = "CreateBackupPolicy")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets PrimaryUserName. Primary user name to access the file share.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ParameterSetName = "CreateBackupPolicy")]
        public string PrimaryUserName { get; set; }

        /// <summary>
        /// Gets or sets PrimaryPassword. Primary password to access the share location.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ParameterSetName = "CreateBackupPolicy")]
        public string PrimaryPassword { get; set; }

        /// <summary>
        /// Gets or sets SecondaryUserName. Secondary user name to access the file share.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ParameterSetName = "CreateBackupPolicy")]
        public string SecondaryUserName { get; set; }

        /// <summary>
        /// Gets or sets SecondaryPassword. Secondary password to access the share location
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ParameterSetName = "CreateBackupPolicy")]
        public string SecondaryPassword { get; set; }

        /// <summary>
        /// Gets or sets MinimumNumberOfBackups. It is the minimum number of backups to be retained at any point of time. If
        /// specified with a non zero value, backups will not be deleted even if the backups have gone past retention duration
        /// and have number of backups less than or equal to it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ParameterSetName = "CreateBackupPolicy")]
        public int? MinimumNumberOfBackups { get; set; }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ParameterSetName = "CreateBackupPolicy")]
        public long? ServerTimeout
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            BackupScheduleDescription backupScheduleDescription = null;
            if (this.FrequencyBased.IsPresent)
            {
                backupScheduleDescription = new FrequencyBasedBackupScheduleDescription(
                    interval: this.Interval);
            }
            else if (this.TimeBased.IsPresent)
            {
                backupScheduleDescription = new TimeBasedBackupScheduleDescription(
                    scheduleFrequencyType: this.ScheduleFrequencyType,
                    runTimes: this.RunTimes,
                    runDays: this.RunDays);
            }

            BackupStorageDescription backupStorageDescription = null;
            if (this.AzureBlobStore.IsPresent)
            {
                backupStorageDescription = new AzureBlobBackupStorageDescription(
                    connectionString: this.ConnectionString,
                    containerName: this.ContainerName,
                    friendlyName: this.FriendlyName);
            }
            else if (this.FileShare.IsPresent)
            {
                backupStorageDescription = new FileShareBackupStorageDescription(
                    path: this.Path,
                    friendlyName: this.FriendlyName,
                    primaryUserName: this.PrimaryUserName,
                    primaryPassword: this.PrimaryPassword,
                    secondaryUserName: this.SecondaryUserName,
                    secondaryPassword: this.SecondaryPassword);
            }

            RetentionPolicyDescription retentionPolicyDescription = null;
            if (this.Basic.IsPresent)
            {
                retentionPolicyDescription = new BasicRetentionPolicyDescription(
                    retentionDuration: this.RetentionDuration,
                    minimumNumberOfBackups: this.MinimumNumberOfBackups);
            }

            var backupPolicyDescription = new BackupPolicyDescription(
            name: this.Name,
            autoRestoreOnDataLoss: this.AutoRestoreOnDataLoss,
            maxIncrementalBackups: this.MaxIncrementalBackups,
            schedule: backupScheduleDescription,
            storage: backupStorageDescription,
            retentionPolicy: retentionPolicyDescription);

            this.ServiceFabricClient.BackupRestore.CreateBackupPolicyAsync(
                backupPolicyDescription: backupPolicyDescription,
                serverTimeout: this.ServerTimeout,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

            Console.WriteLine("Success!");
        }
    }
}
