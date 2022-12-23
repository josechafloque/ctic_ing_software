using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cticbackend.model
{
    public class encargo_interno
    {
        public int id { get; set; }
        public string tipo_encargo { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public int id_usuario_solicitante { get; set; }
        public int id_proyecto { get; set; }
        public int id_estado_encargo { get; set; }
    }
}
