using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cticbackend.model
{
    public class proyecto_detalles
    {
        public int id { get; set; }
        public DateTime fecha_registro { get; set; }
        public int id_usuario_responsable { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nombre_proyecto { get; set; }
    }
}
