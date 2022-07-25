﻿// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models;
using FailureAnalysis.Core.Api.Models.Exceptions;
using Microsoft.Data.SqlClient;
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
                var failedFailureStorageException = new FailedFailureStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedFailureStorageException);
            }
        }

        private Exception CreateAndLogCriticalDependencyException(FailedFailureStorageException failedFailureStorageException)
        {
            var failureDependencyException = new FailureDependencyException(failedFailureStorageException);
            this.loggingBroker.LogCritical(failureDependencyException);

            return failureDependencyException;
        }

        private FailureValidationException CreateAndLogValidationException(Xeption exception)
        {
            var failureValidationException = new FailureValidationException(exception);
            this.loggingBroker.LogError(exception: failureValidationException);

            return failureValidationException;
        }
    }
}