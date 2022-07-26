// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models.Failures;
using FailureAnalysis.Core.Api.Services.Foundations.Failures;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace FailureAnalysis.Core.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FailuresController : RESTFulController
    {
        private readonly IFailureService failureService;

        public FailuresController(IFailureService failureService) =>
            this.failureService = failureService;

        [HttpPost]
        public async ValueTask<ActionResult<Failure>> PostFailureAsync(Failure failure)
        {
            Failure addedFailure =
                await this.failureService.AddFailureAsync(failure);

            return Created(addedFailure);
        }
    }
}
