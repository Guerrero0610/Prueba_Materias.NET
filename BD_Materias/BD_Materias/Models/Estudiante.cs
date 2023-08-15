using System;
using System.Collections.Generic;

namespace BD_Materias.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Edad { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Genero { get; set; }

    public DateTime? FechaInscripcion { get; set; }

    public virtual ICollection<RegistroMateria> RegistroMateria { get; set; } = new List<RegistroMateria>();
}
