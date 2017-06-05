using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class BebidaConfiguration:EntityTypeConfiguration<Bebida>
    {
        public BebidaConfiguration()
        {
            //Table Configurations
            ToTable("Bebidas");

            HasKey(c => c.BebidaId);

            //Relations Cofigurations
            HasRequired(c => c.TipoBebida)
                .WithMany(c => c.Bebidas);
        }
    }
}
