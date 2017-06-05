using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Direccion
    {
        public int DireccionId { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public int DistritoId { get; set; }
       
        public Distrito Distrito { get; set; }
        public Sucursal Sucursal { get; set; }

    }
}
