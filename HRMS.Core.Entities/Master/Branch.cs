using HRMS.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Entities.Master
{
    [Table("Branch", Schema ="Master")]
    public class Branch: BaseModel<int>
    {
        public string MyProperty { get; set; }
    }
}
