// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

namespace FailureAnalysis.Core.Api.Models
{
    public class LiveFailure
    {
        public Guid FailureId { get; set; }
        public LiveData LiveData { get; set; }
    }
}
