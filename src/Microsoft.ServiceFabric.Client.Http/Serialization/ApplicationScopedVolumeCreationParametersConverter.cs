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
    /// Converter for <see cref="ApplicationScopedVolumeCreationParameters" />.
    /// </summary>
    internal class ApplicationScopedVolumeCreationParametersConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationScopedVolumeCreationParameters Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationScopedVolumeCreationParameters GetFromJsonProperties(JsonReader reader)
        {
            ApplicationScopedVolumeCreationParameters obj = null;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("kind", StringComparison.Ordinal))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is kind.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("ServiceFabricVolumeDisk", StringComparison.Ordinal))
            {
                obj = ApplicationScopedVolumeCreationParametersServiceFabricVolumeDiskConverter.GetFromJsonProperties(reader);
            }
            else
            {
                throw new InvalidOperationException("Unknown kind.");
            }

            return obj;
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ApplicationScopedVolumeCreationParameters obj)
        {
            var kind = obj.Kind;
            if (kind.Equals(ApplicationScopedVolumeKind.ServiceFabricVolumeDisk))
            {
                ApplicationScopedVolumeCreationParametersServiceFabricVolumeDiskConverter.Serialize(writer, (ApplicationScopedVolumeCreationParametersServiceFabricVolumeDisk)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown kind.");
            }
        }
    }
}
