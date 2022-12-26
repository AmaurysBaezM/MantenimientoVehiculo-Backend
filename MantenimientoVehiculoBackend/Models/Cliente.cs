using System;
using System.Collections.Generic;

namespace MantenimientoVehiculoBackend.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? ClienteNombre { get; set; }

    public string? ClienteApellido { get; set; }

    public string? ClienteCedula { get; set; }

    public string? ClienteTelefono { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; } = new List<Vehiculo>();
}
