// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using Xeptions;

namespace FailureAnalysis.Core.Api.Models.Exceptions
{
    public class FailedFailureServiceException : Xeption
    {
        public FailedFailureServiceException(Exception exception)
            : base(message: "Failed failure service exception occurred, contact support",
                  exception)
        { }
    }
}
