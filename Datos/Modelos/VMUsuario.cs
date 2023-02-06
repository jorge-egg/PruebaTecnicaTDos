using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos
{
    public class VMUsuario
    {
        public int IdUsuario { get; set; }

        public string? Nombre { get; set; }

        public String? FechaNac { get; set; } //se cambia el tipo de valor porque se trabaja en base a la vista

        public string? Sexo { get; set; }
    }
}
