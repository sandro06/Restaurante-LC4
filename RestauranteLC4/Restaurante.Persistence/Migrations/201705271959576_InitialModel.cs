namespace Restaurante.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bebidas",
                c => new
                    {
                        BebidaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Precio = c.Double(nullable: false),
                        Imagen = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        TipoBebidaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BebidaId)
                .ForeignKey("dbo.TipoBebida", t => t.TipoBebidaId, cascadeDelete: true)
                .Index(t => t.TipoBebidaId);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        PrecioTotal = c.Double(nullable: false),
                        MeseroId = c.Int(nullable: false),
                        VentaId = c.Int(nullable: false),
                        MesaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Meseros", t => t.MeseroId, cascadeDelete: true)
                .Index(t => t.MeseroId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false),
                        ApeMat = c.String(nullable: false, maxLength: 255),
                        ApePat = c.String(nullable: false, maxLength: 255),
                        Dni = c.String(nullable: false, maxLength: 255),
                        Direccion = c.String(nullable: false, maxLength: 255),
                        PedidoId = c.Int(nullable: false),
                        ReservaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Pedidos", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Reservas", t => t.ClienteId)
                .Index(t => t.ClienteId)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        ReservaId = c.Int(nullable: false, identity: true),
                        Referencia = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Estado = c.String(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        SucursalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservaId)
                .ForeignKey("dbo.Sucursales", t => t.SucursalId, cascadeDelete: true)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.Sucursales",
                c => new
                    {
                        SucursalId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false),
                        DireccionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SucursalId)
                .ForeignKey("dbo.Encuestas", t => t.SucursalId)
                .ForeignKey("dbo.OrdenesCompra", t => t.SucursalId)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.Direcciones",
                c => new
                    {
                        DireccionId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false),
                        DistritoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DireccionId)
                .ForeignKey("dbo.Distritos", t => t.DistritoId, cascadeDelete: true)
                .ForeignKey("dbo.Sucursales", t => t.DireccionId)
                .Index(t => t.DireccionId)
                .Index(t => t.DistritoId);
            
            CreateTable(
                "dbo.Distritos",
                c => new
                    {
                        DistritoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        ProvinciaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistritoId)
                .ForeignKey("dbo.Provincias", t => t.ProvinciaId, cascadeDelete: true)
                .Index(t => t.ProvinciaId);
            
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        ProvinciaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 255),
                        DepartamentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinciaId)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId, cascadeDelete: true)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Encuestas",
                c => new
                    {
                        EncuestaId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Resultado = c.String(nullable: false),
                        SucursalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EncuestaId);
            
            CreateTable(
                "dbo.Preguntas",
                c => new
                    {
                        PreguntaId = c.Int(nullable: false, identity: true),
                        Contenido = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                        EncuestaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PreguntaId)
                .ForeignKey("dbo.Encuestas", t => t.EncuestaId, cascadeDelete: true)
                .Index(t => t.EncuestaId);
            
            CreateTable(
                "dbo.Mesa",
                c => new
                    {
                        MesaId = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Capacidad = c.Int(nullable: false),
                        Estado = c.String(nullable: false),
                        PedidoId = c.Int(nullable: false),
                        SucursalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MesaId)
                .ForeignKey("dbo.Sucursales", t => t.SucursalId, cascadeDelete: true)
                .ForeignKey("dbo.Pedidos", t => t.MesaId)
                .Index(t => t.MesaId)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.OrdenesCompra",
                c => new
                    {
                        OrdenCompraId = c.Int(nullable: false, identity: true),
                        Insumo = c.String(nullable: false),
                        Cantidad = c.Double(nullable: false),
                        Precio = c.Double(nullable: false),
                        SucursalId = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrdenCompraId);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        ProveedorId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false),
                        Ruc = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Correo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProveedorId)
                .ForeignKey("dbo.OrdenesCompra", t => t.ProveedorId)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "dbo.TipoCorreos",
                c => new
                    {
                        TipoCorreoId = c.Int(nullable: false, identity: true),
                        Correo = c.String(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoCorreoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.TipoTelefonos",
                c => new
                    {
                        TipoTelefonoId = c.Int(nullable: false, identity: true),
                        Numero = c.String(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoTelefonoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Meseros",
                c => new
                    {
                        MeseroId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 255),
                        CarnetSanidad = c.String(nullable: false),
                        Sueldo = c.Double(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MeseroId);
            
            CreateTable(
                "dbo.Plato",
                c => new
                    {
                        PlatoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Precio = c.Double(nullable: false),
                        Imagen = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        TipoPlato = c.String(),
                    })
                .PrimaryKey(t => t.PlatoId);
            
            CreateTable(
                "dbo.Venta",
                c => new
                    {
                        VentaId = c.Int(nullable: false),
                        TipoPago = c.String(nullable: false),
                        DetalleVenta = c.String(nullable: false),
                        PedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VentaId)
                .ForeignKey("dbo.Pedidos", t => t.VentaId)
                .Index(t => t.VentaId);
            
            CreateTable(
                "dbo.TipoBebida",
                c => new
                    {
                        TipoBebidaId = c.Int(nullable: false),
                        Nombre = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.TipoBebidaId);
            
            CreateTable(
                "dbo.PedidoBebidas",
                c => new
                    {
                        PedidoId = c.Int(nullable: false),
                        BebidaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PedidoId, t.BebidaId })
                .ForeignKey("dbo.Pedidos", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Bebidas", t => t.BebidaId, cascadeDelete: true)
                .Index(t => t.PedidoId)
                .Index(t => t.BebidaId);
            
            CreateTable(
                "dbo.PedidoPlatos",
                c => new
                    {
                        PedidoId = c.Int(nullable: false),
                        PlatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PedidoId, t.PlatoId })
                .ForeignKey("dbo.Pedidos", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Plato", t => t.PlatoId, cascadeDelete: true)
                .Index(t => t.PedidoId)
                .Index(t => t.PlatoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bebidas", "TipoBebidaId", "dbo.TipoBebida");
            DropForeignKey("dbo.Venta", "VentaId", "dbo.Pedidos");
            DropForeignKey("dbo.PedidoPlatos", "PlatoId", "dbo.Plato");
            DropForeignKey("dbo.PedidoPlatos", "PedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.Pedidos", "MeseroId", "dbo.Meseros");
            DropForeignKey("dbo.Mesa", "MesaId", "dbo.Pedidos");
            DropForeignKey("dbo.TipoTelefonos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.TipoCorreos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Reservas", "SucursalId", "dbo.Sucursales");
            DropForeignKey("dbo.Sucursales", "SucursalId", "dbo.OrdenesCompra");
            DropForeignKey("dbo.Proveedores", "ProveedorId", "dbo.OrdenesCompra");
            DropForeignKey("dbo.Mesa", "SucursalId", "dbo.Sucursales");
            DropForeignKey("dbo.Sucursales", "SucursalId", "dbo.Encuestas");
            DropForeignKey("dbo.Preguntas", "EncuestaId", "dbo.Encuestas");
            DropForeignKey("dbo.Direcciones", "DireccionId", "dbo.Sucursales");
            DropForeignKey("dbo.Direcciones", "DistritoId", "dbo.Distritos");
            DropForeignKey("dbo.Distritos", "ProvinciaId", "dbo.Provincias");
            DropForeignKey("dbo.Provincias", "DepartamentoId", "dbo.Departamentos");
            DropForeignKey("dbo.Clientes", "ClienteId", "dbo.Reservas");
            DropForeignKey("dbo.Clientes", "PedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.PedidoBebidas", "BebidaId", "dbo.Bebidas");
            DropForeignKey("dbo.PedidoBebidas", "PedidoId", "dbo.Pedidos");
            DropIndex("dbo.PedidoPlatos", new[] { "PlatoId" });
            DropIndex("dbo.PedidoPlatos", new[] { "PedidoId" });
            DropIndex("dbo.PedidoBebidas", new[] { "BebidaId" });
            DropIndex("dbo.PedidoBebidas", new[] { "PedidoId" });
            DropIndex("dbo.Venta", new[] { "VentaId" });
            DropIndex("dbo.TipoTelefonos", new[] { "ClienteId" });
            DropIndex("dbo.TipoCorreos", new[] { "ClienteId" });
            DropIndex("dbo.Proveedores", new[] { "ProveedorId" });
            DropIndex("dbo.Mesa", new[] { "SucursalId" });
            DropIndex("dbo.Mesa", new[] { "MesaId" });
            DropIndex("dbo.Preguntas", new[] { "EncuestaId" });
            DropIndex("dbo.Provincias", new[] { "DepartamentoId" });
            DropIndex("dbo.Distritos", new[] { "ProvinciaId" });
            DropIndex("dbo.Direcciones", new[] { "DistritoId" });
            DropIndex("dbo.Direcciones", new[] { "DireccionId" });
            DropIndex("dbo.Sucursales", new[] { "SucursalId" });
            DropIndex("dbo.Reservas", new[] { "SucursalId" });
            DropIndex("dbo.Clientes", new[] { "PedidoId" });
            DropIndex("dbo.Clientes", new[] { "ClienteId" });
            DropIndex("dbo.Pedidos", new[] { "MeseroId" });
            DropIndex("dbo.Bebidas", new[] { "TipoBebidaId" });
            DropTable("dbo.PedidoPlatos");
            DropTable("dbo.PedidoBebidas");
            DropTable("dbo.TipoBebida");
            DropTable("dbo.Venta");
            DropTable("dbo.Plato");
            DropTable("dbo.Meseros");
            DropTable("dbo.TipoTelefonos");
            DropTable("dbo.TipoCorreos");
            DropTable("dbo.Proveedores");
            DropTable("dbo.OrdenesCompra");
            DropTable("dbo.Mesa");
            DropTable("dbo.Preguntas");
            DropTable("dbo.Encuestas");
            DropTable("dbo.Departamentos");
            DropTable("dbo.Provincias");
            DropTable("dbo.Distritos");
            DropTable("dbo.Direcciones");
            DropTable("dbo.Sucursales");
            DropTable("dbo.Reservas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Pedidos");
            DropTable("dbo.Bebidas");
        }
    }
}
