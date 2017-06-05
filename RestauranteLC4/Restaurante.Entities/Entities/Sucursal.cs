using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Sucursal
    {
        public int SucursalId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int DireccionId { get; set; }
        public Direccion Direccion { get; set; }
        public OrdenCompra OrdenCompra { get; set; }
        public Encuesta Encuesta { get; set; }
        public List<Reserva> Reservas { get; set; }
        public List<Mesa> Mesas { get; set; }
    }
}
