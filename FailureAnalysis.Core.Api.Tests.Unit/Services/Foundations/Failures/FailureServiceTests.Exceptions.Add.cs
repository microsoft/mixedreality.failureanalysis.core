// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using FailureAnalysis.Core.Api.Models.Failures;
using FailureAnalysis.Core.Api.Models.Failures.Exceptions;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
            
            var duplicateKeyException =
                new DuplicateKeyException(randomMessage);

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

            FailureDependencyValidationException actualFailureDependencyValidationException =
                await Assert.ThrowsAsync<FailureDependencyValidationException>(addFailureTask.AsTask);

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

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAddIfDbUpdateErrorsOccursAndLogItAsync()
        {
            // given
            Failure someFailure = CreateRandomFailure();

            var dbUpdateException =
                new DbUpdateException();

            var failedFailureStorageException =
                new FailedFailureStorageException(dbUpdateException);

            var expectedFailureDependencyException =
                new FailureDependencyException(failedFailureStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertFailureAsync(It.IsAny<Failure>()))
                    .ThrowsAsync(dbUpdateException);

            // when
            ValueTask<Failure> addFailureTask = this.failureService.AddFailureAsync(someFailure);

            FailureDependencyException actualFailureDependencyException =
                await Assert.ThrowsAsync<FailureDependencyException>(
                    addFailureTask.AsTask);

            // then
            actualFailureDependencyException.Should().BeEquivalentTo(
                expectedFailureDependencyException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFailureAsync(It.IsAny<Failure>()),
                        Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedFailureDependencyException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async void ShouldThrowServiceExceptionOnAddIfServiceErrorOccurredAndLogItAsync()
        {
            // given
            Failure someFailure = CreateRandomFailure();
            var exception = new Exception();

            var failedFailureServiceException =
                new FailedFailureServiceException(exception);

             var expectedFailureServiceException =
                new FailureServiceException(failedFailureServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertFailureAsync(It.IsAny<Failure>()))
                    .ThrowsAsync(exception);

            // when
            ValueTask<Failure> addFailureTask =
                this.failureService.AddFailureAsync(someFailure);

            FailureServiceException actualFailureServiceException =
                await Assert.ThrowsAsync<FailureServiceException>(addFailureTask.AsTask);

            // then
            actualFailureServiceException.Should().BeEquivalentTo(
                expectedFailureServiceException);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertFailureAsync(someFailure),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedFailureServiceException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
