using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using TeamBlackHats.Data;
using TeamBlackHats.Services;

namespace TeamBlackHats
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddHttpClient();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                    options =>
                    {
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                        options.SlidingExpiration = true;
                        options.AccessDeniedPath = "/Forbidden/";
                    }
                );
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<HttpContextAccessor>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy(new CookiePolicyOptions() { MinimumSameSitePolicy = SameSiteMode.Strict });

            app.Run();
        }
    }
}