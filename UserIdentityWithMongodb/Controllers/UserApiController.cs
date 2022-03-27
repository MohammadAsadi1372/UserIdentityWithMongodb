using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserIdentityWithMongodb.Models;

namespace UserIdentityWithMongodb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserApiController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<string> exp = new List<string>();
                    ApplicationUser appUser = new ApplicationUser { UserName = user.Name, Email = user.Email };
                    IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                    await _userManager.AddToRoleAsync(appUser, "Admin");
                    if (result.Succeeded)
                        return Ok("عملیات با موفقیت انجام شد");
                    else
                    {
                        foreach (var item in result.Errors)
                            exp.Add(item.Description);
                        return BadRequest(exp.ToArray());
                    }

                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] UserRole userRole)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<string> exp = new List<string>();
                    IdentityResult result = await _roleManager.CreateAsync(new ApplicationRole() {
                         Name = userRole.RoleName,
                         
                    });
                    if (result.Succeeded)
                        return BadRequest("عملیات با موفقیت انجام شد");
                    else
                    {
                        foreach (var item in result.Errors)
                            exp.Add(item.Description);
                        return BadRequest(exp.ToArray());
                    }

                }
                return Ok(userRole);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
