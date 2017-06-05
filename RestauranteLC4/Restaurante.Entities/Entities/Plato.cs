using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Entities
{
    public class Plato
    {
        public int PlatoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string TipoPlato { get; set; }

        public List<Pedido> Pedidos { get; set; }

        public Plato()
        {
            Pedidos = new List<Pedido>();
        }
    }
}