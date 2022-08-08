// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using FailureAnalysis.Core.Api.Models.Failures;

namespace FailureAnalysis.Core.Api.Tests.Acceptance.Brokers
{
    public partial class FailureAnalysisCoreApiBroker
    {
        private const string failuresApiRelativeUrl = "api/failures";

        public async ValueTask<Failure> PostFailureAsync(Failure failure)
        {
            return await this.apiFactoryClient.PostContentAsync<Failure>(
                relativeUrl: $"{failuresApiRelativeUrl}",
                content: failure);
        }
    }
}
