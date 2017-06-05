using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class DepartamentoConfiguration : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoConfiguration()
        {
            //Table Configuration
            ToTable("Departamentos");
            HasKey(c => c.DepartamentoId);
            Property(c => c.Nombre).HasMaxLength(255);



            //Relationship Configuration
        }
    }
}
