using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donton.Common.Constants
{
    public class BatchUploadResponse
    {
        public const string NoDataFound = "No data found. Please provide the necessary information.";
        public const string MissingRequiredInfo = "Missing vital information, please fill all required fields.";
        public const string AllExist = "All uploaded data is already existing.";
        public const string SomeMissing = "File uploaded successfully, but some data missing due to required fields.";
        public const string Success = "Your batch data has been imported successfully.";
    }
}
