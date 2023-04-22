using Asd.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Asd.Controllers;

public class UserController : Controller
{
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;

    public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(CreationUser creationUser)
    {
        if (ModelState.IsValid)
        {
            User user = new User()
            {
                Email = creationUser.Email,
                UserName = creationUser.Email
            };
            var result = await _userManager.CreateAsync(user, creationUser.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect("Home/Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        ViewBag.errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
        return View(creationUser);
    }
}