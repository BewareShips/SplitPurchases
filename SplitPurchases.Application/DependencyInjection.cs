using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SplitPurchases.Application.Application.Services.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                typeof(SplitPurchases.Application.Application.Commands.CreateUser.CreateUserCommandHandler).GetTypeInfo().Assembly
));
            services.AddScoped<IBalanceService, BalanceService>();
            return services;
        }
    }
}
