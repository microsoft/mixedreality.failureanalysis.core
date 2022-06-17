// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using FailureAnalysis.Core.Api.Tests.Acceptance.Brokers;
using FluentAssertions;
using Xunit;

namespace FailureAnalysis.Core.Api.Tests.Acceptance.APIs.Homes
{
    [Collection(nameof(ApiTestCollection))]
    public class HomeApiTests
    {
        private readonly FailureAnalysisCoreApiBroker dmxGatekeeperApiBroker;

        public HomeApiTests(FailureAnalysisCoreApiBroker dmxGatekeeperApiBroker) =>
            this.dmxGatekeeperApiBroker = dmxGatekeeperApiBroker;

        [Fact]
        public async Task ShouldReturnHomeMessageAsync()
        {
            string expectedMessage = "Hello, Mario. The princess is in another castle!";

            string actualMessage =
                await this.dmxGatekeeperApiBroker.GetHomeMessageAsync();

            actualMessage.Should().BeEquivalentTo(expectedMessage);
        }
    }
}