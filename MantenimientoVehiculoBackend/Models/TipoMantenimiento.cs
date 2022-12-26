using System;
using System.Collections.Generic;

namespace MantenimientoVehiculoBackend.Models;

public partial class TipoMantenimiento
{
    public int IdTipo { get; set; }

    public string? Tipo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Mantenimiento> Mantenimientos { get; } = new List<Mantenimiento>();
}
