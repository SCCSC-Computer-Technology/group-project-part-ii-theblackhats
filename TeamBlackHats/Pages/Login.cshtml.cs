using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeamBlackHats.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(string username, string password)
        {
            // Check username and password, authenticate user
            if (username == "admin" && password == "admin")
            {
                // Redirect to sport selection page if authentication succeeds
                return RedirectToPage("/SportSelection");
            }
            else
            {
                // Redirect back to login page with error message if authentication fails
                TempData["ErrorMessage"] = "Invalid username or password.";
                return RedirectToPage("/Login");
            }
        }
    }
}
