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
    /// This API will induce data loss for the specified partition. It will trigger a call to the OnDataLossAsync API of
    /// the partition.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SFDataLoss", DefaultParameterSetName = "StartDataLoss")]
    public partial class StartDataLossCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets ServiceId. The identity of the service. This ID is typically the full name of the service without the
        /// 'fabric:' URI scheme.
        /// Starting from version 6.0, hierarchical names are delimited with the "~" character.
        /// For example, if the service name is "fabric:/myapp/app1/svc1", the service identity would be "myapp~app1~svc1" in
        /// 6.0+ and "myapp/app1/svc1" in previous versions.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = "StartDataLoss")]
        public string ServiceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets PartitionId. The identity of the partition.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, ParameterSetName = "StartDataLoss")]
        public PartitionId PartitionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets OperationId. A GUID that identifies a call of this API.  This is passed into the corresponding
        /// GetProgress API
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "StartDataLoss")]
        public Guid? OperationId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets DataLossMode. This enum is passed to the StartDataLoss API to indicate what type of data loss to
        /// induce. Possible values include: 'Invalid', 'PartialDataLoss', 'FullDataLoss'
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, ParameterSetName = "StartDataLoss")]
        public DataLossMode? DataLossMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "StartDataLoss")]
        public long? ServerTimeout
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                this.ServiceFabricClient.Faults.StartDataLossAsync(
                    serviceId: this.ServiceId,
                    partitionId: this.PartitionId,
                    operationId: this.OperationId,
                    dataLossMode: this.DataLossMode,
                    serverTimeout: this.ServerTimeout,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                Console.WriteLine("Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
