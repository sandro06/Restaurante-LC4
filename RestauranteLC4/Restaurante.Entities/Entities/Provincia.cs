using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Provincia
    {
        public int ProvinciaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public List<Distrito> Distritos { get; set; }
        public Provincia()
        {
            Distritos = new List<Distrito>();
        }
    }
}
