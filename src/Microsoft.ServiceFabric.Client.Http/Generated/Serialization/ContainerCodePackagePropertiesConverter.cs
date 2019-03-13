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
    /// Converter for <see cref="ContainerCodePackageProperties" />.
    /// </summary>
    internal class ContainerCodePackagePropertiesConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ContainerCodePackageProperties Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ContainerCodePackageProperties GetFromJsonProperties(JsonReader reader)
        {
            var name = default(string);
            var image = default(string);
            var imageRegistryCredential = default(ImageRegistryCredential);
            var entrypoint = default(string);
            var commands = default(IEnumerable<string>);
            var environmentVariables = default(IEnumerable<EnvironmentVariable>);
            var settings = default(IEnumerable<Setting>);
            var labels = default(IEnumerable<ContainerLabel>);
            var endpoints = default(IEnumerable<EndpointProperties>);
            var resources = default(ResourceRequirements);
            var volumeRefs = default(IEnumerable<ContainerVolume>);
            var instanceView = default(ContainerInstanceView);
            var diagnostics = default(DiagnosticsRef);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("name", propName, StringComparison.Ordinal) == 0)
                {
                    name = reader.ReadValueAsString();
                }
                else if (string.Compare("image", propName, StringComparison.Ordinal) == 0)
                {
                    image = reader.ReadValueAsString();
                }
                else if (string.Compare("imageRegistryCredential", propName, StringComparison.Ordinal) == 0)
                {
                    imageRegistryCredential = ImageRegistryCredentialConverter.Deserialize(reader);
                }
                else if (string.Compare("entrypoint", propName, StringComparison.Ordinal) == 0)
                {
                    entrypoint = reader.ReadValueAsString();
                }
                else if (string.Compare("commands", propName, StringComparison.Ordinal) == 0)
                {
                    commands = reader.ReadList(JsonReaderExtensions.ReadValueAsString);
                }
                else if (string.Compare("environmentVariables", propName, StringComparison.Ordinal) == 0)
                {
                    environmentVariables = reader.ReadList(EnvironmentVariableConverter.Deserialize);
                }
                else if (string.Compare("settings", propName, StringComparison.Ordinal) == 0)
                {
                    settings = reader.ReadList(SettingConverter.Deserialize);
                }
                else if (string.Compare("labels", propName, StringComparison.Ordinal) == 0)
                {
                    labels = reader.ReadList(ContainerLabelConverter.Deserialize);
                }
                else if (string.Compare("endpoints", propName, StringComparison.Ordinal) == 0)
                {
                    endpoints = reader.ReadList(EndpointPropertiesConverter.Deserialize);
                }
                else if (string.Compare("resources", propName, StringComparison.Ordinal) == 0)
                {
                    resources = ResourceRequirementsConverter.Deserialize(reader);
                }
                else if (string.Compare("volumeRefs", propName, StringComparison.Ordinal) == 0)
                {
                    volumeRefs = reader.ReadList(ContainerVolumeConverter.Deserialize);
                }
                else if (string.Compare("instanceView", propName, StringComparison.Ordinal) == 0)
                {
                    instanceView = ContainerInstanceViewConverter.Deserialize(reader);
                }
                else if (string.Compare("diagnostics", propName, StringComparison.Ordinal) == 0)
                {
                    diagnostics = DiagnosticsRefConverter.Deserialize(reader);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ContainerCodePackageProperties(
                name: name,
                image: image,
                imageRegistryCredential: imageRegistryCredential,
                entrypoint: entrypoint,
                commands: commands,
                environmentVariables: environmentVariables,
                settings: settings,
                labels: labels,
                endpoints: endpoints,
                resources: resources,
                volumeRefs: volumeRefs,
                instanceView: instanceView,
                diagnostics: diagnostics);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ContainerCodePackageProperties obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Name, "name", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.Image, "image", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.Resources, "resources", ResourceRequirementsConverter.Serialize);
            if (obj.ImageRegistryCredential != null)
            {
                writer.WriteProperty(obj.ImageRegistryCredential, "imageRegistryCredential", ImageRegistryCredentialConverter.Serialize);
            }

            if (obj.Entrypoint != null)
            {
                writer.WriteProperty(obj.Entrypoint, "entrypoint", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.Commands != null)
            {
                writer.WriteEnumerableProperty(obj.Commands, "commands", (w, v) => writer.WriteStringValue(v));
            }

            if (obj.EnvironmentVariables != null)
            {
                writer.WriteEnumerableProperty(obj.EnvironmentVariables, "environmentVariables", EnvironmentVariableConverter.Serialize);
            }

            if (obj.Settings != null)
            {
                writer.WriteEnumerableProperty(obj.Settings, "settings", SettingConverter.Serialize);
            }

            if (obj.Labels != null)
            {
                writer.WriteEnumerableProperty(obj.Labels, "labels", ContainerLabelConverter.Serialize);
            }

            if (obj.Endpoints != null)
            {
                writer.WriteEnumerableProperty(obj.Endpoints, "endpoints", EndpointPropertiesConverter.Serialize);
            }

            if (obj.VolumeRefs != null)
            {
                writer.WriteEnumerableProperty(obj.VolumeRefs, "volumeRefs", ContainerVolumeConverter.Serialize);
            }

            if (obj.InstanceView != null)
            {
                writer.WriteProperty(obj.InstanceView, "instanceView", ContainerInstanceViewConverter.Serialize);
            }

            if (obj.Diagnostics != null)
            {
                writer.WriteProperty(obj.Diagnostics, "diagnostics", DiagnosticsRefConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
