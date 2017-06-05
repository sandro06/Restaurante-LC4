using Restaurante.Entities;
using Restaurante.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Restaurante.Persistence.Repositories
{
    public class SucursalRepository : Repository<Sucursal>, ISucursalRepository
    {
        public SucursalRepository(RestauranteDbContext context) : base(context)
        {
        }
    }
}
