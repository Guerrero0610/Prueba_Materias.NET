using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BD_Materias.Models;
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

    }
}