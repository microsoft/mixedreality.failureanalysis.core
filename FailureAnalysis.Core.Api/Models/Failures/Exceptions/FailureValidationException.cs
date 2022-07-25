// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using Xeptions;

namespace FailureAnalysis.Core.Api.Models.Failures.Exceptions
{
    public class FailureValidationException : Xeption
    {
        public FailureValidationException(Xeption exception) :
            base(message: "Failure validation exception occurred, contact support.",
                exception)
        { }
    }
}
