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
    /// Converter for <see cref="ServiceResourceDescription" />.
    /// </summary>
    internal class ServiceResourceDescriptionConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ServiceResourceDescription Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ServiceResourceDescription GetFromJsonProperties(JsonReader reader)
        {
            var properties = default(ServiceResourceProperties);
            var name = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("properties", propName, StringComparison.Ordinal) == 0)
                {
                    properties = ServiceResourcePropertiesConverter.Deserialize(reader);
                }
                else if (string.Compare("name", propName, StringComparison.Ordinal) == 0)
                {
                    name = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ServiceResourceDescription(
                properties: properties,
                name: name);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ServiceResourceDescription obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Properties, "properties", ServiceResourcePropertiesConverter.Serialize);
            writer.WriteProperty(obj.Name, "name", JsonWriterExtensions.WriteStringValue);
            writer.WriteEndObject();
        }
    }
}
