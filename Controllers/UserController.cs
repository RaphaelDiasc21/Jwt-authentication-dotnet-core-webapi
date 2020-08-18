using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiJwt.Services;
namespace ApiJwt.Controllers
{
    public class UserController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult<dynamic>> login()
        {
            var token = JwtService.generateToken("Raphael");

            return new
            {
                token = token
            };
        }

        [HttpPost]
        [Route("auth")]
        [Authorize]
        public async Task<ActionResult<dynamic>> auth()
        {
            return User.Identity.Name;
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        [Route("manager")]
        public async string manager()
        {
            return User.IsInRole;
        }

    }
}
