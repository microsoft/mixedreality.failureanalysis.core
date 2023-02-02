﻿// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models.ExternalFailures;
using System.Threading.Tasks;

namespace FailureAnalysis.Core.Api.Services.Foundations.ExternalFailures
{
    public interface IExternalFailureService
    {
        ValueTask<ExternalFailure> CreateExternalFailureAsync(ExternalFailure externalFailure);
    }
}