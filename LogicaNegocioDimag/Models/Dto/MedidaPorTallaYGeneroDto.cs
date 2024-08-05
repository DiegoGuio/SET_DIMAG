using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocioDimag.Models.Dto
{
    public class MedidaPorTallaYGeneroDto
    {
        public int Id { get; set; }

        public int GeneroId { get; set; }

        public string Talla { get; set; }

        public int ContornoMinimoPecho { get; set; }

        public int ContornoMaximoPecho { get; set; }

        public int ContornoMinimoCintura { get; set; }

        public int ContornoMaximoCintura { get; set; }

        public int ContornoMinimoCadera { get; set; }

        public int ContornoMaximoCadera { get; set; }

        public int LongitudMinimaHombro { get; set; }

        public int LongitudMaximaHombro { get; set; }
    }
}
