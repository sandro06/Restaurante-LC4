using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class TipoCorreo
    {
        public int TipoCorreoId { get; set; }
        [Required]
        public string Correo { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
