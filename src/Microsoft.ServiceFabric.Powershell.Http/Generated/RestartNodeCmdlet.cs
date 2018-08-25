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
    /// Restarts a Service Fabric cluster node.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Restart, "SFNode", DefaultParameterSetName = "RestartNode")]
    public partial class RestartNodeCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets NodeName. The name of the node.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = "RestartNode")]
        public NodeName NodeName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets NodeInstanceId. The instance ID of the target node. If instance ID is specified the node is restarted
        /// only if it matches with the current instance of the node. A default value of "0" would match any instance ID. The
        /// instance ID can be obtained using get node query.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "RestartNode")]
        public string NodeInstanceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets CreateFabricDump. Specify True to create a dump of the fabric node process. This is case-sensitive.
        /// Possible values include: 'False', 'True'
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "RestartNode")]
        public CreateFabricDump? CreateFabricDump
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "RestartNode")]
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
                var restartNodeDescription = new RestartNodeDescription(
                nodeInstanceId: this.NodeInstanceId,
                createFabricDump: this.CreateFabricDump);

                this.ServiceFabricClient.Nodes.RestartNodeAsync(
                    nodeName: this.NodeName,
                    restartNodeDescription: restartNodeDescription,
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
