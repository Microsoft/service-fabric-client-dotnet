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
    /// Converter for <see cref="AutoScalingMetric" />.
    /// </summary>
    internal class AutoScalingMetricConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static AutoScalingMetric Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static AutoScalingMetric GetFromJsonProperties(JsonReader reader)
        {
            AutoScalingMetric obj = null;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("kind", StringComparison.Ordinal))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is kind.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("Resource", StringComparison.Ordinal))
            {
                obj = AutoScalingResourceMetricConverter.GetFromJsonProperties(reader);
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
        internal static void Serialize(JsonWriter writer, AutoScalingMetric obj)
        {
            var kind = obj.Kind;
            if (kind.Equals(AutoScalingMetricKind.Resource))
            {
                AutoScalingResourceMetricConverter.Serialize(writer, (AutoScalingResourceMetric)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown kind.");
            }
        }
    }
}
