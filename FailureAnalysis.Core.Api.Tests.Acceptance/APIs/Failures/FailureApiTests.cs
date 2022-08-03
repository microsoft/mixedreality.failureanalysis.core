// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System;
using FailureAnalysis.Core.Api.Models.Failures;
using FailureAnalysis.Core.Api.Tests.Acceptance.Brokers;
using Tynamix.ObjectFiller;
using Xunit;

namespace FailureAnalysis.Core.Api.Tests.Acceptance.APIs.Failures
{
    [Collection(nameof(ApiTestCollection))]
    public partial class FailureApiTests
    {
        private readonly FailureAnalysisCoreApiBroker failureAnalysisApiBroker;

        public FailureApiTests(FailureAnalysisCoreApiBroker failureAnalysisApiBroker) =>
            this.failureAnalysisApiBroker = failureAnalysisApiBroker;

        private static Failure CreateRandomFailure() =>
            CreateRandomFailureFiller().Create();

        private static Filler<Failure> CreateRandomFailureFiller()
        {
            var filler = new Filler<Failure>();
            DateTimeOffset now = DateTimeOffset.UtcNow;
            Guid id = Guid.NewGuid();

            filler.Setup()
                .OnProperty(failure => failure.Id).Use(id)
                .OnProperty(failure => failure.ProfileId).Use(id)
                .OnProperty(failure => failure.CreatedDate).Use(now)
                .OnProperty(failure => failure.UpdatedDate).Use(now);

            return filler;
        }
    }
}
