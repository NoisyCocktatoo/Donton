using Donton.DataAccess.Models;

namespace Donton.DataAccess.DataService
{
    public interface IDataAccessService
    {
        Task<bool> DeleteContact(long contactId);
        Task<Contact> GetContactDetail(long contactId);
        Task<List<spContactListResult>> GetContactList(long userId);
        Task<Contact> SaveContact(Contact model);
    }
}