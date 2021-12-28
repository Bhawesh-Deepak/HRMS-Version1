using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Helpers
{
    public static class PageHeader
    {
        public static IConfiguration HeaderSetting;

        static PageHeader()
        {
            HeaderSetting = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("PageHeaderTitle.json")
                   .Build();
        }
    }
}
