using cticbackend.model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cticbackend.data.repositorio.data
{
    public class data_app : interface_data
    {
        private ConexionPostgreSQL _connectionString;
        public data_app(ConexionPostgreSQL connectionString)
        {
            _connectionString = connectionString;

        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> Actualizar_Usuario(usuario usuario)
        {
            var db = dbConnection();
            var sql = @"
                         UPDATE usuario
                         SET nombre = @Nombre,
                             apellido = @Apellido,
                             dni = @Dni,
                             correo = @Correo,
                             contrasena = @Contrasena,
                             telefono = @Telefono,
                             id_rol = @Id_rol
                         WHERE id = @Id
                       ";
            var resultado = await db.ExecuteAsync(sql, new { usuario.nombre, usuario.apellido, usuario.dni, usuario.correo, usuario.contrasena, usuario.telefono, usuario.id_rol, usuario.id });
            return resultado > 0;
        }

        public async Task<bool> Borrar_Usuario(usuario usuario)
        {
            var db = dbConnection();
            var sql = @"
                         DELETE FROM usuario
                         WHERE id = @Id
                       ";
            var resultado = await db.ExecuteAsync(sql, new {Id_usuario_responsable = usuario.id, Id = usuario.id });
            return resultado > 0;
        }

        public async Task<IEnumerable<usuario>> Obtener_Lista_Usuarios()
        {
            var db = dbConnection();
            var sql = @"
                         SELECT id, nombre, apellido, correo, contrasena, dni, telefono, id_rol
                         FROM usuario
                       ";
            return await db.QueryAsync<usuario>(sql, new {});
        }

        public async Task<bool> Ingresar_Usuario(usuario usuario)
        {
            var db = dbConnection();
            var sql = @"
                         INSERT INTO usuario (nombre, apellido,dni,correo,contrasena,telefono,id_rol)
                         VALUES (@Nombre,@Apellido,@Dni,@Correo,@Contrasena,@Telefono,@Id_rol)
                       ";
            var resultado = await db.ExecuteAsync(sql, new {usuario.id, usuario.nombre, usuario.apellido, usuario.dni, usuario.correo, usuario.contrasena, usuario.telefono, usuario.id_rol});
            return resultado > 0; 
        }

        public async Task<IEnumerable<proyecto_detalles>> Obtener_Lista_Proyectos()
        {
            var db = dbConnection();
            var sql = @"
                         select p.id,p.fecha_registro,p.id_usuario_responsable, u.nombre, u.apellido, p.nombre_proyecto
                         FROM proyecto as p, usuario as u WHERE p.id_usuario_responsable = u.id
                       ";
            return await db.QueryAsync<proyecto_detalles>(sql, new { });
        }

        public async Task<bool> Ingresar_Proyecto(proyecto proyecto)
        {
            var db = dbConnection();
            var sql = @"
                         INSERT INTO proyecto (fecha_registro, id_usuario_responsable, nombre_proyecto)
                         VALUES (CURRENT_DATE,@Id_usuario_responsable,@Nombre_proyecto)
                       ";
            var resultado = await db.ExecuteAsync(sql, new {proyecto.id,proyecto.fecha_registro, proyecto.id_usuario_responsable, proyecto.nombre_proyecto });
            return resultado > 0;
        }

        public async Task<autenticacion_usuario> Autenticacion_Usuario(int id, string correo, string contrasena)
        {
            var db = dbConnection();
            var sql = @"
                         SELECT u.id, u.correo, u.contrasena, u.id_rol, r.nombre_rol
                         FROM usuario as u,rol as r 
                         WHERE u.id_rol = r.id AND u.id = @Id AND u.correo = @Correo AND u.contrasena = @Contrasena
                       ";
            return await db.QueryFirstOrDefaultAsync<autenticacion_usuario>(sql, new {Id = id, Correo = correo, Contrasena = contrasena});
        }

        public async Task<IEnumerable<encargo_interno_detalles>> Obtener_Lista_Encargos()
        {
            var db = dbConnection();
            var sql = @"
                         SELECT e.id,e.tipo_encargo,e.fecha_solicitud,e.fecha_respuesta, e.id_usuario_solicitante,
                                u.nombre,u.apellido,p.nombre_proyecto,ei.nombre_estado,e.observacion
                         FROM encargo_interno as e, usuario as u, estado_encargo as ei, proyecto as p
                         WHERE e.id_usuario_solicitante = u.id AND e.id_proyecto = p.id
                               AND e.id_estado_encargo = ei.id
                       ";
            return await db.QueryAsync<encargo_interno_detalles>(sql, new { });
        }

        public async Task<bool> Actualizar_Proyecto(proyecto proyecto)
        {
            var db = dbConnection();
            var sql = @"
                         UPDATE proyecto
                         SET id_usuario_responsable = @Id_usuario_responsable,
                             nombre_proyecto = @Nombre_proyecto
                         WHERE id = @Id
                       ";
            var resultado = await db.ExecuteAsync(sql, new {proyecto.id_usuario_responsable,proyecto.nombre_proyecto,proyecto.id });
            return resultado > 0;
        }

        public async Task<bool> Registrar_Evaluacion(observacion_encargo observacion_encargo)
        {
            var db = dbConnection();
            var sql = @"
                         UPDATE encargo_interno
                         SET id_estado_encargo = @Id_estado_encargo,
                             observacion = @Observacion,
                             fecha_respuesta = CURRENT_DATE
                         WHERE id=@Id
                       ";
            var resultado = await db.ExecuteAsync(sql, new {observacion_encargo.id_estado_encargo ,observacion_encargo.observacion, observacion_encargo.fecha_respuesta , observacion_encargo.id});
            return resultado > 0;
        }

        public async Task<bool> Registrar_Encargo_Interno(encargo_interno encargo_interno)
        {
            var db = dbConnection();
            var sql = @"
                         INSERT INTO encargo_interno (tipo_encargo, fecha_solicitud, id_usuario_solicitante, id_proyecto, id_estado_encargo)
                         VALUES (@Tipo_encargo,CURRENT_DATE,@Id_usuario_solicitante,@Id_proyecto,4)
                       ";
            var resultado = await db.ExecuteAsync(sql, new { encargo_interno.id, encargo_interno.tipo_encargo, encargo_interno.fecha_solicitud, encargo_interno.id_usuario_solicitante, encargo_interno.id_proyecto, encargo_interno.id_estado_encargo});
            return resultado > 0;
        }

        public async Task<usuario> Obtener_Usuario(int id)
        {
            var db = dbConnection();
            var sql = @"
                         SELECT id, nombre, apellido, correo, contrasena, dni, telefono, id_rol
                         FROM usuario WHERE id = @Id
                       ";
            return await db.QueryFirstOrDefaultAsync<usuario>(sql, new { Id = id });
        }

        public async Task<proyecto_detalles> Obtener_Proyecto(int id)
        {
            var db = dbConnection();
            var sql = @"
                         select p.id,p.fecha_registro,p.id_usuario_responsable, u.nombre, u.apellido, p.nombre_proyecto
                         FROM proyecto as p, usuario as u WHERE p.id_usuario_responsable = u.id AND p.id = @Id
                       ";
            return await db.QueryFirstOrDefaultAsync<proyecto_detalles>(sql, new { Id = id });
        }

    }
}
