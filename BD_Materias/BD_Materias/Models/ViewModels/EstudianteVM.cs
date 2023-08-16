using Microsoft.AspNetCore.Mvc.Rendering;

namespace BD_Materias.Models.ViewModels
{
    public class EstudianteVM
    {
        public Estudiante oEstudiante { get; set; }

        public List<SelectListItem> oGenero{ get; set;}

        public string GeneroSeleccionado { get; set; }
    }
}
