namespace MVCDimag.Models
{
    public class MedidaPorTallaYGeneroViewModel
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
