// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models.Failures;

namespace FailureAnalysis.Core.Api.Brokers
{
    public partial interface IStorageBroker
    {
        ValueTask<Failure> InsertFailureAsync(Failure failure);
    }
}
