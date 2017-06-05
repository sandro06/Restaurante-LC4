using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
   public class VentaConfiguration: EntityTypeConfiguration<Venta>
    {
            public VentaConfiguration()
            {
                //Table Configurations
                ToTable("Venta");

                HasKey(c => c.VentaId);

            }
        }
    }

