using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cticbackend.model
{
    public class encargo_interno_detalles
    {
        public int id { get; set; }
        public string tipo_encargo { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public DateTime fecha_respuesta { get; set; }

        public int id_usuario_solicitante { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nombre_proyecto { get; set; }
        public string nombre_Estado { get; set; }
        public string observacion { get; set; }
    }
}
