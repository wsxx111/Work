using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WK.Data.Repository;
using WK.Domain.Entity.SystemSecurity;
using WK.Domain.IRepository.SystemSecurity;

namespace WK.Repository.SystemSecurity
{
    public class LogRepository : RepositoryBase<LogEntity>, ILogRepository
    {
    }
}
