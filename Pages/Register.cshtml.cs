using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using AuthenticationVideoOne.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationVideoOne.Pages;

public class RegisterModel : PageModel
{
    [BindProperty]
    public Register Register { get; set; }

    public UserManager<IdentityUser> UserManager { get; set; }
    public SignInManager<IdentityUser> SignInManager { get; set; }

    public RegisterModel(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
    {
        Register = new Register();
        UserManager = userManager;
        SignInManager = signInManager;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser
            {
                UserName = Register.Email,
                Email = Register.Email
            };

            var result = await UserManager.CreateAsync(user, Register.Password);

            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, false);

                return RedirectToPage("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        return Page();
    }
}