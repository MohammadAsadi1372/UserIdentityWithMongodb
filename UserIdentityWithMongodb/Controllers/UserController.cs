using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserIdentityWithMongodb.Models;

namespace UserIdentityWithMongodb.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser appUser = new ApplicationUser { UserName = user.Name, Email = user.Email };
                    IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                    if (result.Succeeded)
                        ViewBag.Message = "عملیات با موفقیت انجام شد";
                    else
                        foreach (var item in result.Errors)
                            ModelState.AddModelError("", item.Description);

                }
                return View(user);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
