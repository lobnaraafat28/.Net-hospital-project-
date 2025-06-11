using HospitalManagementSystem.Presentation.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            return View();
        }
    }
}
