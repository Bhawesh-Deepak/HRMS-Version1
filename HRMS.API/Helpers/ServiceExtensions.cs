using HRMS.Services.Implementation.GenericImplementation;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.Extensions.DependencyInjection;


namespace HRMS.API.Helpers
{
    public static class ServiceExtensions
    {
        public static void AddService(this IServiceCollection service)
        {
            service.AddTransient(typeof(IGenericRepository<,>), typeof(Implementation<,>));
        }

    }
}
