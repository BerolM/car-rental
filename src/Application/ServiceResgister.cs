using Application.Infrastructure.Persistence;
using Application.Services;
using Application.Services.Concrete;
using Application.Utilities.FileUpload;
using Application.Utilities.FileUpload.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IFileUploadService, PhysicalFileUploadService>();
            services.AddSingleton<IHashService, HashService>();

            services.AddDbContext<CarRentalDbContext>();
            services.AddScoped<ICarRentalDbContext>(provider => provider.GetService<CarRentalDbContext>());

            services.AddScoped<IVehicleBrandService, VehicleBrandService>();
            services.AddScoped<IVehicleModelService, VehicleModelService>();
            services.AddScoped<IColorTypeService, ColorTypeService>();
            services.AddScoped<IFuelTypeService, FuelTypeService>();
            services.AddScoped<IRentalPeriodService, RentalPeriodService>();
            services.AddScoped<ITireTypeService, TireTypeService>();
            services.AddScoped<ITransmissionTypeService, TransmissionTypeService>();
            services.AddScoped<IVehicleClassTypeService, VehicleClassTypeService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehicleRentalPriceService, VehicleRentalPriceService>();
            services.AddScoped<IVehicleImageService, VehicleImageService>();
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserOperationClaimService, UserOperationClaimService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();

            return services;
        }
    }
}