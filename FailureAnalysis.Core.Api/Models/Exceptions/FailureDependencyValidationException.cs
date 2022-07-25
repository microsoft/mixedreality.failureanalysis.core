// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using Xeptions;

namespace FailureAnalysis.Core.Api.Models.Exceptions
{
    public class FailureDependencyValidationException : Xeption
    {
        public FailureDependencyValidationException(Xeption innerException) :
            base(message:"Failure dependency validation exception occurred, contact support",
                innerException)
        { }
    }
}
