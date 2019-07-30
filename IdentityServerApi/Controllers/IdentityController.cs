using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public ActionResult IdentityApi()
        {
            var claim = HttpContext.User.Claims;
            return new JsonResult("测试访问API");
        }
    }
}