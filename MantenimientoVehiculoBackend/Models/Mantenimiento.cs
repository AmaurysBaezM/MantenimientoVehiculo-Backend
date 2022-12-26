using System;
using System.Collections.Generic;

namespace MantenimientoVehiculoBackend.Models;

public partial class Mantenimiento
{
    public int IdMantenimiento { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Costo { get; set; }

    public int? Tipo { get; set; }

    public int? Mecanico { get; set; }

    public int? Vehiculo { get; set; }

    public int? Estado { get; set; }

    public virtual Estado? EstadoNavigation { get; set; }

    public virtual Mecanico? MecanicoNavigation { get; set; }

    public virtual TipoMantenimiento? TipoNavigation { get; set; }

    public virtual Vehiculo? VehiculoNavigation { get; set; }
}
