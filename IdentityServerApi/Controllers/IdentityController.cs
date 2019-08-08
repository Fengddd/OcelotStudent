using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [EnableCors("any")]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> IdentityApi()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
            var claim = HttpContext.User.Claims.ToList();
            return new JsonResult("测试访问API");
        }
    }
}