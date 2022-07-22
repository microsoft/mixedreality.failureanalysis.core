// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models;

namespace FailureAnalysis.Core.Api.Services.Foundations.Failures
{
    public class FailureService : IFailureService
    {
        public ValueTask<Failure> AddFailureAsync(Failure failure) =>
            throw new NotImplementedException();
    }
}
