using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        [Required]
        public string Referencia { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string Estado { get; set; }
        public int ClienteId { get; set; }
        public int SucursalId { get; set; }
        public Cliente Cliente { get; set; }
        public Sucursal Sucursal { get; set; }
    }
}
