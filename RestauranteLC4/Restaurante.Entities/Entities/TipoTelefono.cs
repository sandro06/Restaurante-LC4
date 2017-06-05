using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class TipoTelefono
    {
        public int TipoTelefonoId { get; set; }
        [Required]
        public string Numero { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
