// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes how a volume is attached to a container.
    /// </summary>
    public partial class ContainerVolume
    {
        /// <summary>
        /// Initializes a new instance of the ContainerVolume class.
        /// </summary>
        /// <param name="name">Name of the volume.</param>
        /// <param name="destinationPath">The path within the container at which the volume should be mounted. Only valid path
        /// characters are allowed.</param>
        /// <param name="readOnly">The flag indicating whether the volume is read only. Default is 'false'.</param>
        public ContainerVolume(
            string name,
            string destinationPath,
            bool? readOnly = default(bool?))
        {
            name.ThrowIfNull(nameof(name));
            destinationPath.ThrowIfNull(nameof(destinationPath));
            this.Name = name;
            this.DestinationPath = destinationPath;
            this.ReadOnly = readOnly;
        }

        /// <summary>
        /// Gets name of the volume.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the flag indicating whether the volume is read only. Default is 'false'.
        /// </summary>
        public bool? ReadOnly { get; }

        /// <summary>
        /// Gets the path within the container at which the volume should be mounted. Only valid path characters are allowed.
        /// </summary>
        public string DestinationPath { get; }
    }
}
