using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cticbackend.model
{
    public class observacion_encargo
    {
        public int id { get; set; }
        public int id_estado_encargo { get; set; }
        public string observacion { get; set; }
        public DateTime fecha_respuesta { get; set; }
    }
}
