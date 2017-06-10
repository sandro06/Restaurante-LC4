using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    class TipoCorreoConfiguration : EntityTypeConfiguration<TipoCorreo>
    {
        public TipoCorreoConfiguration()
        {
            ToTable("TipoCorreos");
            HasKey(c => c.TipoCorreoId);

            HasRequired(c => c.Cliente)
                .WithMany(c => c.TipoCorreos)
                .HasForeignKey(c => c.ClienteId);
        }
    }
}
