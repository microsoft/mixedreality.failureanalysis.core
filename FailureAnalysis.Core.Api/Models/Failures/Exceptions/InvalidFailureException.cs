// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using Xeptions;

namespace FailureAnalysis.Core.Api.Models.Failures.Exceptions
{
    public class InvalidFailureException : Xeption
    {
        public InvalidFailureException()
            : base(message: "Invalid failure error occurred. Please fix the errors and try again.")
        { }
    }
}
