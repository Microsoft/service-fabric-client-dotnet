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
    /// Converter for <see cref="UsageInfo" />.
    /// </summary>
    internal class UsageInfoConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static UsageInfo Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static UsageInfo GetFromJsonProperties(JsonReader reader)
        {
            var usedSpace = default(string);
            var fileCount = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("UsedSpace", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    usedSpace = reader.ReadValueAsString();
                }
                else if (string.Compare("FileCount", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    fileCount = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new UsageInfo(
                usedSpace: usedSpace,
                fileCount: fileCount);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, UsageInfo obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            if (obj.UsedSpace != null)
            {
                writer.WriteProperty(obj.UsedSpace, "UsedSpace", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.FileCount != null)
            {
                writer.WriteProperty(obj.FileCount, "FileCount", JsonWriterExtensions.WriteStringValue);
            }

            writer.WriteEndObject();
        }
    }
}
