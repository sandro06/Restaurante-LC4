using Restaurante.Entities;
using Restaurante.Persistence.EntitiesConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence
{
    public class RestauranteDbContext:DbContext
    {

        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Mesero> Meseros { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<TipoBebida> TipoBebidas { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<OrdenCompra> OrdenesCompra { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<TipoTelefono> TipoTelefonos { get; set; }
        public DbSet<TipoCorreo> TipoCorreos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public RestauranteDbContext() : base("Restaurante")
		{

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartamentoConfiguration());
            modelBuilder.Configurations.Add(new DireccionConfiguration());
            modelBuilder.Configurations.Add(new DistritoConfiguration());
            modelBuilder.Configurations.Add(new ProvinciaConfiguration());
            modelBuilder.Configurations.Add(new SucursalConfiguration());
            modelBuilder.Configurations.Add(new EncuestaConfiguration());
            modelBuilder.Configurations.Add(new PreguntaConfiguration());
            modelBuilder.Configurations.Add(new OrdenCompraConfiguration());
            modelBuilder.Configurations.Add(new ProveedorConfiguration());
            modelBuilder.Configurations.Add(new TipoTelefonoConfiguration());
            modelBuilder.Configurations.Add(new TipoCorreoConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new PedidoConfiguration());
            modelBuilder.Configurations.Add(new ReservaConfiguration());
            modelBuilder.Configurations.Add(new BebidaConfiguration());
            modelBuilder.Configurations.Add(new MesaConfiguration());
            modelBuilder.Configurations.Add(new MeseroConfiguration());
            modelBuilder.Configurations.Add(new PlatoConfiguration());
            modelBuilder.Configurations.Add(new TipoBebidaConfiguration());
            modelBuilder.Configurations.Add(new VentaConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
