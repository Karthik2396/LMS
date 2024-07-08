using LMS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using LMS.Model.Models;

namespace LibraryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBizLmsService _bizLmsService;

        public AccountController(IBizLmsService bizLmsService)
        {
            _bizLmsService = bizLmsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LibrarianLogin()
        {
            ViewBag.Title = "Login";
            if (HttpContext.Session.GetString("librarian_userid") != null)
            {
                return RedirectToAction("Index", "LibrarianOps");
            }
            ViewBag.LibrarianLogin = true;
            return View(new Librarian());
        }

        public IActionResult MemberLogin()
        {
            ViewBag.Title = "Login";
            if (HttpContext.Session.GetString("member_userid") != null)
            {
                return RedirectToAction("Index", "MemberOps");
            }
            ViewBag.LibrarianLogin = false;
            return View(new MemberDetail());
        }

        [HttpPost]
        public async Task<IActionResult> LibrarianLogin(string username, string password)
        {
            var user = await _bizLmsService.LibrarianLogin(username, password);
            if (user != null)
            {
                HttpContext.Session.SetString("librarian_userid", user.Id.ToString());
                return  RedirectToAction("Index", "LibrarianOps");
            }
            ViewBag.Error = "Unable to login! Check credentials.";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MemberLogin(string username, string password)
        {
            var user = await _bizLmsService.MemberLogin(username, password);
            if (user != null)
            {
                HttpContext.Session.SetString("member_userid", user.Id.ToString());
                return RedirectToAction("Index", "MemberOps");
            }
            ViewBag.Error = "Unable to login! Check credentials.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

