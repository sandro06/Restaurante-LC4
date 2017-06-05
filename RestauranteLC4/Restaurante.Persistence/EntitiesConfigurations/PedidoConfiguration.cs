using Restaurante.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.EntitiesConfigurations
{
    public class PedidoConfiguration:EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            //TC
            ToTable("Pedidos");
            HasKey(c => c.PedidoId);
            //RC
            HasRequired(c => c.Mesero)
               .WithMany(c => c.Pedidos);

            HasRequired(c => c.Venta)
                .WithRequiredPrincipal(c => c.Pedido);

            HasRequired(c => c.Mesa)
                .WithRequiredPrincipal(c => c.Pedido);

            HasMany(c => c.Platos)
                .WithMany(c => c.Pedidos)
                .Map(m =>
                {
                    m.ToTable("PedidoPlatos");
                    m.MapLeftKey("PedidoId");
                    m.MapRightKey("PlatoId");
                });

            HasMany(c => c.Bebidas)
                .WithMany(c => c.Pedidos)
                .Map(m =>
                {
                    m.ToTable("PedidoBebidas");
                    m.MapLeftKey("PedidoId");
                    m.MapRightKey("BebidaId");
                });
        }
    }
}
