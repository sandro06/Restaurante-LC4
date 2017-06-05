using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class ReservaConfiguration : EntityTypeConfiguration<Reserva>
    {
        public ReservaConfiguration()
        {
            //Table Configurations
            ToTable("Reservas");
            HasKey(c => c.ReservaId);

            HasRequired(c => c.Cliente)
               .WithRequiredPrincipal(c => c.Reserva);
            HasRequired(c => c.Sucursal)
                 .WithMany(c => c.Reservas);

        }
    }
}
