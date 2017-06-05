﻿using Restaurante.Entities;
using Restaurante.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.Repositories
{
    public class TipoTelefonoRepository : Repository<TipoTelefono>, ITipoTelefonoRepository
    {
        public TipoTelefonoRepository(RestauranteDbContext context) : base(context)
        {
        }
    }
}
