using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosDimag.Models
{
    public class MedidaPorTallaYGenero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Generos")]
        public int GeneroId { get; set; }
        
        [Required]
        [StringLength(2)]
        public string Talla {  get; set; }
        
        [Required]
        public int ContornoMinimoPecho { get; set; }
        
        [Required]
        public int ContornoMaximoPecho { get; set; }
        
        [Required]
        public int ContornoMinimoCintura { get; set; }
        
        [Required]
        public int ContornoMaximoCintura { get; set; }
       
        [Required]
        public int ContornoMinimoCadera { get; set; }
        
        [Required]
        public int ContornoMaximoCadera { get; set; }
        
        [Required]
        public int LongitudMinimaHombro { get; set; }
        
        [Required]
        public int LongitudMaximaHombro { get; set; }
    }
}
