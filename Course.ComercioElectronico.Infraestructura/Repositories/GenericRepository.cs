﻿using Course.ComercioElectronico.Dominio.Entities.Base;
using Course.ComercioElectronico.Dominio.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Infraestructura.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ComercioElectronicoDBContext context;

        public GenericRepository(ComercioElectronicoDBContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<T>> GetAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string code)
        {
            return await context.Set<T>().FindAsync(code);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    }
}
