using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Entities
{
    public class Mesero
    {
        public int MeseroId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string CarnetSanidad { get; set; }
        [Required]
        public double Sueldo { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public DateTime Fecha { get; set; }

        public Mesero()
        {
            Pedidos = new List<Pedido>();
        }

    }
}