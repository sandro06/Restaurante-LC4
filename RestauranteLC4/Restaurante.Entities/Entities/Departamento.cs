using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Provincia> Provincias { get; set; }
        
    }
}
