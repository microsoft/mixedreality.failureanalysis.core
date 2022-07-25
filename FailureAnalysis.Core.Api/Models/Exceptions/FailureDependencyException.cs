// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using Xeptions;

namespace FailureAnalysis.Core.Api.Models.Exceptions
{
    public class FailureDependencyException : Xeption
    {
        public FailureDependencyException(Xeption innerException)
            : base(message: "Failure dependency error occurred, please contact support.",
                  innerException)
        { }
    }
}
