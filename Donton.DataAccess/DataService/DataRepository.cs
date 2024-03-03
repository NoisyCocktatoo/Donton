using Donton.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Donton.DataAccess.DataService
{
    public class DataRepository : IDataRepository
    {
        private readonly DontonContext context_;
        public DataRepository(DontonContext context)
        {
            context_ = context;
        }

        public DontonContext Context
        {
            get
            {
                return context_;
            }
        }

        public async Task<List<TT>> GetList<TT>() where TT : class, new()
        {
            var result = await context_.Set<TT>().AsNoTracking().ToListAsync();
            return result ?? new List<TT>();
        }

        public async Task<List<TT>> GetList<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new()
        {
            var result = await context_.Set<TT>().Where(predicate).AsNoTracking().ToListAsync();
            return result ?? new List<TT>();
        }

        public async Task<bool> CheckIfExist<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new()
        {
            var result = await context_.Set<TT>().AnyAsync(predicate);
            return result;
        }

        public async Task<TT> GetDetail<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new()
        {
            var result = await context_.Set<TT>().AsNoTracking().FirstOrDefaultAsync(predicate);
            return result ?? new TT();
        }

        public async Task<TT> UpdateRecord<TT>(TT model) where TT : class, new()
        {
            context_.Update(model);
            return model;
        }

        public async Task<int> SaveRecord()
        {
            var retVal = await context_.SaveChangesAsync();
            return retVal;
        }

        public async Task<bool> DeleteRecord<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new()
        {
            int result = 0;
            var toDelete = await context_.Set<TT>().FirstOrDefaultAsync(predicate);
            if (toDelete is not null)
            {
                context_.Set<TT>().Remove(toDelete);
                result = await context_.SaveChangesAsync();
            }
            return Convert.ToBoolean(result);
        }
    }
}
