using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class ProvinciaConfiguration:EntityTypeConfiguration<Provincia>
    {
        public ProvinciaConfiguration()
        {
            //Table Configuration
            ToTable("Provincias");
            HasKey(c => c.ProvinciaId);
            Property(c => c.Nombre).HasMaxLength(255);
            //Relationship Configuration
            HasRequired(c => c.Departamento).
                WithMany(c => c.Provincias);
            

        }
    }
}
