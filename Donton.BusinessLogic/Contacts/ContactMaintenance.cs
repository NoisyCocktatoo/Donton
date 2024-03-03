using Donton.Common.RequestResponses.Responses;
using Donton.DataAccess.DataService;
using Donton.DataAccess.Models;

namespace Donton.BusinessLogic.Contacts
{
    public class ContactMaintenance
    {
        private readonly IDataAccessService _dataAccessService;

        public ContactMaintenance(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        public async Task<List<spContactListResult>> GetUserContacts(long userId)
        {
            return await _dataAccessService.GetContactList(userId);
        }

        public async Task<Contact> GetContactInformation(long contactId)
        {
            return await _dataAccessService.GetContactDetail(contactId);
        }

        public async Task<PostResponse> SaveContactInfo(Contact contact)
        {
            Contact result = await _dataAccessService.SaveContact(contact);
            bool isSuccess = result.ContactId > 0;
            string message = isSuccess ? "Contact Saved" : "Contact already exists";

            return new PostResponse { IsSuccess = isSuccess, Id = result.ContactId, Message = message };
        }

        public async Task<PostResponse> DeleteContact(long contactId)
        {
            bool result = await _dataAccessService.DeleteContact(contactId);
            string message = result ? "Contact Deleted" : "Error in Deleting Contacts";
            return new PostResponse { IsSuccess = result, Message = message };
        }
    }
}
