using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class SucursalConfiguration:EntityTypeConfiguration<Sucursal>
    {
        public SucursalConfiguration()
        {
            ToTable("Sucursales");
            HasKey(c => c.SucursalId);

            HasRequired(c => c.Direccion)
                .WithRequiredPrincipal(c => c.Sucursal);
        }
    }
}
