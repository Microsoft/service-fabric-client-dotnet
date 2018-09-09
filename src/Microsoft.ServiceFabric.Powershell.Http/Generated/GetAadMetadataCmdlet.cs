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
    /// Gets the Azure Active Directory metadata used for secured connection to cluster.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFAadMetadata", DefaultParameterSetName = "GetAadMetadata")]
    public partial class GetAadMetadataCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "GetAadMetadata")]
        public long? ServerTimeout
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            var result = this.ServiceFabricClient.Cluster.GetAadMetadataAsync(
                serverTimeout: this.ServerTimeout,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

            this.WriteObject(this.FormatOutput(result));
        }

        /// <inheritdoc/>
        protected override object FormatOutput(object output)
        {
            return output;
        }
    }
}
