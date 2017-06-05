using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class DistritoConfiguration:EntityTypeConfiguration<Distrito>
    {
        public DistritoConfiguration()
        {
            ToTable("Distritos");
            HasKey(c => c.DistritoId);

            HasRequired(c => c.Provincia).
                WithMany(c => c.Distritos);
        }
    }
}
