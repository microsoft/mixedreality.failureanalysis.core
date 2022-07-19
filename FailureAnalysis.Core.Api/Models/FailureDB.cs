// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

namespace FailureAnalysis.Core.Api.Models
{
    public class FailureDB<TRequiredFields>
    {
        public string FailureId { get; set; }
        public TRequiredFields RequiredFields { get; set; }
        public Failure Failure { get; set; }
    }
}
