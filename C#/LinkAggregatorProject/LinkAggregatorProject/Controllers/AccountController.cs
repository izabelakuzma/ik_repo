using System.Linq;
using LinkAggregatorProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinkAggregatorProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserDbContext _context;

        public AccountController(UserDbContext context)
        {
            _context = context;

        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (!_context.Users.Any(x => x.Email == user.Email))
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();

                    ModelState.Clear();
                    ViewBag.Message = user.Email + " został poprawnie zarejestrowany.";               
                }
                else
                {
                    ViewBag.Message = "Ten użytkownik już istnieje.";
                    return View();
                }               
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var account = _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("UserID", account.UserId.ToString());
                HttpContext.Session.SetString("Email", account.Email);

                return RedirectToAction("Index", "Link", new { area = "" });
            }
            else
            {
                ModelState.AddModelError("", "Email lub hasło jest nieprawidłowe.");
            }
            return View();
        }
        public ActionResult Welcome()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                ViewBag.Username = HttpContext.Session.GetString("Email");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View();
        }
    }
}