using System;
using System.Collections.Generic;

namespace MantenimientoVehiculoBackend.Models;

public partial class Vehiculo
{
    public int IdVehiculo { get; set; }

    public string? Tipo { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Año { get; set; }

    public string? Color { get; set; }

    public string? Chasis { get; set; }

    public string? Matricula { get; set; }

    public string? Descripcion { get; set; }

    public int? Dueño { get; set; }

    public virtual Cliente? DueñoNavigation { get; set; }

    public virtual ICollection<Mantenimiento> Mantenimientos { get; } = new List<Mantenimiento>();
}
