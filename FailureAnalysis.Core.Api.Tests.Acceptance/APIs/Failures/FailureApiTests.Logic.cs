// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using FailureAnalysis.Core.Api.Models.Failures;
using FluentAssertions;
using Force.DeepCloner;
using Xunit;

namespace FailureAnalysis.Core.Api.Tests.Acceptance.APIs.Failures
{
    public partial class FailureApiTests
    {
        [Fact]
        public async Task ShouldAddFailureAsync()
        {
            // given
            Failure randomFailure = CreateRandomFailure();
            var inputFailure = randomFailure;
            var expectedFailure = randomFailure.DeepClone();

            // when
            Failure actualFailure = 
                await this.failureAnalysisApiBroker.PostFailureAsync(inputFailure);

            // then
            actualFailure.Should().BeEquivalentTo(expectedFailure);
        }
    }
}
