using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelStores.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }
        public ApplicationUser()
        {
        }
    }


    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("TravelDb") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) //хранилище пользователей
                : base(store)
        {
        }
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
                                                IOwinContext context)
        {
            ApplicationContext db = context.Get<ApplicationContext>();
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            return manager;
        }
    }
}