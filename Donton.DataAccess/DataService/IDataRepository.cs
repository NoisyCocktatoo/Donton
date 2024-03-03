using Donton.DataAccess.Contexts;
using System.Linq.Expressions;

namespace Donton.DataAccess.DataService
{
    public interface IDataRepository
    {
        DontonContext Context { get; }

        Task<bool> CheckIfExist<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new();
        Task<bool> DeleteRecord<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new();
        Task<TT> GetDetail<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new();
        Task<List<TT>> GetList<TT>() where TT : class, new();
        Task<List<TT>> GetList<TT>(Expression<Func<TT, bool>> predicate) where TT : class, new();
        Task<int> SaveRecord();
        Task<TT> UpdateRecord<TT>(TT model) where TT : class, new();
    }
}