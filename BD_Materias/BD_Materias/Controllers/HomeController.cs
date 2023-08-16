﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BD_Materias.Models;
using BD_Materias.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BD_Materias.Controllers
{
    public class HomeController : Controller
    {
        private readonly BdmateriasContext _BDContext;

        public HomeController(BdmateriasContext context)
        {
            _BDContext = context;
        }

        public IActionResult Index(string Buscar)
        {
            var EstudianteInte = _BDContext.Estudiantes.ToList();

            if (!String.IsNullOrEmpty(Buscar))
            {
                EstudianteInte = EstudianteInte.Where(s => s.Nombre != null && s.Nombre.Contains(Buscar)).ToList();
            }

            return View(EstudianteInte);
        }

        [HttpGet]
        public IActionResult PersonaInteDetalle(int idPersonaInt)
        {
            EstudianteVM oEstudianteVM = new EstudianteVM()
            {
                oEstudiante = new Estudiante(),
                oRegistroMateria = _BDContext.RegistroMaterias.Select(Materias => new SelectListItem()
                {
                    Text = Materias.Id.ToString(),
                    Value = Materias.Id.ToString()

                }).ToList()

            };

            if (idPersonaInt != 0)
            {
                oEstudianteVM.oEstudiante = _BDContext.Estudiantes.Find(idPersonaInt);
            }

            return View(oEstudianteVM);
        }

        [HttpPost]
        public IActionResult PersonaInteDetalle(EstudianteVM oEstudianteVM)
        {
            if (oEstudianteVM.oEstudiante.Id == 0)
            {
                _BDContext.Estudiantes.Add(oEstudianteVM.oEstudiante);
            }
            else
            {
                _BDContext.Estudiantes.Update(oEstudianteVM.oEstudiante);
            }

            _BDContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}