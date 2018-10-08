using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelStores.Models;

[assembly: OwinStartup(typeof(TravelStores.Startup))] //при запуске будет запускаться класс sturtup
namespace TravelStores
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // настраиваем контекст и менеджер
            app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create); // Регистрируем контекст данных
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create); //Менеджер пользователей
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, // для авторизации и аутентификации приложение будет использовать coockie
                LoginPath = new PathString("/Account/Login"), // путь для неавторизованного пользователя
            });
        }
    }
}