using System;
using System.Collections.Generic;

namespace MantenimientoVehiculoBackend.Models;

public partial class Mecanico
{
    public int IdMecanico { get; set; }

    public string? MecanicoNombre { get; set; }

    public string? MecanicoApellido { get; set; }

    public string? MecanicoCedula { get; set; }

    public string? MecanicoTelefono { get; set; }

    public virtual ICollection<Mantenimiento> Mantenimientos { get; } = new List<Mantenimiento>();
}
