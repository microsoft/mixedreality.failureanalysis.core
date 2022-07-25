// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using FailureAnalysis.Core.Api.Models;
using FailureAnalysis.Core.Api.Models.Exceptions;
using FluentAssertions;
using Moq;
using Xunit;

namespace FailureAnalysis.Core.Api.Tests.Unit.Services.Foundations.Failures
{
    public partial class FailureServiceTests
    {
        [Fact]
        public async void ShouldThrowValidationExceptionOnAddIfNullAndLogItAsync()
        {
            // given
            Failure nullFailure = null;
            var nullFailureException = new NullFailureException();

            var expectedFailureValidationException =
                new FailureValidationException(nullFailureException);

            // when
            ValueTask<Failure> addFailureTask = this.failureService.AddFailureAsync(nullFailure);

            FailureValidationException actualFailureValidationException =
                await Assert.ThrowsAsync<FailureValidationException>(
                    addFailureTask.AsTask);

            // then
            actualFailureValidationException.Should().BeEquivalentTo(
                expectedFailureValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedFailureValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFailureAsync(It.IsAny<Failure>()),
                    Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
