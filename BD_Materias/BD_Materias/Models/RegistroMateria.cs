using System;
using System.Collections.Generic;

namespace BD_Materias.Models;

public partial class RegistroMateria
{
    public int Id { get; set; }

    public int? EstudianteId { get; set; }

    public int? MateriaId { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Estudiante? Estudiante { get; set; }

    public virtual Materia? Materia { get; set; }
}
