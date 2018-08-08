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
    /// Converter for <see cref="PagedServiceResourceDescriptionList" />.
    /// </summary>
    internal class PagedServiceResourceDescriptionListConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static PagedServiceResourceDescriptionList Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static PagedServiceResourceDescriptionList GetFromJsonProperties(JsonReader reader)
        {
            var continuationToken = default(ContinuationToken);
            var items = default(IEnumerable<ServiceResourceDescription>);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("ContinuationToken", propName, StringComparison.Ordinal) == 0)
                {
                    continuationToken = ContinuationTokenConverter.Deserialize(reader);
                }
                else if (string.Compare("Items", propName, StringComparison.Ordinal) == 0)
                {
                    items = reader.ReadList(ServiceResourceDescriptionConverter.Deserialize);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new PagedServiceResourceDescriptionList(
                continuationToken: continuationToken,
                items: items);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, PagedServiceResourceDescriptionList obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            if (obj.ContinuationToken != null)
            {
                writer.WriteProperty(obj.ContinuationToken, "ContinuationToken", ContinuationTokenConverter.Serialize);
            }

            if (obj.Items != null)
            {
                writer.WriteEnumerableProperty(obj.Items, "Items", ServiceResourceDescriptionConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
