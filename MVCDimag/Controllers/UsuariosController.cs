using Microsoft.AspNetCore.Mvc;
using MVCDimag.Models;

namespace MVCDimag.Controllers
{
    public class UsuariosController : Controller
    {
        public UsuariosController() 
        
        {
        
        }

        [HttpPost]
        public void RegistrarOActualizarUsuario([FromBody] UsuarioViewModel usuario)
        {

        }
    }
}
