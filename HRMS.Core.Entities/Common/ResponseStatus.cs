using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Entities.Common
{
    public enum ResponseStatus
    {
        Created=201,
        Deleted,
        Updated,
        Success,
        DataBaseException,
        CodeException,
        AlreadyExists
    }
}
