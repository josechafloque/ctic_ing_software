using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cticbackend.model
{
    public class autenticacion_usuario
    {
        public int id { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public int id_rol { get; set; }
        public string nombre_rol { get; set; }

    }
}
