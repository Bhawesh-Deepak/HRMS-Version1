using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Helpers.CommonHelper
{
    public static class StringHelper
    {
        public static T GetDefaultDBNull<T>(this string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                return default;
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
