using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNetCoreReact.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetCoreReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario _usuarios;

        public UsuariosController(IUsuario usuario)
        {
            _usuarios = usuario;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            return Ok(await _usuarios.GetAllUsuarios() );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuariosDetails(int id)
        {
            return Ok(await _usuarios.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] Models.Usuarios usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var create = await _usuarios.InsertUsuarios(usuario);

            return Created("created", create);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] Models.Usuarios usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _usuarios.UpdateUsuarios(usuario);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuarios.DeleteUsuarios(new Models.Usuarios { Id = id});

            return NoContent();
        }

        [HttpGet("username/password")]
        public async Task<IActionResult> IniciarSesion(string username, string password)
        {
            await 
        }

    }

   
}