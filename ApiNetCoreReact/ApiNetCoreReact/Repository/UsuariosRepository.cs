using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiNetCoreReact.Context;
using ApiNetCoreReact.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiNetCoreReact.Repository
{
    public class UsuariosRepository : IUsuario
    {
        private readonly AppDbContext _connectionString;

        public UsuariosRepository(AppDbContext connection) { _connectionString = connection; }

        protected MySqlConnection dbContexto() { return new MySqlConnection(_connectionString.ConnectionStrings); }

        public Task<IEnumerable<Usuarios>> GetAllUsuarios()
        {
            var db = dbContexto();

            var sql = @"select * from usuarios";

            return  db.QueryAsync<Usuarios>(sql ,new { });
        }

        public Task<Usuarios> GetDetails(int id)
        {
            var db = dbContexto();

            var sql = @"select * from usuarios where id = @Id";


            return db.QueryFirstOrDefaultAsync<Usuarios>(sql, new { Id = id });
        }

        public async Task<bool> InsertUsuarios(Usuarios usuarios)
        {
            var db = dbContexto();

            var sql = @"insert from usuarios(nombre,apellido_paterno,apellido_materno,username,correo password)
                        values(@nombre,@apellido_paterno,@apellido_materno,@username,@correo, @password)";
            var result = await db.ExecuteAsync(sql, new
            {
                usuarios.Nombre,usuarios.Apellido_materno,usuarios.Apellido_paterno,
                usuarios.Correo,usuarios.Username,usuarios.Password
            });

            return result > 0;
        }

        public async Task<bool> UpdateUsuarios(Usuarios usuarios)
        {
            var db = dbContexto();

            var sql = @"update usuarios set
                            nombre = @nombre,
                            apellido_paterno = @apellido_paterno,
                            apellido_materno@apellido_materno,
                            username = @username,
                            correo = @correo,
                            password =  @password
                            where id = @Id
                        ";
            var result = await db.ExecuteAsync(sql, new
            {
                usuarios.Nombre,
                usuarios.Apellido_materno,
                usuarios.Apellido_paterno,
                usuarios.Correo,
                usuarios.Username,
                usuarios.Password
            });

            return result > 0;
        }

        public Task<bool> DeleteUsuarios(Usuarios usuarios)
        {
            throw new NotImplementedException();
        }

        public Task<Usuarios> GetUsuarios(string username, string password)
        {
            var db = dbContexto();

            var sql = @"select * from usuarios where username = @username and password = @password";

            return db.QueryFirstOrDefaultAsync<Usuarios>(sql, new { Username = username,Password = password });
        }
    }
}

