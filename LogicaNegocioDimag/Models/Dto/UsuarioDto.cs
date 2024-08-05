using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocioDimag.Models.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public int DepartamentoId { get; set; }

        public int CiudadOMunicipioId { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public string NombreUsuario { get; set; }

        public string Password { get; set; }
        public UsuarioDto()
        {
            PrimerNombre = string.Empty;
            SegundoNombre = string.Empty;
            PrimerApellido = string.Empty;
            SegundoApellido = string.Empty;
            Email = string.Empty;
            Celular = string.Empty;
            NombreUsuario = string.Empty;
            Password = string.Empty;
        }
    }
}
