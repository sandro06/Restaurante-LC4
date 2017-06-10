using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Ruc { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Correo { get; set; }
        public OrdenCompra OrdenCompra { get; set; }
        public int OrdenCompraId { get; set; }

    }
}
