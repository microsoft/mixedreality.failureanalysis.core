// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using Xeptions;

namespace FailureAnalysis.Core.Api.Models.Failures.Exceptions
{
    public class AlreadyExistsFailureException : Xeption
    {
        public AlreadyExistsFailureException(Exception innerException)
            : base(message: "Failure with same Id already exists.",
                innerException)
        { }
    }
}
