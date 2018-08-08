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
    /// Converter for <see cref="ServiceResourceReplicaDescription" />.
    /// </summary>
    internal class ServiceResourceReplicaDescriptionConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ServiceResourceReplicaDescription Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ServiceResourceReplicaDescription GetFromJsonProperties(JsonReader reader)
        {
            var osType = default(OperatingSystemTypes?);
            var codePackages = default(IEnumerable<ContainerCodePackageProperties>);
            var networkRefs = default(IEnumerable<NetworkRef>);
            var diagnostics = default(DiagnosticsRef);
            var replicaName = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("osType", propName, StringComparison.Ordinal) == 0)
                {
                    osType = OperatingSystemTypesConverter.Deserialize(reader);
                }
                else if (string.Compare("codePackages", propName, StringComparison.Ordinal) == 0)
                {
                    codePackages = reader.ReadList(ContainerCodePackagePropertiesConverter.Deserialize);
                }
                else if (string.Compare("networkRefs", propName, StringComparison.Ordinal) == 0)
                {
                    networkRefs = reader.ReadList(NetworkRefConverter.Deserialize);
                }
                else if (string.Compare("diagnostics", propName, StringComparison.Ordinal) == 0)
                {
                    diagnostics = DiagnosticsRefConverter.Deserialize(reader);
                }
                else if (string.Compare("replicaName", propName, StringComparison.Ordinal) == 0)
                {
                    replicaName = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ServiceResourceReplicaDescription(
                osType: osType,
                codePackages: codePackages,
                networkRefs: networkRefs,
                diagnostics: diagnostics,
                replicaName: replicaName);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ServiceResourceReplicaDescription obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.OsType, "osType", OperatingSystemTypesConverter.Serialize);
            writer.WriteEnumerableProperty(obj.CodePackages, "codePackages", ContainerCodePackagePropertiesConverter.Serialize);
            writer.WriteProperty(obj.ReplicaName, "replicaName", JsonWriterExtensions.WriteStringValue);
            if (obj.NetworkRefs != null)
            {
                writer.WriteEnumerableProperty(obj.NetworkRefs, "networkRefs", NetworkRefConverter.Serialize);
            }

            if (obj.Diagnostics != null)
            {
                writer.WriteProperty(obj.Diagnostics, "diagnostics", DiagnosticsRefConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
