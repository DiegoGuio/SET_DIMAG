using AccesoDatosDimag.Models;
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
        /// <summary>
        /// Fncion para registar los usuarios nuevo
        /// </summary>
        /// <param name="usuarioDto"></param>
        /// <returns>1 Exitoso, 2 Usuario ya existe, 3 Fallido</returns>
        [HttpPost("RegistrarUsuario")]
        public int RegistrarUsuario([FromBody] UsuarioDto usuarioDto)
        {
            return _bL.RegistrarUsuario(usuarioDto);
        }
        /// <summary>
        /// Consultar informaciòn con el nombre de usuario
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns>Informaciòn del usuairo consultado</returns>
        [HttpGet("ConsultarUsuarioPorNombreUsuario")]
        public UsuarioDto ConsultarUsuarioPorNombreUsuario(string nombreUsuario)
        {
            return _bL.ConsultarUsuarioPorNombreUsuario(nombreUsuario);
        }
        /// <summary>
        /// Eliminación individual de usuarios
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns>True existosa, false fallida</returns>
        [HttpDelete("EliminarUsuarioPorNombreUsuario")]
        public bool EliminarUsuarioPorNombreUsuario(string nombreUsuario)
        {
            return _bL.EliminarUsuarioPorNombreUsuario(nombreUsuario);
        }
        /// <summary>
        /// Se obtiene el listado de generos disponibles
        /// </summary>
        /// <returns>Listado de generos con Id y nombre</returns>
        [HttpGet("ObtenerGeneros")]
        public List<GeneroDto> ObtenerGeneros()
        {
            return _bL.ObtenerGeneros();
        }
        /// <summary>
        /// Registra las medidas corporales de los usuarios y establece la talla adecuada
        /// </summary>
        /// <param name="data">Son las medidas corporales ingresadas por el usuario</param>
        /// <returns>Retorna los datos ingresados por el usuario, agrgandole la talla determinada y la fecha de  registro. Esta información se almacena en la base  de datos</returns>
        [HttpPost("RegistroMedidasCorporalesPorUsuario")]
        public RegistroMedidasCorporalesPorUsuarioDto RegistroMedidasCorporalesPorUsuario([FromBody] RegistroMedidasCorporalesPorUsuarioDto data)
        {
            return _bL.RegistroMedidasCorporalesPorUsuario(data);
        }

        [HttpPost("IniciarSesion")]
        public int IniciarSesion([FromBody]CredencialesUsuarioDto credenciales)
        {
            return _bL.IniciarSesion(credenciales);
        }
    }
}
