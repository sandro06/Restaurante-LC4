using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    class MeseroConfiguration:EntityTypeConfiguration<Mesero>
    {
        public MeseroConfiguration()
        {
            //Table Configurations
            ToTable("Meseros");

            HasKey(a => a.MeseroId);

            Property(a => a.Nombre).HasMaxLength(255);
                      

        }
                
    }
}
