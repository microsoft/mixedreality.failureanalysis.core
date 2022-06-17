﻿// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace FailureAnalysis.Core.Api.Infrastructure.Provision.Brokers.Clouds
{
    public partial interface ICloudBroker
    {
        ValueTask<IAppServicePlan> CreatePlanAsync(string planName, IResourceGroup resourceGroup);
    }
}
