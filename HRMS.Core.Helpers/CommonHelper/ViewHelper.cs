using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Helpers.CommonHelper
{
    public static class ViewHelper
    {
        public static string GetViewPathDetails(string folderName, string actionName) =>  $"~/Views/{folderName}/{actionName}.cshtml";
    }
}
