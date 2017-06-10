using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class OrdenCompraConfiguration : EntityTypeConfiguration<OrdenCompra>
    {
        public OrdenCompraConfiguration()
        {

            ToTable("OrdenesCompra");
            HasKey(c => c.OrdenCompraId);

            
            HasRequired(c => c.Sucursal)
               .WithMany(c => c.OrdenCompras)
               .HasForeignKey(c => c.SucursalId);
        }
    }
}
