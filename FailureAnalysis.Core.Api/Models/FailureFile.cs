// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

namespace FailureAnalysis.Core.Api.Models
{
    public class FailureFile
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}