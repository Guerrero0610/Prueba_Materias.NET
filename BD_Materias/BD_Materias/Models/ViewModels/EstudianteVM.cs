using Microsoft.AspNetCore.Mvc.Rendering;

namespace BD_Materias.Models.ViewModels
{
    public class EstudianteVM
    {
        public EstudianteVM oEstudiante { get; set; }

        public List<SelectListItem> oRegistroMateria{ get; set;}
    }
}
