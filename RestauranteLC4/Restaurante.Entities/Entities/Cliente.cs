using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        [Required]
        public string ApeMat { get; set; }
        [Required]
        public string ApePat { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Direccion { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }

      
        public List<TipoTelefono> TipoTelefonos { get; set; }
        public List<TipoCorreo> TipoCorreos { get; set; }
    }
}
