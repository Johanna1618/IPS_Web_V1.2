using IPS_Entity.Entity;
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
    public class HomeController : Controller // se puede heredar este controller a otros
    {
        private readonly ILogger<HomeController> _logger;
        private IpsWebLogic ipswebLogic = new IpsWebLogic(); // private solo para estas vistas

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View(ipswebLogic.GetAllPeople()); // viene de IpsWebLogic
        }

        public IActionResult Create() // vista sola
        {
            return View();
        }

        // Post: oculta | Get: muestra
        [HttpPost]
        public IActionResult Create(PersonaEntity personaEntity) // captura
        {
            ipswebLogic.AddPerson(personaEntity); // método creado en IpsWebLogic

            return View(personaEntity); // trae aquí
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
