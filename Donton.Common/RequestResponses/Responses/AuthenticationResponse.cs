using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donton.Common.RequestResponses.Responses
{
    public class AuthenticationResponse
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Contact { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }

    }
}
