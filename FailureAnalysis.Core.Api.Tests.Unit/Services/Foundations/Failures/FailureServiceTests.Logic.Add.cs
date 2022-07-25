// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using FailureAnalysis.Core.Api.Models;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace FailureAnalysis.Core.Api.Tests.Unit.Services.Foundations.Failures
{
    public partial class FailureServiceTests
    {
        [Fact]
        public async Task ShouldAddFailureAsync()
        {
            // given
            Failure randomFailure = CreateRandomFailure();
            Failure inputFailure = randomFailure;
            Failure insertedFailure = inputFailure;
            Failure expectedFailure = insertedFailure.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertFailureAsync(inputFailure))
                    .ReturnsAsync(insertedFailure);

            // when
            Failure actualFailure =
                await this.failureService.AddFailureAsync(inputFailure);

            // then
            actualFailure.Should().BeEquivalentTo(expectedFailure);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFailureAsync(inputFailure),
                    Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
