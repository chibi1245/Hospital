using Hospital.Model;
using Hospital.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Utilites
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _Context;

        public DbInitializer(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _Context = context;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Initializer()
        {
            try
            {
                if (_Context.Database.GetPendingMigrations() .Count()>0)
                {
                    _Context.Database.Migrate();
                }
            }
            catch(Exception)
            {

            }


            if (!_roleManager.RoleExistsAsync(WebSiteRoles.Website_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Website_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Website_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Website_Doctor)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    Email =" dollie@xyz.com"
                },"dollie@123").GetAwaiter().GetResult();
                var AppUser = _Context.ApplicationUsers.FirstOrDefault(x => x.Email == "dollie@xyz.com");
                if (AppUser!=null)
                {
                    _userManager.AddToRoleAsync(AppUser, role: WebSiteRoles.Website_Admin).GetAwaiter().GetResult();
                }
            }


        }
    }
}
