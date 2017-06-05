using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class TipoBebidaConfiguration : EntityTypeConfiguration<TipoBebida>
    {
        public TipoBebidaConfiguration()
        {
            //Table Configurations
            ToTable("TipoBebida");

            HasKey(a => a.TipoBebidaId);

            Property(tb => tb.TipoBebidaId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            Property(a => a.Nombre).HasMaxLength(255);

        }
    }
}

