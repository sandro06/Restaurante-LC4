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

            HasRequired(c => c.Proveedor)
               .WithRequiredPrincipal(c => c.OrdenCompra);
            HasRequired(c => c.Sucursal)
               .WithRequiredPrincipal(c => c.OrdenCompra);
        }
    }
}
