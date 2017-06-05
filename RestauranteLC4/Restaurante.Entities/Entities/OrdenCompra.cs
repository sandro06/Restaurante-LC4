using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class OrdenCompra
    {
        public int OrdenCompraId { get; set; }
        [Required]
        public string Insumo { get; set; }
        [Required]
        public double Cantidad { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public int SucursalId { get; set; }
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        public Sucursal Sucursal { get; set; }
        
    }
}
