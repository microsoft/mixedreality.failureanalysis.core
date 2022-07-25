// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System;
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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnAddIfFailureIsInvalidAndLogItAsync(
            string invalidString)
        {
            // given
            var invalidFailure = new Failure
            {
                State = invalidString,
                Title = invalidString,
                AssignTo = invalidString,
                FailureArea = invalidString,
                SprintName = invalidString,
                FailureIdString = invalidString,
                Description = invalidString,
                ErrorMessage = invalidString,
                Source = invalidString
            };

            var invalidFailureException = new InvalidFailureException();

            invalidFailureException.AddData(
                key: nameof(Failure.Id),
                values: "Id is required");

            invalidFailureException.AddData(
                key: nameof(Failure.ProfileId),
                values: "Id is required");

            invalidFailureException.AddData(
                key: nameof(Failure.State),
                values: "Text is required");

            invalidFailureException.AddData(
                key: nameof(Failure.Title),
                values: "Text is required");

            invalidFailureException.AddData(
                key: nameof(Failure.AssignTo),
                values: "Text is required");

            invalidFailureException.AddData(
                key: nameof(Failure.FailureArea),
                values: "Text is required");

            invalidFailureException.AddData(
                key: nameof(Failure.SprintName),
                values: "Text is required");

            invalidFailureException.AddData(
                key: nameof(Failure.FailureIdString),
                values: "Text is required");

            invalidFailureException.AddData(
                key: nameof(Failure.Description),
                values: "Text is required");

            invalidFailureException.AddData(
                key: nameof(Failure.ErrorMessage),
                values: "Text is required");

            invalidFailureException.AddData(
                key: nameof(Failure.Source),
                values: "Text is required");

            invalidFailureException.AddData(
                key: nameof(Failure.CreatedDate),
                values: "Date is required");

            invalidFailureException.AddData(
                key: nameof(Failure.UpdatedDate),
                values: "Date is required");

            var expectedFailureValidationException =
                new FailureValidationException(invalidFailureException);

            // when
            ValueTask<Failure> addFailureTask =
                this.failureService.AddFailureAsync(invalidFailure);

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

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task 
            ShouldThrowFailureValidationExceptionOnAddIfFailureSeverityOrPriorityIsInvalidAndLogItAsync()
        {
            // given
            Failure randomFailure = CreateRandomFailure();
            var invalidFailure = randomFailure;
            invalidFailure.Severity = GetInvalidEnum<Severity>();
            invalidFailure.Priority = GetInvalidEnum<Priority>();

            var invalidFailureException = new InvalidFailureException();

            invalidFailureException.AddData(
                key: nameof(Failure.Severity),
                values: "Value is not recognized");

            invalidFailureException.AddData(
                key: nameof(Failure.Priority),
                values: "Value is not recognized");

            var expectedFailureValidationException = 
                new FailureValidationException(invalidFailureException);

            // when
            ValueTask<Failure> addFailureTask =
                this.failureService.AddFailureAsync(invalidFailure);

            FailureValidationException actualFailureValidationException =
                await Assert.ThrowsAsync<FailureValidationException>(addFailureTask.AsTask);

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

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
