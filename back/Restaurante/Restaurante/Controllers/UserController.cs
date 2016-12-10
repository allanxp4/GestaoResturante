using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Web.App_Start;
using Potatotech.GestaoRestaurante.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Potatotech.GestaoRestaurante.Web.Controllers
{
    public class UserController : Controller
    {

        #region Private

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("LogIn", "User");
            }
            return returnUrl;
        }

        #endregion

        #region UserManager

        private readonly UserManager<User> userManager;
        public UserController()
        {
            this.userManager = IdentityConfig.UserManagerFactory.Invoke();
        }

        #endregion

        #region Get

        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn(string url, string msg)
        {
            var model = new UserViewModel
            {
                ReturnUrl = url,
                Mensagem = msg
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            GetAuthenticationManager().SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("LogIn", "User", new { msg = "Volte smepre!" });
        }

        #endregion

        #region Post

        [HttpPost]
        public async Task<ActionResult> Registrar(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName,
                TipoId = model.TipoId
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                GetAuthenticationManager().SignIn(identity);
                return RedirectToAction("LogIn", "User", new { msg = "Cadastrado com sucesso" } );
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", "Troxa");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Pedido", "Garcom");
            }
            var user = await userManager.FindAsync(model.Email, model.Password);
            if (user != null)
            {
                var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                GetAuthenticationManager().SignIn(identity);
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }
            ModelState.AddModelError("", "Usuário e/ou Senha inválidos");
            return View();
        }

        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null) { userManager.Dispose(); }
            base.Dispose(disposing);
        }

        #endregion
    }
}