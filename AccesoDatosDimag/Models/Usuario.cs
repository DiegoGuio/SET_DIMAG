using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosDimag.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string PrimerNombre { get; set; }

        [StringLength(15)]
        public string SegundoNombre { get; set; }

        [Required]
        [StringLength(15)]
        public string PrimerApellido { get; set; }
                
        [StringLength(15)]
        public string SegundoApellido { get; set; }

        [Required]
        [ForeignKey("Departamento")]
        public int DepartamentoId { get; set; }

        [Required]
        [ForeignKey("CiudadOMunicipio")]
        public int CiudadOMunicipioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Celular { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(60)]
        public string Password { get; set; }
        public Usuario() 
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
