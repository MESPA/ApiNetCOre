using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiNetCoreReact.Models;

namespace ApiNetCoreReact.Repository
{
    public interface IUsuario
    {
        Task<IEnumerable<Usuarios>> GetAllUsuarios();
        Task<Usuarios> GetDetails(int id);
        Task<Usuarios> GetUsuarios(string username, string password);
        Task<bool> InsertUsuarios(Usuarios usuarios);
        Task<bool> UpdateUsuarios(Usuarios usuarios);
        Task<bool> DeleteUsuarios(Usuarios usuarios);
    }
}

