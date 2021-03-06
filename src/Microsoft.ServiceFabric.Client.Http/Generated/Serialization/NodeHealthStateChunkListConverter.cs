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
    /// Converter for <see cref="NodeHealthStateChunkList" />.
    /// </summary>
    internal class NodeHealthStateChunkListConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static NodeHealthStateChunkList Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static NodeHealthStateChunkList GetFromJsonProperties(JsonReader reader)
        {
            var totalCount = default(long?);
            var items = default(IEnumerable<NodeHealthStateChunk>);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("TotalCount", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    totalCount = reader.ReadValueAsLong();
                }
                else if (string.Compare("Items", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    items = reader.ReadList(NodeHealthStateChunkConverter.Deserialize);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new NodeHealthStateChunkList(
                totalCount: totalCount,
                items: items);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, NodeHealthStateChunkList obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            if (obj.TotalCount != null)
            {
                writer.WriteProperty(obj.TotalCount, "TotalCount", JsonWriterExtensions.WriteLongValue);
            }

            if (obj.Items != null)
            {
                writer.WriteEnumerableProperty(obj.Items, "Items", NodeHealthStateChunkConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
