// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using System.Collections.Generic;

namespace FailureAnalysis.Core.Api.Infrastructure.Build.Services.ScriptGenerations
{
    public class ScriptGenerationService
    {
        private readonly ADotNetClient adotNetClient;

        public ScriptGenerationService() =>
            this.adotNetClient = new ADotNetClient();

        public void GenerateBuildScript()
        {
            var githubPipeline = new GithubPipeline
            {
                Name = "FailureAnalysis Core Build",

                OnEvents = new Events
                {
                    Push = new PushEvent
                    {
                        Branches = new string[] { "main" }
                    },

                    PullRequest = new PullRequestEvent
                    {
                        Branches = new string[] { "main" }
                    }
                },

                Jobs = new Jobs
                {
                    Build = new BuildJob
                    {
                        RunsOn = BuildMachines.Windows2022,

                        Steps = new List<GithubTask>
                        {
                            new CheckoutTaskV2
                            {
                                Name = "Checking out Code"
                            },

                            new SetupDotNetTaskV1
                            {
                                Name = "Installing .NET",

                                TargetDotNetVersion = new TargetDotNetVersion
                                {
                                    DotNetVersion = "7.0.101"
                                }
                            },

                            new RestoreTask
                            {
                                Name = "Restoring Packages"
                            },

                            new DotNetBuildTask
                            {
                                Name = "Building Project(s)"
                            },

                            new TestTask
                            {
                                Name = "Running Tests"
                            }
                        }
                    }
                }
            };

            adotNetClient.SerializeAndWriteToFile(
                githubPipeline,
                path: "../../../../.github/workflows/dotnet.yml");
        }

        public void GenerateProvisionScript()
        {
            var githubPipeline = new GithubPipeline
            {
                Name = "Provision Failure Analysis Core",

                OnEvents = new Events
                {
                    Push = new PushEvent
                    {
                        Branches = new string[] { "main" }
                    },

                    PullRequest = new PullRequestEvent
                    {
                        Branches = new string[] { "main" }
                    }
                },
                Jobs = new Jobs
                {
                    Build = new BuildJob
                    {
                        RunsOn = BuildMachines.WindowsLatest,

                        EnvironmentVariables = new Dictionary<string, string>
                        {
                            { "AzureSubscriptionId", "${{ secrets.AZURE_SUBSCRIPTIONID }}"},
                            { "AzureTenantId", "${{ secrets.AZURE_TENANTID }}" },
                            { "AzureAdAppProvisionClientId", "${{ secrets.AZURE_ADAPP_PROVISION_CLIENTID }}" },
                            { "AzureAdAppProvisionClientSecret", "${{ secrets.AZURE_ADAPP_PROVISION_CLIENTSECRET }}" },
                            { "AzureSqlServerAdminName", "${{ secrets.AZURE_SQLSERVER_ADMINNAME }}" },
                            { "AzureSqlServerAdminAccess", "${{ secrets.AZURE_SQLSERVER_ADMINACCESS }}" }
                        },

                        Steps = new List<GithubTask>
                        {
                            new CheckoutTaskV2
                            {
                                Name = "Checking out code"
                            },

                            new SetupDotNetTaskV1
                            {
                                Name = "Setup Dot Net Version",

                                TargetDotNetVersion = new TargetDotNetVersion
                                {
                                    DotNetVersion = "7.0.101"
                                }
                            },

                            new RestoreTask
                            {
                                Name = "Restoring Packages"
                            },

                            new DotNetBuildTask
                            {
                                Name = "Building Project(s)"
                            },

                            new RunTask
                            {
                                Name = "Provision",
                                Run = "dotnet run --project .\\FailureAnalysis.Core.Api.Infrastructure.Provision\\FailureAnalysis.Core.Api.Infrastructure.Provision.csproj"
                            }
                        }
                    }
                }
            };

            this.adotNetClient.SerializeAndWriteToFile(
                githubPipeline,
                path: "../../../../.github/workflows/provision.yml");
        }
    }
}
