using Donton.BusinessLogic.Contacts;
using Donton.Common.Helpers;
using Donton.Common.RequestResponses.Responses;
using Donton.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Donton.UserInterface.Pages.Contacts
{
    public class IndexModel : BasePageModel
    {
        private readonly ContactMaintenance _contactMaintenance;

        public IndexModel(IDependencyAggregate aggregate, ContactMaintenance contactMaintenance) : base(aggregate)
        {
            _contactMaintenance = contactMaintenance;
        }

        [BindProperty(SupportsGet = true)]
        public Contact Contact { get; set; }

        [BindProperty(SupportsGet = true)]
        public Holder Holder { get; set; }

        public List<spContactListResult> ContactList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ContactList = await _contactMaintenance.GetUserContacts(1);
            return Partial("List", ContactList);
        }

        public async Task<IActionResult> OnGetContactForm()
        {
            return Partial("Form", new Contact());
        }

        public async Task<IActionResult> OnPostSaveContact()
        {
            PostResponse response = await _contactMaintenance.SaveContactInfo(Contact);
            return new JsonResult(response);
        }

        public async Task<IActionResult> OnPostDeleteContact()
        {
            PostResponse response = await _contactMaintenance.DeleteContact(Holder.HolderId);
            return new JsonResult(response);
        }
    }

}