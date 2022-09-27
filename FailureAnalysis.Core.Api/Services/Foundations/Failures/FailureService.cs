// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using FailureAnalysis.Core.Api.Brokers.Loggings;
using FailureAnalysis.Core.Api.Brokers.Storages;
using FailureAnalysis.Core.Api.Models.Failures;

namespace FailureAnalysis.Core.Api.Services.Foundations.Failures
{
    public partial class FailureService : IFailureService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public FailureService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Failure> AddFailureAsync(Failure failure) =>
        TryCatch(async () =>
        {
            ValidateFailureOnAdd(failure);

            return await this.storageBroker.InsertFailureAsync(failure);
        });
    }
}
