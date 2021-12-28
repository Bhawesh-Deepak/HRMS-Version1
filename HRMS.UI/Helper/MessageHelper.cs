using Microsoft.Extensions.Configuration;
using System.IO;

namespace HRMS.UI.Helper
{
    public static class MessageHelper
    {
        public static IConfiguration AppSetting { get; }
        static MessageHelper()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appmessages.json")
                    .Build();
        }
    }
}
