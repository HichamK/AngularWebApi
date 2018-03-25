using AngularWebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace AngularWebApi.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(AccountModel model)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);

            var user = new ApplicationUser()
            {
                UserName = model.UserName, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Gender = model.Gender, Titre = model.Titre,
            };

            manager.PasswordValidator = new PasswordValidator() { 
                RequiredLength = 3
            };

            var result = manager.Create(user, model.Password);

            return result;
        }

        [HttpGet]
        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;

            var account = new AccountModel()
            {
                UserName = identityClaims.FindFirst("UserName").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                Email = identityClaims.FindFirst("Email").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value,
            };

            return account;
        }
    }
}
