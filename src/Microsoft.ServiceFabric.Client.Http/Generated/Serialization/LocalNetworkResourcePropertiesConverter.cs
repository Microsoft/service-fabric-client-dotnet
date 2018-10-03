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
    /// Converter for <see cref="LocalNetworkResourceProperties" />.
    /// </summary>
    internal class LocalNetworkResourcePropertiesConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static LocalNetworkResourceProperties Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static LocalNetworkResourceProperties GetFromJsonProperties(JsonReader reader)
        {
            var description = default(string);
            var status = default(ResourceStatus?);
            var statusDetails = default(string);
            var networkAddressPrefix = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("description", propName, StringComparison.Ordinal) == 0)
                {
                    description = reader.ReadValueAsString();
                }
                else if (string.Compare("status", propName, StringComparison.Ordinal) == 0)
                {
                    status = ResourceStatusConverter.Deserialize(reader);
                }
                else if (string.Compare("statusDetails", propName, StringComparison.Ordinal) == 0)
                {
                    statusDetails = reader.ReadValueAsString();
                }
                else if (string.Compare("networkAddressPrefix", propName, StringComparison.Ordinal) == 0)
                {
                    networkAddressPrefix = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            var localNetworkResourceProperties = new LocalNetworkResourceProperties(
                description: description,
                status: status,
                networkAddressPrefix: networkAddressPrefix);

            localNetworkResourceProperties.StatusDetails = statusDetails;
            return localNetworkResourceProperties;
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, LocalNetworkResourceProperties obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind, "kind", NetworkKindConverter.Serialize);
            writer.WriteProperty(obj.Status, "status", ResourceStatusConverter.Serialize);
            if (obj.Description != null)
            {
                writer.WriteProperty(obj.Description, "description", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.StatusDetails != null)
            {
                writer.WriteProperty(obj.StatusDetails, "statusDetails", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.NetworkAddressPrefix != null)
            {
                writer.WriteProperty(obj.NetworkAddressPrefix, "networkAddressPrefix", JsonWriterExtensions.WriteStringValue);
            }

            writer.WriteEndObject();
        }
    }
}
