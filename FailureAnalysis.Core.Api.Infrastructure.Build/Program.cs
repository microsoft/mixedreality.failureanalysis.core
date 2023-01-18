// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Infrastructure.Build.Services.ScriptGenerations;

var scriptGenerationService = new ScriptGenerationService();
scriptGenerationService.GenerateBuildScript();
scriptGenerationService.GenerateProvisionScript();