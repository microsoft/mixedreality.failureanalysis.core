// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models.ExternalFailures;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace FailureAnalysis.Core.Api.Tests.Unit.Services.Foundations.ExternalFailures
{
    public partial class ExternalFailureServiceTests
    {
        [Fact]
        public async Task ShouldCreateExternalFailureAsync()
        {
            // given
            ExternalFailure randomFailure = CreateRandomExternalFailure();
            var inputFailure = randomFailure;
            var createdFailure = inputFailure.DeepClone();
            var expectedFailure = inputFailure.DeepClone();

            this.externalFailureBroker.Setup(broker =>
                broker.CreateExternalFailureAsync(It.IsAny<ExternalFailure>()))
                    .ReturnsAsync(createdFailure);

            // when
            ExternalFailure actualExternalFailure = 
                await this.externalFailureService.CreateExternalFailureAsync(inputFailure);

            // then
            actualExternalFailure.Should().BeEquivalentTo(expectedFailure);

            this.externalFailureBroker.Verify(broker =>
                broker.CreateExternalFailureAsync(inputFailure),
                    Times.Once());

            this.externalFailureBroker.VerifyNoOtherCalls();
            this.loggingBroker.VerifyNoOtherCalls();
        }
    }
}