// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using EFxceptions.Models.Exceptions;
using FailureAnalysis.Core.Api.Models.Failures;
using FailureAnalysis.Core.Api.Models.Failures.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xeptions;

namespace FailureAnalysis.Core.Api.Services.Foundations.Failures
{
    public partial class FailureService
    {
        private delegate ValueTask<Failure> ReturningFailureFunction();
        private async ValueTask<Failure> TryCatch(ReturningFailureFunction returningFailureFunction)
        {
            try
            {
                return await returningFailureFunction();
            }
            catch (NullFailureException nullFailureException)
            {
                throw CreateAndLogValidationException(nullFailureException);
            }
            catch (InvalidFailureException invalidFailureException)
            {
                throw CreateAndLogValidationException(invalidFailureException);
            }
            catch (SqlException sqlException)
            {
                var failedFailureStorageException =
                    new FailedFailureStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedFailureStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsFailureException =
                    new AlreadyExistsFailureException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExistsFailureException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedFailureStorageException =
                    new FailedFailureStorageException(dbUpdateException);

                throw CreateAndLogDependencyException(failedFailureStorageException);
            }
            catch (Exception exception)
            {
                var failedFailureServiceException =
                    new FailedFailureServiceException(exception);

                throw CreateAndLogServiceException(failedFailureServiceException);
            }
        }

        private Exception CreateAndLogDependencyException(
            FailedFailureStorageException failedFailureStorageException)
        {
            var failureDependencyException =
                new FailureDependencyException(failedFailureStorageException);

            this.loggingBroker.LogError(failureDependencyException);

            return failureDependencyException;
        }

        private Exception CreateAndLogCriticalDependencyException(
            FailedFailureStorageException failedFailureStorageException)
        {
            var failureDependencyException =
                new FailureDependencyException(failedFailureStorageException);

            this.loggingBroker.LogCritical(failureDependencyException);

            return failureDependencyException;
        }

        private FailureValidationException CreateAndLogValidationException(Xeption exception)
        {
            var failureValidationException = new FailureValidationException(exception);
            this.loggingBroker.LogError(exception: failureValidationException);

            return failureValidationException;
        }

        private FailureDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var failureDependencyValidationException = new FailureDependencyValidationException(exception);
            this.loggingBroker.LogError(exception: failureDependencyValidationException);

            return failureDependencyValidationException;
        }

        private FailureServiceException CreateAndLogServiceException(Xeption exception)
        {
            var failureServiceException = new FailureServiceException(exception);
            this.loggingBroker.LogError(failureServiceException);

            return failureServiceException;
        }


    }
}
