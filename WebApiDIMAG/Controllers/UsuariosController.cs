using LogicaNegocioDimag.BL;
using LogicaNegocioDimag.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDIMAG.Controllers
{
    public class UsuariosController : Controller
    {
        public readonly UsuariosBL _bL;

        public UsuariosController(UsuariosBL bL)
        {
            _bL = bL;
        }

        [HttpPost("RegistrarUsuario")]
        public int RegistrarUsuario([FromBody] UsuarioDto usuarioDto)
        {
            return _bL.RegistrarUsuario(usuarioDto);
        }

        [HttpGet("ConsultarUsuarioPorNombreUsuario")]
        public UsuarioDto ConsultarUsuarioPorNombreUsuario(string nombreUsuario)
        {
            return _bL.ConsultarUsuarioPorNombreUsuario(nombreUsuario);
        }

        [HttpDelete("EliminarUsuarioPorNombreUsuario")]
        public bool EliminarUsuarioPorNombreUsuario(string nombreUsuario)
        {
            return _bL.EliminarUsuarioPorNombreUsuario(nombreUsuario);
        }

    }
}
