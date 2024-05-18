using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SplitPurchases.Application.Application.Services.Balance;
using System.Reflection;
using FluentValidation;
using SplitPurchases.Application.Common.Behaviors;
using SplitPurchases.Application.Application.Commands.CreateUser;


namespace SplitPurchases.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            typeof(SplitPurchases.Application.Application.Commands.CreateUser.CreateUserCommandHandler).GetTypeInfo().Assembly
        ));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IBalanceService, BalanceService>();
            return services;
        }
    }
}
