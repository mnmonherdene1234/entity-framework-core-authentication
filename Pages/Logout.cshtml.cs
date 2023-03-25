using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationVideoOne.Pages;

public class LogoutModel : PageModel
{
    public SignInManager<IdentityUser> SignInManager { get; set; }
    public LogoutModel(SignInManager<IdentityUser> signInManager)
    {
        SignInManager = signInManager;
    }

    public async Task<IActionResult> OnPostLogoutAsync()
    {
        await SignInManager.SignOutAsync();
        return RedirectToPage("Login");
    }

    public IActionResult OnPostDontLogout()
    {
        return RedirectToPage("Index");
    }
}