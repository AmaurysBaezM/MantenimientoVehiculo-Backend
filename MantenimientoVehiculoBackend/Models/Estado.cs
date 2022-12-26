using System;
using System.Collections.Generic;

namespace MantenimientoVehiculoBackend.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? EstadoNombre { get; set; }

    public virtual ICollection<Mantenimiento> Mantenimientos { get; } = new List<Mantenimiento>();
}
