using Lab10CoffeeShopRegistrationMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Lab10CoffeeShopRegistrationMVC.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IFormCollection userRegistration)
        {
            return View();
        }

        public IActionResult Summary(IFormCollection userRegistration)
        {
            try
            {
                RegistrationViewModel newRegistration = new RegistrationViewModel()
                {
                    FirstName = userRegistration["FirstName"],
                    LastName = userRegistration["LastName"],
                    Email = userRegistration["Email"],
                    Password = userRegistration["Password"]
                };

                return View(newRegistration);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
