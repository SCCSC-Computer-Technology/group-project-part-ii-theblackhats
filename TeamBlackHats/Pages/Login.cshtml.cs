using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.ComponentModel.DataAnnotations;

namespace TeamBlackHats.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential? Credential { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(string action)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (action == "login")
            {
                // Simulated login logic
                if (IsValidUser(Credential.Username, Credential.Password))
                {
                    // Redirect to dashboard or perform other actions
                    return RedirectToPage("/Home");
                }
                else
                {
                    // Redirect back to login page with error message
                    TempData["ErrorMessage"] = "Invalid username or password.";
                    return RedirectToPage("/Login");
                }
            }
            else if (action == "addUser")
            {
                // Simulated add user logic
                if (Credential.Username != null && Credential.Password != null)
                {
                    // Add new user
                    AddNewUser(Credential.Username, Credential.Password);
                    // Redirect to login page with success message
                    TempData["SuccessMessage"] = "User created successfully.";
                    return RedirectToPage("/Login");
                }
                else
                {
                    // Redirect back to login page with error message
                    TempData["ErrorMessage"] = "Username and password are required.";
                    return RedirectToPage("/Login");
                }
            }

            // Redirect back to the same page after handling the form submission
            return RedirectToPage("/Login");
        }

        // Simulated method to check if user is valid
        private bool IsValidUser(string username, string password)
        {
            // You need to implement your actual user authentication logic here
            // For demonstration, let's assume there's a hardcoded user
            return username == "admin" && password == "password";
        }

        // Simulated method to add new user
        private void AddNewUser(string username, string password)
        {
            // You need to implement your actual user creation logic here
            // For demonstration, we'll just print the new user details
            Console.WriteLine($"New user created: Username - {username}, Password - {password}");
        }
    }

    public class Credential
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
