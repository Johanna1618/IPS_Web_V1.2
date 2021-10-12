using IPS_Logic.Logic;
using IPS_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IPS_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IpsWebLogic ipswebLogic = new IpsWebLogic();

            return View(ipswebLogic.GetAllPeople());
        }

        public IActionResult SignUP() // Registro
        {
            return View();
        }

        public IActionResult SignIn() // Login
        {

            return View();
        }

    }
}
