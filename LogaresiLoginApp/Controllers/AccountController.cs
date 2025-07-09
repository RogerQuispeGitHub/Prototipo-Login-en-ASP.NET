using Microsoft.AspNetCore.Mvc;
using LogaresiLoginApp.Models;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LogaresiLoginApp.Controllers {

    public class AccountController : Controller
    {
        private readonly LoginDbContext _context;

        public AccountController(LoginDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
             var user = await _context.Users
    .FirstOrDefaultAsync(u =>
        u.TipoDocumento.Trim() == model.TipoDocumento.Trim() &&
        u.NumeroDocumento.Trim() == model.Usuario.Trim());


            if (user == null)
            {
                ViewBag.UsuarioError = "Usuario no encontrado.";
                return View(model);
            }

            if (user.BloqueadoHasta.HasValue && user.BloqueadoHasta.Value > DateTime.Now)
            {
                return RedirectToAction("Blocked");
            }

            if (model.Password != user.PasswordHash) 
            {
                user.IntentosFallidos++;

                if (user.IntentosFallidos >= 4)
                {
                    user.BloqueadoHasta = DateTime.Now.AddMinutes(15);
                }

                await _context.SaveChangesAsync();

                ViewBag.PasswordError = "Contraseña incorrecta.";
                return View(model);
            }

            // Login exitoso
            user.IntentosFallidos = 0;
            user.BloqueadoHasta = null;
            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("NombreUsuario", user.NombreCompleto);
            HttpContext.Session.SetInt32("UserId", user.Id);

            return RedirectToAction("Perfil", "User");
        }

        public IActionResult Bloqueado()
        {
            return View(); // Vista con el mensaje: Cuenta bloqueada temporalmente...
        }

        public IActionResult Perfil()
        {
            var nombre = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.NombreUsuario = nombre;
            return View();
        }

        public IActionResult Blocked()
        {
            return View();
        }


        public async Task<IActionResult> TestDb()
        {
            var usuarios = await _context.Users.ToListAsync();
            return Content("Usuarios encontrados: " + usuarios.Count);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }


    }

}