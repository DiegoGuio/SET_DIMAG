using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosDimag.Models
{
    public class FotoDeUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(50)]
        public string Path { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }
    }
}
