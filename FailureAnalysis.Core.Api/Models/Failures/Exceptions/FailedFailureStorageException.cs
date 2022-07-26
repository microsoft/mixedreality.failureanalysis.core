// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using Xeptions;

namespace FailureAnalysis.Core.Api.Models.Failures.Exceptions
{
    public class FailedFailureStorageException : Xeption
    {
        public FailedFailureStorageException(Exception innerException)
            : base(message: "Failed failure storage error occurred, please contact support.",
                  innerException)
        { }
    }
}
