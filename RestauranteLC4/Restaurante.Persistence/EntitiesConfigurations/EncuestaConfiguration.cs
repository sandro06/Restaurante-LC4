using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class EncuestaConfiguration : EntityTypeConfiguration<Encuesta>
    {
        public EncuestaConfiguration()
        {

            ToTable("Encuestas");
            HasKey(c => c.EncuestaId);

            HasRequired(c => c.Sucursal)
               .WithRequiredPrincipal(c => c.Encuesta);


        }
    }
}
