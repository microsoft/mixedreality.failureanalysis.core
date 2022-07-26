// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

namespace FailureAnalysis.Core.Api.Models.Failures
{
    public class Failure
    {
        public Guid Id { get; set; }
        public Guid ProfileId { get; set; }
        public string State { get; set; }
        public string Title { get; set; }
        public string AssignTo { get; set; }
        public string FailureArea { get; set; }
        public string SprintName { get; set; }
        public string FailureIdString { get; set; }
        public DateTime? FailureDateTime { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public string Description { get; set; }
        public string ErrorMessage { get; set; }
        public string Source { get; set; }
        public Priority Priority { get; set; }
        public Severity Severity { get; set; }
    }
}
