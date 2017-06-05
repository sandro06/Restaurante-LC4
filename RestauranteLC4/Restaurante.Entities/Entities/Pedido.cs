using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public double PrecioTotal { get; set; }
        public List<Cliente> Clientes { get; set; }
        public ICollection<Plato> Platos { get; set; }
        public ICollection<Bebida> Bebidas { get; set; }
        public Pedido()
        {
            Platos = new HashSet<Plato>();
            Bebidas = new HashSet<Bebida>();
        }
        public int MeseroId { get; set; }

        public Mesero Mesero { get; set; }

        public int VentaId { get; set; }

        public Venta Venta { get; set; }

        public int MesaId { get; set; }

        public Mesa Mesa { get; set; }
    }
}
