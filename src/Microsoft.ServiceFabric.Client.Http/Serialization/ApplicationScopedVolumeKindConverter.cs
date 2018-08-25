// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converter for <see cref="ApplicationScopedVolumeKind" />.
    /// </summary>
    internal class ApplicationScopedVolumeKindConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static ApplicationScopedVolumeKind? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(ApplicationScopedVolumeKind);

            if (string.Compare(value, "ServiceFabricVolumeDisk", StringComparison.Ordinal) == 0)
            {
                obj = ApplicationScopedVolumeKind.ServiceFabricVolumeDisk;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, ApplicationScopedVolumeKind? value)
        {
            switch (value)
            {
                case ApplicationScopedVolumeKind.ServiceFabricVolumeDisk:
                    writer.WriteStringValue("ServiceFabricVolumeDisk");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type ApplicationScopedVolumeKind");
            }
        }
    }
}
