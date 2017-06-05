using Restaurante.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.Repositories
{
    public class UnityOfWork:IUnityOfWork
    {
        //variable que contendra el contexto de la base de datos
        private readonly RestauranteDbContext _Context;
        private static readonly object _Lock = new object();
        public IBebidaRepository Bebidas { get; private set; }
        public IClienteRepository Clientes { get; private set; }
        public IDepartamentoRepository Departamentos { get; private set; }
        public IDireccionRepository Direcciones { get; private set; }
        public IDistritoRepository Distritos { get; private set; }
        public IEncuestaRepository Encuestas { get; private set; }
        public IMesaRepository Mesas { get; private set; }
        public IMeseroRepository Meseros { get; private set; }
        public IOrdenCompraRepository OrdenesCompra { get; private set; }
        public IPedidoRepository Pedidos { get; private set; }
        public IPlatoRepository Platos { get; private set; }
        public IPreguntaRepository Preguntas { get; private set; }
        public IProveedorRepository Proveedores { get; private set; }
        public IProvinciaRepository Provincias { get; private set; }
        public IReservaRepository Reservas { get; private set; }
        public ISucursalRepository Sucursales { get; private set; }
        public ITipoBebidaRepository TipoBebidas { get; private set; }
        public ITipoCorreoRepository TipoCorreos { get; private set; }
        public ITipoTelefonoRepository TipoTelefonos { get; private set; }
        public IVentaRepository Ventas { get; private set; }

        public UnityOfWork()
        {
                
        }

        public UnityOfWork(RestauranteDbContext context)
        {
            _Context = context;

            Bebidas = new BebidaRepository(_Context);
            Clientes = new ClienteRepository(_Context);
            Departamentos = new DepartamentoRepository(_Context);
            Direcciones = new DireccionRepository(_Context);
            Distritos = new DistritoRepository(_Context);
            Encuestas = new EncuestaRepository(_Context);
            Mesas = new MesaRepository(_Context);
            Meseros = new MeseroRepository(_Context);
            OrdenesCompra = new OrdenCompraRepository(_Context);
            Pedidos = new PedidoRepository(_Context);
            Platos = new PlatoRepository(_Context);
            Preguntas = new PreguntaRepository(_Context);
            Proveedores = new ProveedorRepository(_Context);
            Reservas = new ReservaRepository(_Context);
            Sucursales = new SucursalRepository(_Context);
            TipoBebidas = new TipoBebidaRepository(_Context);
            TipoCorreos = new TipoCorreoRepository(_Context);
            TipoTelefonos = new TipoTelefonoRepository(_Context);
            Ventas = new VentaRepository(_Context);
        }

        public void Dispose()
        {
            _Context.Dispose();
        }

        //metodo que guarda los cambios. lleva los cambios en memoria hacia la base de datos.
        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        //metodo que cambia el estado de una entidad en el entityframework para que luego se cambie en la base de datos
        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
