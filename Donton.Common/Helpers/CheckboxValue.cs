using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donton.Common.Helpers
{
    public static class CheckboxValue
    {
        public static bool ConvertValue(string value)
        {
            return (value == "on") ? true : false;
        }

        public static bool CheckValue(long? value)
        {
            var val = (value != 0 && value != null) ? true : false;
            return val;
        }
    }
}
