using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donton.DataAccess.DataService
{
    public partial class DataAccessService : IDataAccessService
    {
        private readonly IDataRepository _repository;
        private readonly IEmailService _emailService;
        public DataAccessService(IDataRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
    }
}
