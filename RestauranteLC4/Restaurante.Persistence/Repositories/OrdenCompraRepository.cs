using Restaurante.Entities;
using Restaurante.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.Repositories
{
    public class OrdenCompraRepository : Repository<OrdenCompra>, IOrdenCompraRepository
    {
        public OrdenCompraRepository(RestauranteDbContext context) : base(context)
        {
        }
    }
}
