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

        [HttpPost("RegistrarOActualizarUsuario")]
        public bool RegistrarOActualizarUsuario(UsuarioDto usuarioDto)
        {
            return _bL.RegistrarOActualizarUsuario(usuarioDto);
        }

        [HttpGet("ConsultarUsuarioPorDocumentoIdentidad")]
        public UsuarioDto ConsultarUsuarioPorDocumentoIdentidad(int tipoDocumentoId, string numeroDocumento)
        {
            return _bL.ConsultarUsuarioPorDocumentoIdentidad(tipoDocumentoId, numeroDocumento);
        }

        [HttpDelete("EliminarUsuarioPorDocumentoIdentidad")]
        public bool EliminarUsuarioPorDocumentoIdentidad(int tipoDocumentoId, string numeroDocumento)
        {
            return _bL.EliminarUsuarioPorDocumentoIdentidad(tipoDocumentoId, numeroDocumento);
        }

    }
}
