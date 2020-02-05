using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TreeStructure.Data;
using TreeStructure.Settings;

namespace TreeStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            try
            {
                using (var scope = host.Services.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                    var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    var userSettings = scope.ServiceProvider.GetRequiredService<IOptions<AdminSettings>>();
                    ctx.Database.EnsureCreated();

                    var adminRole = new IdentityRole("Admin");
                    if (!ctx.Roles.Any())
                    {
                        roleMgr.CreateAsync(adminRole).GetAwaiter().GetResult();
                    }
                    if (!ctx.Users.Any())
                    {
                        var adminUser = new IdentityUser
                        {
                            UserName = userSettings.Value.Username,
                            Email = userSettings.Value.Email
                        };
                        var result = userMgr.CreateAsync(adminUser, userSettings.Value.Password).GetAwaiter().GetResult();
                        userMgr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
