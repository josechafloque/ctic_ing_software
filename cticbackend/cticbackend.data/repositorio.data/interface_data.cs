using cticbackend.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cticbackend.data.repositorio.data
{
    public interface interface_data
    {
        Task<IEnumerable<usuario>> Obtener_Lista_Usuarios();
        Task<autenticacion_usuario> Autenticacion_Usuario(int id, string correo, string contrasena);
        Task<bool> Ingresar_Usuario(usuario usuario);

        Task<bool> Actualizar_Usuario(usuario usuario);
        Task<bool> Borrar_Usuario(usuario usuario);

        Task<IEnumerable<proyecto_detalles>> Obtener_Lista_Proyectos();

        Task<bool> Ingresar_Proyecto(proyecto proyecto);

        Task<bool> Actualizar_Proyecto(proyecto proyecto);

        Task<IEnumerable<encargo_interno_detalles>> Obtener_Lista_Encargos();
        Task<bool> Registrar_Evaluacion(observacion_encargo observacion_encargo);
        Task<bool> Registrar_Encargo_Interno(encargo_interno encargo_interno);
        Task<usuario> Obtener_Usuario(int id);

        Task<proyecto_detalles> Obtener_Proyecto(int id);
    }
}
