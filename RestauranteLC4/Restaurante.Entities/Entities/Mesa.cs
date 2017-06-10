using System.ComponentModel.DataAnnotations;

namespace Restaurante.Entities
{
    public class Mesa
    {
        public int MesaId { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public int Capacidad { get; set; }
        [Required]
        public  string Estado { get; set; }
        
        public int SucursalId { get; set; }
        public Pedido Pedido { get; set; }
        public Sucursal Sucursal { get; set; }
    }
}