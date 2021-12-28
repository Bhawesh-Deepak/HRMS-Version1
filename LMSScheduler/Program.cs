using System;
using System.Linq;
using HRMS.Core.Entities.LeadManagement;
using HRMS.Services.Implementation.GenericImplementation;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LMSScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton(typeof(IGenericRepository<,>), typeof(Implementation<,>))
                .BuildServiceProvider();

            var customerDetailRepo = serviceProvider.GetService<IGenericRepository<CustomerDetail, int>>();
            var customerLeadRepo = serviceProvider.GetService<IGenericRepository<CustomerLeadDetail, int>>();

            var responseData = customerDetailRepo.GetAllEntities(x => x.IsActive && !x.IsDeleted).Result;

            responseData.Entities.ToList().ForEach(data=> {
                Console.Write(data.EmpCode);
            });

            Console.Read();
        }
    }
}
