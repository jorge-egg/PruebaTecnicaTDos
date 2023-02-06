using System;
using System.Collections.Generic;

namespace Datos.DbUsuarios;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaNac { get; set; }

    public string? Sexo { get; set; }
}
