using AutoMapper;
using ExpenseManager.DAL.Repositories.Expenses;
using ExpenseManager.Service.Mappings;
using ExpenseManager.Service.Services.Authentication;
using ExpenseManager.Service.Services.Expenses;
using System.ComponentModel.Design;
using Task.GenericRepository;

namespace ExpenseManager.API.Extensions
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            // Register All Services


            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExpenseService, ExpenseService>();


        }

        public static void AddRepos(this IServiceCollection services)
        {
            // Register all repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IExpenseRepository, ExpenseRepository>();



        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            // Manually configure AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile()); // Register your profiles here
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper); // Register IMapper as singleton
        }

    }
}
