using LogaresiLoginApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LogaresiLoginApp.Controllers {

    public class UserController : Controller
    {
        private readonly LoginDbContext _context;
        public UserController(LoginDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Perfil()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = await _context.Users
                            .FirstOrDefaultAsync(u => u.Id == userId.Value);
            if (user == null)
                return RedirectToAction("Login", "Account");

            ViewBag.NombreUsuario = user.NombreCompleto;
            return View(user);
        }
    }

}