// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FailureAnalysis.Core.Api.Brokers
{
    public partial class StorageBroker
    {
        public DbSet<Failure> Failures { get; set; }

        public async ValueTask<Failure> InsertFailureAsync(Failure failure)
        {
            var broker = new StorageBroker(this.configuration);

            EntityEntry<Failure> failureEntityEntry =
                await broker.Failures.AddAsync(failure);

            await broker.SaveChangesAsync();

            return failureEntityEntry.Entity;
        }
    }
}
