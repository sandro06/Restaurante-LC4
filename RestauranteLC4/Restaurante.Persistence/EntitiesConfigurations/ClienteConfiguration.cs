using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class ClienteConfiguration:EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            //Table Configurations
            ToTable("Clientes");
            HasKey(c => c.ClienteId);
            Property(c => c.ApeMat).HasMaxLength(255);
            Property(c => c.ApePat).HasMaxLength(255);
            Property(c => c.Dni).HasMaxLength(255);
            Property(c => c.Direccion).HasMaxLength(255);

            //Relations Configurations
            HasRequired(c => c.Pedido)
                 .WithMany(c => c.Clientes);
            HasRequired(c => c.Reserva)
                .WithRequiredPrincipal(c => c.Cliente);

        }
    }
}
