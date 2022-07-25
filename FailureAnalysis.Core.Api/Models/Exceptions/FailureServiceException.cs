// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using Xeptions;

namespace FailureAnalysis.Core.Api.Models.Exceptions
{
    public class FailureServiceException : Xeption
    {
        public FailureServiceException(Xeption innerException)
            :base(message: "Failure Service error occurred, contact support",
                 innerException)
        { }
    }
}
