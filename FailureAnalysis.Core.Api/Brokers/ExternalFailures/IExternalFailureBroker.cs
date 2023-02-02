// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models.ExternalFailures;
using System.Threading.Tasks;

namespace FailureAnalysis.Core.Api.Brokers.ExternalFailures
{
    public interface IExternalFailureBroker
    {
        ValueTask<ExternalFailure> CreateExternalFailureAsync(ExternalFailure externalFailure);
    }
}
