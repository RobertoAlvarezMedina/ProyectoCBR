using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CBR_Web.Models;

namespace CBR_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Login()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Login_Nuevo()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Login_Existente()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Premium()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult MenuAdmin()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult MenuUser()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Usuarionuevo(User user)
        {
            Utils.Utils utils = new Utils.Utils();
            bool resultado = utils.InsertarUsuario(user);
            ViewBag.Resultado = resultado;
            if (resultado)
            {
                ViewBag.Mensaje = "El usuario" + user.Nombre + "ha sido ingresado satisfactoriamente.";
            }
            else
            {
                ViewBag.Mensaje = "El usuario"+ user.Nombre + "no fue ingresado correctamente,intente de nuevo!";
            }
            return View("~/Views/Home/Login_Nuevo.cshtml");
        }

        public IActionResult Usuarioexistente(User user)
        {
            return View("~/Views/Home/Login_Existente.cshtml");
        }

    }
}
