using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    class MesaConfiguration:EntityTypeConfiguration<Mesa>
    {
        public MesaConfiguration()
        {
            //Table Configurations
            ToTable("Mesa");
            HasKey(c => c.MesaId);
            //RC
            HasRequired(c => c.Sucursal)
                .WithMany(c => c.Mesas);

        }
    }
}
