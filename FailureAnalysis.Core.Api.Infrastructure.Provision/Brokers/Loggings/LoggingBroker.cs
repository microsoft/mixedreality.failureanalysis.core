// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System;

namespace FailureAnalysis.Core.Api.Infrastructure.Provision.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        public void LogActivity(string message) =>
            Console.WriteLine(message);
    }
}
