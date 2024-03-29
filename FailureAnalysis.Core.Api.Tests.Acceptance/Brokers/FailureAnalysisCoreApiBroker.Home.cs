﻿// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System.Threading.Tasks;

namespace FailureAnalysis.Core.Api.Tests.Acceptance.Brokers
{
    public partial class FailureAnalysisCoreApiBroker
    {
        private const string HomeRelatativeUrl = "api/home";

        public async ValueTask<string> GetHomeMessageAsync() =>
            await this.apiFactoryClient.GetContentStringAsync(HomeRelatativeUrl);
    }
}