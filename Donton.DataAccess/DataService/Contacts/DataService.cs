using Donton.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donton.DataAccess.DataService
{
    public partial class DataAccessService : IDataAccessService
    {

        public async Task<List<spContactListResult>> GetContactList(long userId)
        {
            return await _repository.Context.Procedures.spContactListAsync(userId);
        }

        public async Task<Contact> GetContactDetail(long contactId)
        {
            return await _repository.GetDetail<Contact>(p => p.ContactId == contactId);
        }

        public async Task<Contact> SaveContact(Contact model)
        {
            var checker_ = await _repository.CheckIfExist<Contact>(p => p.ContactNumber == model.ContactNumber);
            if (checker_ && model.ContactId == 0)
            {
                return new Contact();
            } else
            {
                var result = await _repository.UpdateRecord<Contact>(model);
                var saving_result = await _repository.SaveRecord();
                var retVal = Convert.ToBoolean(saving_result) == true ? result : new Contact();
                return retVal;
            }
         
        }

        public async Task<bool> DeleteContact(long contactId)
        {
            var result = await _repository.DeleteRecord<Contact>(p => p.ContactId == contactId);
            return result;
        }
    }
}
