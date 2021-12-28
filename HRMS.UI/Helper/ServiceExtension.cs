using HRMS.Services.Implementation.GenericImplementation;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.Extensions.DependencyInjection;


namespace HRMS.UI.Helper
{
    public static class ServiceExtension
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
