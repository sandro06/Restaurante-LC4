using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Encuesta
    {
        public int EncuestaId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string Resultado { get; set; }
        public int SucursalId { get; set; }
        public List<Pregunta> Preguntas { get; set; }
        public Sucursal Sucursal { get; set; }
       
    }
}
