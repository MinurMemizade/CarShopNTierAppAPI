using NTierApp.Bussiness.DTOs.Commons;
using App.Business.Helpers;
using NTierApp.Bussiness.Services.Abstractions;
using NTierApp.Bussiness.Services.Interfaces;
using App.Business.Validators.Commons;
using NTierApp.Shared.Abstractions;
using NTierApp.Shared.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Business
{
    public static class BusinessDependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddServices();
            
            services.AddControllers(options =>
            {
                options.Conventions.Add(new PluralizedRouteConvention());
                options.ModelValidatorProviders.Clear();
            })
           .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BaseEntityValidator<BaseEntityDTO>>())
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
           });

            return services;
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClaimService,ClaimService>();
            services.AddScoped<ICarService,CarService>();
            services.AddScoped<IAccountService,AccountService>();

            // External Services 
           
        }

        
    }
}