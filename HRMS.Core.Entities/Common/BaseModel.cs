using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Entities.Common
{
    /// <summary>
    /// Abstract class for base development put all the common code on this class 
    /// and inherit the class as per requirement
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseModel<T>
    {
        public T Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int FinancialYear { get; set; }
    }
}
