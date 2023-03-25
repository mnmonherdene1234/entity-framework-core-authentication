using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using AuthenticationVideoOne.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationVideoOne.Pages;

public class LoginModel : PageModel
{
    [BindProperty]
    public Login Login { get; set; }
    public SignInManager<IdentityUser> SignInManager { get; set; }

    public LoginModel(SignInManager<IdentityUser> signInManager)
    {
        Login = new();
        SignInManager = signInManager;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        if (ModelState.IsValid)
        {
            var result = await SignInManager.PasswordSignInAsync(Login.Email, Login.Password, Login.RememberMe, false);

            if (result.Succeeded)
            {
                if (returnUrl == null || returnUrl == "/")
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    return RedirectToPage(returnUrl);
                }
            }

            ModelState.AddModelError("", "Username or password incorrect");
        }

        return Page();
    }
}