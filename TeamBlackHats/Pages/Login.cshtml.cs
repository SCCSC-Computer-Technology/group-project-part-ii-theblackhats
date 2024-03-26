using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.ComponentModel.DataAnnotations;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TeamBlackHats.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }

        private readonly HttpClient _httpClient;

        public LoginModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string action)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                if (action == "login")
                {
                    var loginResult = await AuthenticateUserAsync(Credential.Username, Credential.Password);
                    if (loginResult)
                    {
                        // Redirect to dashboard or perform other actions
                        return RedirectToPage("/Dashboard");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Invalid username or password.";
                        return RedirectToPage("/Login");
                    }
                }
                else if (action == "addUser")
                {
                    await AddUserAsync(Credential.Username, Credential.Password);
                    TempData["SuccessMessage"] = "User created successfully.";
                    return RedirectToPage("/Login");
                }
                else if (action == "deleteUser")
                {
                    await DeleteUserAsync(Credential.Username);
                    TempData["SuccessMessage"] = "User deleted successfully.";
                    return RedirectToPage("/Login");
                }

                return RedirectToPage("/Login");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return RedirectToPage("/Login");
            }
        }

        private async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            var loginRequest = new { Username = username, Password = password };
            var content = new StringContent(JsonSerializer.Serialize(loginRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7275/api/BlackHatsApp/GetUsers", content);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return result == "success"; // Modify this based on your API response
        }

        private async Task AddUserAsync(string username, string password)
        {
            var newUser = new { Username = username, Password = password };
            var content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7275/api/BlackHatsApp/AddUsers", content);

            response.EnsureSuccessStatusCode();
        }

        private async Task DeleteUserAsync(string username)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7275/api/BlackHatsApp/DeleteUsers?Username={username}");

            response.EnsureSuccessStatusCode();
        }
    }


    public class Credential
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
