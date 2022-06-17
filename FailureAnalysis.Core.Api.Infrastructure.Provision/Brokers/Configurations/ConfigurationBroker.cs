﻿// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System.IO;
using FailureAnalysis.Core.Api.Infrastructure.Provision.Models.Configurations;
using Microsoft.Extensions.Configuration;

namespace FailureAnalysis.Core.Api.Infrastructure.Provision.Brokers.Configurations
{
    public class ConfigurationBroker : IConfigurationBroker
    {
        public CloudManagementConfiguration GetConfiguration()
        {
            IConfigurationRoot configrationRoot = new ConfigurationBuilder()
                .SetBasePath(basePath: Directory.GetCurrentDirectory())
                    .AddJsonFile(path: "appSettings.json", optional: false)
                        .Build();

            return configrationRoot.Get<CloudManagementConfiguration>();
        }
    }
}
