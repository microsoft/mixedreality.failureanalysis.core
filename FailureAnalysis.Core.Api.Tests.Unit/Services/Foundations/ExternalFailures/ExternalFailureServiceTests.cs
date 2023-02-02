// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Brokers.ExternalFailures;
using FailureAnalysis.Core.Api.Brokers.Loggings;
using FailureAnalysis.Core.Api.Models.ExternalFailures;
using FailureAnalysis.Core.Api.Services.Foundations.ExternalFailures;
using Moq;
using System;
using Tynamix.ObjectFiller;

namespace FailureAnalysis.Core.Api.Tests.Unit.Services.Foundations.ExternalFailures
{
    public partial class ExternalFailureServiceTests
    {
        private readonly Mock<IExternalFailureBroker> externalFailureBroker;
        private readonly Mock<ILoggingBroker> loggingBroker;
        private readonly IExternalFailureService externalFailureService;

        public ExternalFailureServiceTests()
        {
            this.externalFailureBroker = new Mock<IExternalFailureBroker>();
            this.loggingBroker = new Mock<ILoggingBroker>();

            this.externalFailureService = new ExternalFailureService(
                this.externalFailureBroker.Object,
                this.loggingBroker.Object);
        }

        private ExternalFailure CreateRandomExternalFailure() =>
            CreateExternalFailureFiller().Create();

        private Filler<ExternalFailure> CreateExternalFailureFiller()
        {
            var filler = new Filler<ExternalFailure>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(GetRandomDateTime());

            return filler;
        }

        private DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();
    }
}
