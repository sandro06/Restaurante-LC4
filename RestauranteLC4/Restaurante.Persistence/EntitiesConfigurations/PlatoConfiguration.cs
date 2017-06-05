using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class PlatoConfiguration: EntityTypeConfiguration<Plato>
    {
            public PlatoConfiguration()
            {
                //Table Configurations
                ToTable("Plato");

                HasKey(c => c.PlatoId);
            }
        }
}


