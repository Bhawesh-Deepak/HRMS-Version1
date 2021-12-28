using HRMS.Services.Implementation.GenericImplementation;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Helper
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Inject all the service to this class
        /// </summary>
        /// <param name="services"></param>
        public static void AddService(this IServiceCollection services, IConfiguration configuration)
        {
            #region GenericImplementationService 

            services.AddTransient(typeof(IGenericRepository<,>), typeof(Implementation<,>));

            #endregion
        }
    }
}
