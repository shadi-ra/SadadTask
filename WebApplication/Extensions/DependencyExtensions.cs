using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sadad.Core.ApplicationService.IRepository;
using Sadad.Core.ApplicationService.Services.User;
using Sadad.Infrastructure.EF.Repository;


namespace SadadWebApi.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddDependency(this IServiceCollection service)
        {
            AddRepositories(service);
            AddService(service);
        }

        public static void AddService(IServiceCollection service)
        {

            service.AddTransient<IUserService, UserService>();

        }

        public static void AddRepositories(IServiceCollection service)
        {
            service.AddTransient<IRepository<Sadad.Core.Entities.Model.User>, Repository<Sadad.Core.Entities.Model.User>>();
    
        }
    }
}
