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
        private PersonaLogic personaLogic = new PersonaLogic(); // private solo para estas vistas

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string nombre = "")
        {
            
            List<PersonaEntity> listPersonEntities = new List<PersonaEntity>();
            if (string.IsNullOrEmpty(nombre))
            {
                listPersonEntities = personaLogic.GetAllPeople();
            }
            else
            {
                listPersonEntities = personaLogic.GetAllPeople().Where(x => x.Nombre.ToUpper().Contains(nombre.ToUpper())).ToList();
            }
            
            return View(listPersonEntities);
        }

        /*
        public IActionResult ListaPersonas(string nombre = "")
        {
            List<PersonaEntity> listPersonEntities = new List<PersonaEntity>();
            if (string.IsNullOrEmpty(nombre))
            {
                listPersonEntities = personaLogic.GetAllPeople();
            }
            else
            {
                listPersonEntities = personaLogic.GetAllPeople().Where(x => x.Nombre.ToUpper().Contains(nombre.ToUpper())).ToList();
            }
            return View(listPersonEntities);
        }
        */

        public IActionResult Create() // vista sola
        {
            return View();
        }

        // Post: oculta | Get: muestra
        [HttpPost]
        public IActionResult Create(PersonaEntity personaEntity) // captura
        {
            var person = personaLogic.AddPerson(personaEntity); // método creado en...

            ViewBag.Message = person.Message;
            ViewBag.Type = person.Type;

            return View(personaEntity); 

        }

        public IActionResult Edit(string cedula)
        {
            var person = personaLogic.GetPersonForCedula(cedula);

            ViewBag.Message = person.Message;
            ViewBag.Type = person.Type;

            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(PersonaEntity personaEntity)
        {
            var person = personaLogic.UpdatePerson(personaEntity);

            ViewBag.Message = person.Message;
            ViewBag.Type = person.Type;

            return View(personaEntity);
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
