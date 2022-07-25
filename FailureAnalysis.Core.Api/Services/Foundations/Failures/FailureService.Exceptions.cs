// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models;
using FailureAnalysis.Core.Api.Models.Exceptions;
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
        }

        private FailureValidationException CreateAndLogValidationException(Xeption exception)
        {
            var failureValidationException = new FailureValidationException(exception);
            this.loggingBroker.LogError(exception: failureValidationException);

            return failureValidationException;
        }
    }
}
