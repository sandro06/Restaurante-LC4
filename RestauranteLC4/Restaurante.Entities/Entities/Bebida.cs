using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Entities
{
    public class Bebida
    {
        public int BebidaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public  int TipoBebidaId { get; set; }
        public TipoBebida TipoBebida { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public Bebida()
        {
            Pedidos = new List<Pedido>();
        }
    }
}