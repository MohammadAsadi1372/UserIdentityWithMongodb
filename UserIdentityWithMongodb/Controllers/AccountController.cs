using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using UserIdentityWithMongodb.Models;

namespace UserIdentityWithMongodb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<string> exp = new List<string>();
                    ApplicationUser appUser = await _userManager.FindByNameAsync(login.Username);
                    if (appUser == null)
                        return BadRequest("کاربری پیدا نشد");
                    else
                    {
                        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
                        if (result.Succeeded)
                        {

                        }else
                            return BadRequest("گذرواژه اشتباه میباشد");
                    }

                }
                return Ok(login);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
