// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using FailureAnalysis.Core.Api.Models.Failures;
using FailureAnalysis.Core.Api.Models.Failures.Exceptions;
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
            try
            {
                Failure addedFailure =
                await this.failureService.AddFailureAsync(failure);

                return Created(addedFailure);
            }
            catch (FailureValidationException failureValidationException)
            {
                return BadRequest(failureValidationException.InnerException);
            }
            catch (FailureDependencyException failureDependencyException)
            {
                return InternalServerError(failureDependencyException);
            }
            catch (FailureDependencyValidationException failureDependencyValidationException)
                when (failureDependencyValidationException.InnerException is AlreadyExistsFailureException)
            {
                return Conflict(failureDependencyValidationException.InnerException);
            }
            catch (FailureDependencyValidationException failureDependencyValidationException)
            {
                return BadRequest(failureDependencyValidationException.InnerException);
            }
            catch (FailureServiceException failureServiceException)
            {
                return InternalServerError(failureServiceException);
            }
        }
    }
}
