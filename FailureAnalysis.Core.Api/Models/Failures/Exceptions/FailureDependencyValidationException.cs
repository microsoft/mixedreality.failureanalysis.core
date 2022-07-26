// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using Xeptions;

namespace FailureAnalysis.Core.Api.Models.Failures.Exceptions
{
    public class FailureDependencyValidationException : Xeption
    {
        public FailureDependencyValidationException(Xeption innerException)
            : base(message: "Failure dependency validation error occurred, please contact support",
                innerException)
        { }
    }
}
