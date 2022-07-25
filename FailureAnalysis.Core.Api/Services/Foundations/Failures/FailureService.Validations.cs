// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models;
using FailureAnalysis.Core.Api.Models.Exceptions;

namespace FailureAnalysis.Core.Api.Services.Foundations.Failures
{
    public partial class FailureService
    {
        private void ValidateFailureOnAdd(Failure failure) =>
            ValidateFailureIsNotNull(failure);

        private void ValidateFailureIsNotNull(Failure failure)
        {
            if(failure is null)
            {
                throw new NullFailureException();
            }
        }
    }
}
