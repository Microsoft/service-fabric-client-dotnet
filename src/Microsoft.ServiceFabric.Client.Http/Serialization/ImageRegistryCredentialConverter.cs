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
    /// Converter for <see cref="ImageRegistryCredential" />.
    /// </summary>
    internal class ImageRegistryCredentialConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ImageRegistryCredential Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ImageRegistryCredential GetFromJsonProperties(JsonReader reader)
        {
            var server = default(string);
            var username = default(string);
            var password = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("server", propName, StringComparison.Ordinal) == 0)
                {
                    server = reader.ReadValueAsString();
                }
                else if (string.Compare("username", propName, StringComparison.Ordinal) == 0)
                {
                    username = reader.ReadValueAsString();
                }
                else if (string.Compare("password", propName, StringComparison.Ordinal) == 0)
                {
                    password = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ImageRegistryCredential(
                server: server,
                username: username,
                password: password);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ImageRegistryCredential obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Server, "server", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.Username, "username", JsonWriterExtensions.WriteStringValue);
            if (obj.Password != null)
            {
                writer.WriteProperty(obj.Password, "password", JsonWriterExtensions.WriteStringValue);
            }

            writer.WriteEndObject();
        }
    }
}
