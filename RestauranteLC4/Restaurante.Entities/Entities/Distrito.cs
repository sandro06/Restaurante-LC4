using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Distrito
    {
        public int DistritoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public List<Direccion> Direcciones { get; set; }
        public Distrito()
        {
            Direcciones = new List<Direccion>();
        }
    }
}
