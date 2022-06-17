// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System.Threading.Tasks;

namespace FailureAnalysis.Core.Api.Infrastructure.Provision.Services.Processings.CloudManagements
{
    public interface ICloudManagementProcessingService
    {
        ValueTask ProcessAsync();
    }
}
