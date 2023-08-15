using System;
using System.Collections.Generic;

namespace BD_Materias.Models;

public partial class Profesore
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Telefono { get; set; }

    public string? Especialidad { get; set; }

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();
}
