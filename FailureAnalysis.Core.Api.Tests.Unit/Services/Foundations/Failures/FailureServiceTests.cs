// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System;
using System.Linq.Expressions;
using FailureAnalysis.Core.Api.Brokers;
using FailureAnalysis.Core.Api.Brokers.Loggings;
using FailureAnalysis.Core.Api.Models;
using FailureAnalysis.Core.Api.Models.Exceptions;
using FailureAnalysis.Core.Api.Services.Foundations.Failures;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;

namespace FailureAnalysis.Core.Api.Tests.Unit.Services.Foundations.Failures
{
    public partial class FailureServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IFailureService failureService;

        public FailureServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.failureService = new FailureService(
                storageBroker: storageBrokerMock.Object,
                loggingBroker: loggingBrokerMock.Object);
        }

        private static Failure CreateRandomFailure() =>
            CreateFailureFiller().Create();

        private static Filler<Failure> CreateFailureFiller()
        {
            var filler = new Filler<Failure>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(GetRandomDateTimeOffset());

            return filler;
        }

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);
    }
}
