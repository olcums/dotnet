using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZantosMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ZantosMvc.Areas.Identity.Data;

namespace ZantosMvc.Controllers
{  
    public class UserController : Controller  
    {  
        private readonly ZantosMvcIdentityDbContext context;

        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> roleManager;  

        public UserController(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager,ZantosMvcIdentityDbContext  context)  
        {  
            this.userManager = userManager;  
            this.roleManager = roleManager;  
            this.context = context; 
        }  
  
        [Authorize(Policy = "readpolicy")] 
        public IActionResult Index()  
        {
            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleNames = (from userrole in context.UserRoles
                                                   join r in context.Roles on userrole.RoleId equals r.Id
                                                   join u in context.Users on userrole.UserId equals u.Id
                                                   where userrole.UserId == user.Id
                                                   select r.Name).ToList()
                                  }).ToList().Select(p => new UserViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });
            return View(usersWithRoles);
        }

    }  
}  