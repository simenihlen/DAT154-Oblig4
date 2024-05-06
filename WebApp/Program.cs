using HotelLibrary.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApp.Components;

namespace WebApp {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // https://www.youtube.com/watch?v=GKvEuA80FAE

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.Cookie.Name = "auth_token";
                    options.LoginPath = "/login";
                    options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
                    options.AccessDeniedPath = "/access-denied";
                });
            builder.Services.AddAuthorization();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddDbContext<HotelDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
