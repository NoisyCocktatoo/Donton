using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donton.Common.RequestResponses.Responses
{
    public class PostResponse
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
