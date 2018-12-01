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
    /// Gets the next segment of the Chaos events based on the continuation token or the time range.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFChaosEvents")]
    public partial class GetChaosEventsCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets StartTimeUtc. The Windows file time representing the start time of the time range for which a Chaos
        /// report is to be generated. Consult [DateTime.ToFileTimeUtc
        /// Method](https://msdn.microsoft.com/library/system.datetime.tofiletimeutc(v=vs.110).aspx) for details.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0)]
        public string StartTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets EndTimeUtc. The Windows file time representing the end time of the time range for which a Chaos report
        /// is to be generated. Consult [DateTime.ToFileTimeUtc
        /// Method](https://msdn.microsoft.com/library/system.datetime.tofiletimeutc(v=vs.110).aspx) for details.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1)]
        public string EndTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets MaxResults. The maximum number of results to be returned as part of the paged queries. This parameter
        /// defines the upper bound on the number of results returned. The results returned can be less than the specified
        /// maximum results if they do not fit in the message as per the max message size restrictions defined in the
        /// configuration. If this parameter is zero or not specified, the paged query includes as many results as possible
        /// that fit in the return message.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2)]
        public long? MaxResults { get; set; }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3)]
        public long? ServerTimeout { get; set; }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            var continuationToken = default(ContinuationToken);
            do
            {
                var result = this.ServiceFabricClient.ChaosClient.GetChaosEventsAsync(
                    continuationToken: continuationToken,
                    startTimeUtc: this.StartTimeUtc,
                    endTimeUtc: this.EndTimeUtc,
                    maxResults: this.MaxResults,
                    serverTimeout: this.ServerTimeout,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                if (result == null)
                {
                    break;
                }

                var count = 0;
                foreach (var item in result.Data)
                {
                    count++;
                    this.WriteObject(this.FormatOutput(item));
                }

                continuationToken = result.ContinuationToken;
                this.WriteDebug(string.Format(Resource.MsgCountAndContinuationToken, count, continuationToken));
            }
            while (continuationToken.Next);
        }

        /// <inheritdoc/>
        protected override object FormatOutput(object output)
        {
            return output;
        }
    }
}
