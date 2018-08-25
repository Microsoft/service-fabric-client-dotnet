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
    /// Commit an image store upload session.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SFImageStoreUploadSession", DefaultParameterSetName = "CommitImageStoreUploadSession")]
    public partial class NewImageStoreUploadSessionCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets SessionId. A GUID generated by the user for a file uploading. It identifies an image store upload
        /// session which keeps track of all file chunks until it is committed.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "CommitImageStoreUploadSession")]
        public Guid? SessionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "CommitImageStoreUploadSession")]
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
                this.ServiceFabricClient.ImageStore.CommitImageStoreUploadSessionAsync(
                    sessionId: this.SessionId,
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
