using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<IdentityUser> manager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = manager;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        ViewData["IsUser"] = User.IsInRole("User");
        ViewData["IsAdmin"] = User.IsInRole("Admin");

        var users = _userManager.Users.AsEnumerable();
        var roles = _roleManager.Roles.AsEnumerable();

        return View((users, roles));
    }
}
