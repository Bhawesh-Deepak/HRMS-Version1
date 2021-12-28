using HRMS.Services.Implementation.GenericImplementation;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Helpers
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Inject all the service to this class
        /// </summary>
        /// <param name="services"></param>
        public static void AddService(this IServiceCollection services)
        {
            #region GenericImplementationService 

            services.AddTransient(typeof(IGenericRepository<,>), typeof(Implementation<,>));

            #endregion
        }
    }
}
