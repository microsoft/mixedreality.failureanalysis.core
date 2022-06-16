// ---------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;

namespace FailureAnalysis.Core.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Hello, Mario. The princess is in another castle!");
    }
}
