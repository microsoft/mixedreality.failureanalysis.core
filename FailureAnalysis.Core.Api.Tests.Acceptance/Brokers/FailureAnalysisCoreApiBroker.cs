// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;

namespace FailureAnalysis.Core.Api.Tests.Acceptance.Brokers
{
    public partial class FailureAnalysisCoreApiBroker
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private readonly HttpClient httpClient;
        private readonly IRESTFulApiFactoryClient apiFactoryClient;

        public FailureAnalysisCoreApiBroker()
        {
            this.webApplicationFactory = new WebApplicationFactory<Startup>();
            this.httpClient = this.webApplicationFactory.CreateClient();
            this.apiFactoryClient = new RESTFulApiFactoryClient(this.httpClient);
        }
    }
}