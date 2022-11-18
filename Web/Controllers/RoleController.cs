using Application.ViewModels.RolesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Authorize(Roles = "Admin")]
public class RoleController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;

    public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;

    }
    public IActionResult Index() => View(_roleManager.Roles.ToList());

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(name));

            if (result.Succeeded)
                return RedirectToAction("Index");

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }
        return View(name);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role != null)
        {
            var result = await _roleManager.DeleteAsync(role);
        }
        return RedirectToAction("Index");
    }

    public IActionResult UserList() => View(_userManager.Users.ToList());

    public async Task<IActionResult> Edit(string userId)
    {
        // получаем пользователя
        IdentityUser user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            // получем список ролей пользователя
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();
            var model = new ChangeRoleViewModel
            {
                UserId = user.Id,
                UserEmail = user.Email,
                UserRoles = userRoles,
                AllRoles = allRoles
            };
            return View(model);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string userId, List<string> roles)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return NotFound();

        var userRoles = await _userManager.GetRolesAsync(user);

        var addedRoles = roles.Except(userRoles);

        var removedRoles = userRoles.Except(roles);

        await _userManager.AddToRolesAsync(user, addedRoles);

        await _userManager.RemoveFromRolesAsync(user, removedRoles);

        return RedirectToAction("UserList");
    }
}
