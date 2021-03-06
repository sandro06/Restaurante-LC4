﻿using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class ProveedorConfiguration : EntityTypeConfiguration<Proveedor>
    {
        public ProveedorConfiguration()
        {

            ToTable("Proveedores");

            HasKey(c => c.ProveedorId);
            HasRequired(c => c.OrdenCompra)
                .WithMany(c => c.Proveedores)
                .HasForeignKey(c => c.OrdenCompraId);

        }
    }
}