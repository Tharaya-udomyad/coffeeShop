using Microsoft.AspNetCore.Authorization;
using coffeeShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace coffeeShop.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnly() => Content("หน้านี้ส ําหรับ Admin เท่านั้น");
        [Authorize(Roles = "Admin,Manager,Cashier")]
        public IActionResult StaffOnly() => Content($"พนักงาน: {User.Identity?.Name}");
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

