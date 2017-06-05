using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Pregunta
    {
        public int PreguntaId { get; set; }
        [Required]
        public string Contenido { get; set; }
        [Required]
        public string Estado { get; set; }
        public int EncuestaId { get; set; }
        public Encuesta Encuesta { get; set; }

    }
}
