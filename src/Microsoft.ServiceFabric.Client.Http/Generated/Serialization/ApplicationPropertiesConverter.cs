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
    /// Converter for <see cref="ApplicationProperties" />.
    /// </summary>
    internal class ApplicationPropertiesConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationProperties Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationProperties GetFromJsonProperties(JsonReader reader)
        {
            var description = default(string);
            var debugParams = default(string);
            var services = default(IEnumerable<ServiceResourceDescription>);
            var healthState = default(HealthState?);
            var unhealthyEvaluation = default(string);
            var status = default(ApplicationResourceStatus?);
            var statusDetails = default(string);
            var serviceNames = default(IEnumerable<string>);
            var diagnostics = default(DiagnosticsDescription);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("description", propName, StringComparison.Ordinal) == 0)
                {
                    description = reader.ReadValueAsString();
                }
                else if (string.Compare("debugParams", propName, StringComparison.Ordinal) == 0)
                {
                    debugParams = reader.ReadValueAsString();
                }
                else if (string.Compare("services", propName, StringComparison.Ordinal) == 0)
                {
                    services = reader.ReadList(ServiceResourceDescriptionConverter.Deserialize);
                }
                else if (string.Compare("healthState", propName, StringComparison.Ordinal) == 0)
                {
                    healthState = HealthStateConverter.Deserialize(reader);
                }
                else if (string.Compare("unhealthyEvaluation", propName, StringComparison.Ordinal) == 0)
                {
                    unhealthyEvaluation = reader.ReadValueAsString();
                }
                else if (string.Compare("status", propName, StringComparison.Ordinal) == 0)
                {
                    status = ApplicationResourceStatusConverter.Deserialize(reader);
                }
                else if (string.Compare("statusDetails", propName, StringComparison.Ordinal) == 0)
                {
                    statusDetails = reader.ReadValueAsString();
                }
                else if (string.Compare("serviceNames", propName, StringComparison.Ordinal) == 0)
                {
                    serviceNames = reader.ReadList(JsonReaderExtensions.ReadValueAsString);
                }
                else if (string.Compare("diagnostics", propName, StringComparison.Ordinal) == 0)
                {
                    diagnostics = DiagnosticsDescriptionConverter.Deserialize(reader);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ApplicationProperties(
                description: description,
                debugParams: debugParams,
                services: services,
                healthState: healthState,
                unhealthyEvaluation: unhealthyEvaluation,
                status: status,
                statusDetails: statusDetails,
                serviceNames: serviceNames,
                diagnostics: diagnostics);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ApplicationProperties obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.HealthState, "healthState", HealthStateConverter.Serialize);
            writer.WriteProperty(obj.Status, "status", ApplicationResourceStatusConverter.Serialize);
            if (obj.Description != null)
            {
                writer.WriteProperty(obj.Description, "description", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.DebugParams != null)
            {
                writer.WriteProperty(obj.DebugParams, "debugParams", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.Services != null)
            {
                writer.WriteEnumerableProperty(obj.Services, "services", ServiceResourceDescriptionConverter.Serialize);
            }

            if (obj.UnhealthyEvaluation != null)
            {
                writer.WriteProperty(obj.UnhealthyEvaluation, "unhealthyEvaluation", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.StatusDetails != null)
            {
                writer.WriteProperty(obj.StatusDetails, "statusDetails", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.ServiceNames != null)
            {
                writer.WriteEnumerableProperty(obj.ServiceNames, "serviceNames", (w, v) => writer.WriteStringValue(v));
            }

            if (obj.Diagnostics != null)
            {
                writer.WriteProperty(obj.Diagnostics, "diagnostics", DiagnosticsDescriptionConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
