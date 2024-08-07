using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocioDimag.Models.Dto
{
    public class FotoDeUsuarioDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Path { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
