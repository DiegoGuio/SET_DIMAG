using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosDimag.Models
{
    public class RegistroMedidasCorporalesPorUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }
        
        [Required]
        [ForeignKey("Usuario")]
        public int usuarioId { get; set; }

        [Required]
        [ForeignKey("Genero")]
        public int GeneroId { get; set; }

        [Required]
        public int ContornoPecho { get; set; }

        [Required]
        public int ContornoCintura { get; set; }

        [Required]
        public int ContornoCadera { get; set; }

        [Required]
        public int LongitudHombro { get; set; }

        [Required]
        [StringLength(2)]
        public string TallaSETDimag { get; set; }
    }
}
