// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FailureAnalysis.Core.Api.Brokers
{
    public partial class StorageBroker
    {
        public void ConfigureFailure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Failure>();
        }
    }
}
