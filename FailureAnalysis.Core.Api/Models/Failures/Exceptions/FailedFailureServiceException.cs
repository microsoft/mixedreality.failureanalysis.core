// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace FailureAnalysis.Core.Api.Models.Failures.Exceptions
{
    public class FailedFailureServiceException : Xeption
    {
        public FailedFailureServiceException(Exception exception)
            : base(message: "Failed failure service error occurred, please contact support.",
                  exception)
        { }
    }
}
