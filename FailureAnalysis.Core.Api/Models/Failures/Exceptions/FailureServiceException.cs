﻿// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using Xeptions;

namespace FailureAnalysis.Core.Api.Models.Failures.Exceptions
{
    public class FailureServiceException : Xeption
    {
        public FailureServiceException(Xeption innerException)
            : base(message: "Failure Service error occurred, please contact support",
                 innerException)
        { }
    }
}
