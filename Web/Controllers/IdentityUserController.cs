using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Authorize(Roles = "Admin")]
public class IdentityUserController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public IdentityUserController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Index() => View(_userManager.Users.ToList());

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return RedirectToAction("Index");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

    public async Task<IActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return NotFound();

        var model = new UpdateUserViewModel
        {
            Id = user.Id,
            Email = user.Email
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user != null)
            {
                user.Email = model.Email;
                user.UserName = model.Email;

                var passwordValidator = HttpContext.RequestServices
                    .GetRequiredService(typeof(IPasswordValidator<IdentityUser>))
                    as IPasswordValidator<IdentityUser>;

                var passwordHasher = HttpContext.RequestServices
                    .GetRequiredService(typeof(IPasswordHasher<IdentityUser>))
                    as IPasswordHasher<IdentityUser>;

                var result = await passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);

                if (result.Succeeded)
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, model.NewPassword);
                    await _userManager.UpdateAsync(user);
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }

        return View(model);
    }

    [HttpPost]
    public async Task<ActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);
        }

        return RedirectToAction("Index");
    }
}
