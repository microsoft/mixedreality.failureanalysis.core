// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using FailureAnalysis.Core.Api.Models;
using FailureAnalysis.Core.Api.Models.Exceptions;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;

namespace FailureAnalysis.Core.Api.Tests.Unit.Services.Foundations.Failures
{
    public partial class FailureServiceTests
    {
        [Fact]
        public async Task ShouldThrowCriticalDependencyExceptionOnAddIfSqlErrorOccursAndLogItAsync()
        {
            // given
            Failure someFailure = CreateRandomFailure();
            SqlException sqlException = GetSqlException();

            var failedFailureStorageException =
                new FailedFailureStorageException(sqlException);

            var expectedFailureDependencyException =
                new FailureDependencyException(failedFailureStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertFailureAsync(It.IsAny<Failure>()))
                    .ThrowsAsync(sqlException);

            // when
            ValueTask<Failure> retrievedFailureTask =
                this.failureService.AddFailureAsync(someFailure);

            FailureDependencyException actualFailureDependencyException =
                await Assert.ThrowsAsync<FailureDependencyException>(
                    retrievedFailureTask.AsTask);

            // then
            actualFailureDependencyException.Should().BeEquivalentTo(
                expectedFailureDependencyException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFailureAsync(It.IsAny<Failure>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedFailureDependencyException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void ShouldThrowDependencyValidationExceptionOnAddIfFailureAlreadyExistsAndLogItAsync()
        {
            // given
            var someFailure = CreateRandomFailure();
            string randomMessage = GetRandomMessage();
            var duplicateKeyException = new DuplicateKeyException(randomMessage);

            var alreadyExistsFailureException = 
                new AlreadyExistsFailureException(duplicateKeyException);

            var expectedFailureDependencyValidationException =
                new FailureDependencyValidationException(alreadyExistsFailureException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertFailureAsync(It.IsAny<Failure>()))
                    .ThrowsAsync(duplicateKeyException);

            // when
            ValueTask<Failure> addFailureTask =
                this.failureService.AddFailureAsync(someFailure);

            FailureDependencyValidationException actualFailureDependencyValidationException
                = await Assert.ThrowsAsync<FailureDependencyValidationException>(addFailureTask.AsTask);

            // then
            actualFailureDependencyValidationException.Should().BeEquivalentTo(
                expectedFailureDependencyValidationException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFailureAsync(It.IsAny<Failure>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedFailureDependencyValidationException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
