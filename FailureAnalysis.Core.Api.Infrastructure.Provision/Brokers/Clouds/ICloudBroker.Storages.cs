﻿// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using FailureAnalysis.Core.Api.Infrastructure.Provision.Models.Storages;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Sql.Fluent;

namespace FailureAnalysis.Core.Api.Infrastructure.Provision.Brokers.Clouds
{
    public partial interface ICloudBroker
    {
        ValueTask<ISqlServer> CreateSqlServerAsync(
            string sqlServerName,
            IResourceGroup resourceGroup);

        ValueTask<ISqlDatabase> CreateSqlDatabaseAsync(
            string sqlDatabaseName,
            ISqlServer sqlServer);

        SqlDatabaseAccess GetSqlDatabaseAccess();
    }
}
