using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class PreguntaConfiguration : EntityTypeConfiguration<Pregunta>
    {
        public PreguntaConfiguration()
        {

            ToTable("Preguntas");
            HasKey(c => c.PreguntaId);

            HasRequired(c => c.Encuesta)
                .WithMany(c => c.Preguntas);
        }
    }
}
