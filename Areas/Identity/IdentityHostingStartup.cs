using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZantosMvc.Areas.Identity.Data;

[assembly: HostingStartup(typeof(ZantosMvc.Areas.Identity.IdentityHostingStartup))]
namespace ZantosMvc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ZantosMvcIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ZantosMvcIdentityDbContextConnection")));

                services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)  
                 .AddDefaultUI()  
                 .AddEntityFrameworkStores<ZantosMvcIdentityDbContext>()  
                 .AddDefaultTokenProviders(); 

                services.AddAuthorization(options => {  
                options.AddPolicy("basicpolicy",  
                    builder => builder.RequireRole("Admin", "Manager","Member"));      
                options.AddPolicy("readpolicy",  
                    builder => builder.RequireRole("Admin", "Manager"));  
                options.AddPolicy("writepolicy",  
                    builder => builder.RequireRole("Admin", "Manager"));  
                });   
            });
        }
    }
}