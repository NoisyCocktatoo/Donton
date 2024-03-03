using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donton.Common.Helpers
{
    public class Configurations
    {
        public string Client { get; set; }
        public string SecretKey { get; set; }
    }

    public class DBConfig
    {
        public string Server { get; set; }
        public string DBName { get; set; }
        public string DBUser { get; set; }
        public string DBPassword { get; set; }
    }
}
