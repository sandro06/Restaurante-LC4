using System.ComponentModel.DataAnnotations;

namespace Restaurante.Entities
{
    public class Venta
    {
        public int VentaId { get; set; }
        [Required]
        public string TipoPago { get; set; }
        [Required]
        public string DetalleVenta { get; set; }

        public Pedido Pedido { get; set; }
    }
}