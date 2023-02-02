// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System;
using Newtonsoft.Json;

namespace FailureAnalysis.Core.Api.Models.ExternalFailures
{
    public class ExternalFailure
    {
        public Guid Id { get; set; }

        [JsonProperty("System.ID")]
        public string ExternalId { get; set; }

        [JsonProperty("System.CreatedBy")]
        public Guid ProfileId { get; set; }

        [JsonProperty("System.State")]
        public string State { get; set; }

        [JsonProperty("System.Title")]
        public string Title { get; set; }

        [JsonProperty("System.AssignedTo")]
        public string AssignTo { get; set; }

        [JsonProperty("System.AreaPath")]
        public string FailureArea { get; set; }

        [JsonProperty("System.IterationPath")]
        public string SprintName { get; set; }

        [JsonProperty("OSG.FailureHash")]
        public string FailureIdString { get; set; }

        public DateTime? FailureDateTime { get; set; }

        [JsonProperty("System.CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("System.ChangedDate")]
        public DateTimeOffset UpdatedDate { get; set; }

        [JsonProperty("Microsoft.VSTS.TCM.ReproSteps")]
        public string Description { get; set; }

        [JsonProperty("Microsoft.VSTS.TCM.ReproSteps")]
        public string ErrorMessage { get; set; }

        [JsonProperty("Microsoft.VSTS.Build.FoundIn")]
        public string Source { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.CustomString")]
        public string AdditionalData { get; set; }

        [JsonProperty("OSG.NumInstances")]
        public int HitCount { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Priority")]
        public Priority Priority { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Severity")]
        public Severity Severity { get; set; }
    }
}