// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.IO;
    using System.Management.Automation;
    using Microsoft.ServiceFabric.Client;

    /// <summary>
    /// Updates mesh network resource in service fabric cluster.
    /// </summary>
    [Cmdlet(VerbsData.Update, "SFMeshNetwork")]
    public class UpdateMeshNetworkCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets network name to update.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        [Parameter(Mandatory = true, ParameterSetName = "jsonfile")]
        [ValidateNotNullOrEmpty]
        public string NetworkResourceName { get; set; }

        /// <summary>
        /// Gets or sets the json containing the description of the network to be updated.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        [ValidateNotNullOrEmpty]
        public string JsonDescription { get; set; }

        /// <summary>
        /// Gets or sets the Json resource file containing the description of the network to be updated.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "jsonfile")]
        [ValidateNotNullOrEmpty]
        public string ResourceDescriptionFile { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecordInternal()
        {
            var networkResourceInfo = this.ServiceFabricClient.MeshNetworks.GetAsync(this.NetworkResourceName, this.CancellationToken).GetAwaiter().GetResult();

            if (networkResourceInfo == null)
            {
                throw new InvalidOperationException("Specified mesh network doesn't exist in cluster.");
            }

            var jsonDescription = this.JsonDescription;

            if (this.ParameterSetName.Equals("jsonfile"))
            {
                jsonDescription = File.ReadAllText(this.ResourceDescriptionFile);
            }

            this.ServiceFabricClient.MeshNetworks.CreateOrUpdateAsync(
                networkResourceName: this.NetworkResourceName,
                jsonDescription: jsonDescription,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
        }
    }
}
