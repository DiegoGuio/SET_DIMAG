using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocioDimag.Models.Dto
{
    public class RegistroMedidasCorporalesPorUsuarioDto
    {
        public int Id { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int usuarioId { get; set; }

        public int GeneroId { get; set; }

        public int ContornoPecho { get; set; }

        public int ContornoCintura { get; set; }

        public int ContornoCadera { get; set; }

        public int LongitudHombro { get; set; }

        public string TallaSETDimag { get; set; }
    }
}
