using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoAlison.Modelo;
using ProjetoAlison.Entity;
using System.Security.Cryptography;

namespace ProjetoAlison.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserSys user)
        {
            using (ProjetoAlisonContexto db = new ProjetoAlisonContexto())
            {
                try
                {
                    var criptografia = new Criptografia(SHA512.Create());
                    // NÃO USEI CRIPTOGRAFIA POIS A COLUNA PASSWORD TEM LIMITE DE 40 CARACTERES E NAO ARMAZENAVA ESTE TIPO DE CRIPTOGRAFIA
                    //var usr = db.UserSys.Single(u => u.Email.Equals(user.Email) && criptografia.VerificaSenha(user.Password, u.Password));
                    var usr = db.UserSys.Single(u => u.Email.Equals(user.Email) && user.Password.Equals(u.Password));

                    if (usr != null)
                    {
                        Session["UserID"] = usr.Id.ToString();
                        Session["UserName"] = usr.Login.ToString();
                        Session["Role"] = usr.UserRoleId.ToString();
                        return RedirectToAction("LoggedIn");
                    }
                    else
                        ModelState.AddModelError("", "The email and / or password entered is invalid.Please try again.");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "The email and / or password entered is invalid.Please try again.");
                }

                return RedirectToAction("index", "Customer", new { area = "" });
            }
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }
    }
}