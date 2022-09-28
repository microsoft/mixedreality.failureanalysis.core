// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using FailureAnalysis.Core.Api.Models.Failures;
using Microsoft.EntityFrameworkCore;

namespace FailureAnalysis.Core.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Failure> Failures { get; set; }

        public async ValueTask<Failure> InsertFailureAsync(Failure failure) =>
            await InsertAsync(failure);

        public IQueryable<Failure> SelectAllFailures() =>
            SelectAll<Failure>();

        public async ValueTask<Failure> SelectFailureByIdAsync(Guid failureId) =>
            await SelectAsync<Failure>(failureId);

        public async ValueTask<Failure> UpdateFailureAsync(Failure failure) =>
            await UpdateAsync(failure);
    }
}
