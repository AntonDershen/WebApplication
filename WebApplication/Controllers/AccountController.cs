using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using BLL.Interface.Services;
using WebApplication.Infrastructure.Mappers;
using System.Web.Security;
using Constants;
namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IAuthorizationService authService;
        private readonly IRoleService roleService;
        public AccountController(IUserService userService, IAuthorizationService authService, IRoleService roleService)
        {
            this.userService = userService;
            this.authService = authService;
            this.roleService = roleService;
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if(authService.CheckForm(model.ToBllUser()))
                {
                    FormsAuthentication.SetAuthCookie(userService.GetUserById(authService.GetAuthorizationByEmail(model.Email).UserId).UserName, true);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                
                int id = userService.CreateUser(model.ToBllUser(roleService.GetIdByDescriptor(Constants.Constants.User)));
                if (id>0)
                {
                    authService.CreateAuthorization(model.ToBllAuthorization(id));
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Пользователь с данным именем существует");
                   
            }
          return View(model);
         }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
	}
}