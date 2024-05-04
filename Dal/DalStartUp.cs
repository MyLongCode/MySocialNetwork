﻿
using Dal.User.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Logic
{
    public static class DalStartUp
    {
        public static IServiceCollection TryAddDal(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddScoped<IUserRepository, UserRepository>();
            return serviceCollection;
        }
    }
}