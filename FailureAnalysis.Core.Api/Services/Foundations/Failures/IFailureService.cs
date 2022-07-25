﻿// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models;

namespace FailureAnalysis.Core.Api.Services.Foundations.Failures
{
    public interface IFailureService
    {
        ValueTask<Failure> AddFailureAsync(Failure failure);
    }
}
