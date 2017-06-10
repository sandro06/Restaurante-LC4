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
        
        public Direccion Direccion { get; set; }
        public List<OrdenCompra> OrdenCompras { get; set; }
        public List<Encuesta> Encuestas { get; set; }
        
        public List<Mesa> Mesas { get; set; }
    }
}
