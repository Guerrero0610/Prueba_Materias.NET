using System;
using System.Collections.Generic;

namespace BD_Materias.Models;

public partial class Materia
{
    public int Id { get; set; }

    public string? NombreMateria { get; set; }

    public string? DescripcionMateria { get; set; }

    public string? Horario { get; set; }

    public int? ProfesorId { get; set; }

    public virtual Profesore? Profesor { get; set; }

    public virtual ICollection<RegistroMateria> RegistroMateria { get; set; } = new List<RegistroMateria>();
}
