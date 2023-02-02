// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Brokers.ExternalFailures;
using FailureAnalysis.Core.Api.Brokers.Loggings;
using FailureAnalysis.Core.Api.Models.ExternalFailures;
using System.Threading.Tasks;

namespace FailureAnalysis.Core.Api.Services.Foundations.ExternalFailures
{
    public class ExternalFailureService : IExternalFailureService
    {
        private readonly IExternalFailureBroker externalFailureBroker;
        private readonly ILoggingBroker loggingBroker;

        public ExternalFailureService(
            IExternalFailureBroker externalFailureBroker, 
            ILoggingBroker logging)
        {
            this.externalFailureBroker = externalFailureBroker;
            this.loggingBroker = logging;
        }

        public ValueTask<ExternalFailure> CreateExternalFailureAsync(ExternalFailure externalFailure)
        {
            throw new System.NotImplementedException();
        }
    }
}