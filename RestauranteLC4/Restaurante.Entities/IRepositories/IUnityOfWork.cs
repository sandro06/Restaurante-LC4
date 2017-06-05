using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities.IRepositories
{
    public interface IUnityOfWork : IDisposable
    {
        IBebidaRepository Bebidas { get; }
        IClienteRepository Clientes { get; }
        IDepartamentoRepository Departamentos { get; }
        IDireccionRepository Direcciones { get; }
        IDistritoRepository Distritos { get; }
        IEncuestaRepository Encuestas { get; }
        IMesaRepository Mesas { get; }
        IMeseroRepository Meseros { get; }
        IOrdenCompraRepository OrdenesCompra { get; }
        IPedidoRepository Pedidos { get; }
        IPlatoRepository Platos { get; }
        IPreguntaRepository Preguntas { get; }
        IProveedorRepository Proveedores { get; }
        IProvinciaRepository Provincias { get; }
        IReservaRepository Reservas { get; }
        ISucursalRepository Sucursales { get; }
        ITipoBebidaRepository TipoBebidas { get; }
        ITipoCorreoRepository TipoCorreos { get; }
        ITipoTelefonoRepository TipoTelefonos { get; }
        IVentaRepository Ventas { get; }

        int SaveChanges();
        void StateModified(object entity);
    }
}
