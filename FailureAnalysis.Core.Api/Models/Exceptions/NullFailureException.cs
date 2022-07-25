// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using Xeptions;

namespace FailureAnalysis.Core.Api.Models.Exceptions
{
    public class NullFailureException : Xeption
    {
        public NullFailureException() :
            base(message: "Failure is Null.")
        { }
    }
}
