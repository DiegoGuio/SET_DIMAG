namespace MVCDimag.Models
{
    public class FotoDeUsuarioViewModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Path { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
