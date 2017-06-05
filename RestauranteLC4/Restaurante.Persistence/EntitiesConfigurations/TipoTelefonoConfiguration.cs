using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class TipoTelefonoConfiguration:EntityTypeConfiguration<TipoTelefono>
    {
        public TipoTelefonoConfiguration()
        {
            //TC
            ToTable("TipoTelefonos");
            HasKey(c => c.TipoTelefonoId);
            //RC
            HasRequired(c => c.Cliente)
                .WithMany(c => c.TipoTelefonos);
        }
    }
}
