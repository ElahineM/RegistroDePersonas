using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using RegistroDePersonas.Models.DataBase;
using RegistroDePersonas.Models.ViewModels;

namespace RegistroDePersonas.Controllers
{
    public class PersonaController : Controller
    {
        // Obtener Persona

        /// <summary>
        /// Información cargada por la página principal
        /// </summary>
        /// <returns>La lista de las personas registradas</returns>
        public IActionResult Index()
        {
            List<ListPersonaViewModel> listPersonaViews;
            using (ElahinePruebaContext db = new ElahinePruebaContext()) 
            {
                listPersonaViews = (from d in db.Personas
                           select new ListPersonaViewModel
                           {
                               Id = d.Id,
                               Nombre = d.Nombre,
                               FechaDeNacimiento = d.FechaDeNacimiento
                           }).ToList();
            }
           
           return View(listPersonaViews);
        }

        //Crear Persona

        /// <summary>
        /// Información entregada a la vista de nueva persona
        /// </summary>
        /// <returns>La vista sin ninguna información adicional</returns>
        public ActionResult Nuevo()
        {
            return View();
        }

        /// <summary>
        /// Endpoint consumido para registrar una nueva persona
        /// </summary>
        /// <param name="model">Datos de la persona a registrar</param>
        /// <returns>Redirección a la vista principal</returns>
        [HttpPost]
        public ActionResult Nuevo (PersonaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ElahinePruebaContext db = new ElahinePruebaContext())
                    {
                        var newPersona = new Persona();
                        newPersona.Nombre = model.Nombre;
                        newPersona.FechaDeNacimiento = model.FechaDeNacimiento;
                        
                        db.Personas.Add(newPersona);
                        db.SaveChanges();
                    }

                    return Redirect("~/Persona/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //Editar Persona
        /// <summary>
        /// Información entregada a la vista de editar persona
        /// </summary>
        /// <param name="Id">Identificador de la persona a editar</param>
        /// <returns>La vista con información del modelo</returns>
        public ActionResult Editar(int Id)
        {
            PersonaViewModel model = new PersonaViewModel();
            using (ElahinePruebaContext db = new ElahinePruebaContext())
            {
                var persona = db.Personas.Find(Id);
                model.Id = persona.Id;
                model.Nombre = persona.Nombre;
                model.FechaDeNacimiento = persona.FechaDeNacimiento;
            }
            return View(model);
        }

        /// <summary>
        /// Endpoint consumido para editar la información de una persona existente
        /// </summary>
        /// <param name="model">Datos de la persona a editar</param>
        /// <returns>Redirección a la vista principal</returns>
        [HttpPost]
        public ActionResult Editar(PersonaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ElahinePruebaContext db = new ElahinePruebaContext())
                    {
                        var persona = db.Personas.Find(model.Id);
                        persona.Nombre = model.Nombre;
                        persona.FechaDeNacimiento = model.FechaDeNacimiento;

                        db.SaveChanges();
                    }

                    return Redirect("~/Persona/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Eliminar Persona

        /// <summary>
        /// Endpoint consumido para eliminar el registro de una persona existente
        /// </summary>
        /// <param name="Id">Identificador de la persona a eliminar</param>
        /// <returns>Redirección a la vista principal</returns>
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (ElahinePruebaContext db = new ElahinePruebaContext())
            {
                var persona = db.Personas.Find(Id);
                db.Personas.Remove(persona);
                db.SaveChanges();
            }
            return Redirect("~/Persona/");
        }
    }
}
