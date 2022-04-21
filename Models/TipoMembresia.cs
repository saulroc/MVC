namespace MVC.Models
{
    public class TipoMembresia
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public short TarifaDeRegistro { get; set; }
        public byte DuracionEnMeses { get; set; }
        public byte Descuento {  get; set; }

    }
}
