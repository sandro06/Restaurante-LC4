using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class DireccionConfiguration:EntityTypeConfiguration<Direccion>
    {
        public DireccionConfiguration()
        {
            ToTable("Direcciones");
            HasKey(c => c.DireccionId);

            HasRequired(c => c.Distrito).
                WithMany(c => c.Direcciones);
            
        }
    }
}
