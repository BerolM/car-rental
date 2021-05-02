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

            services.AddScoped<IVehicleImageService, VehicleImageService>();

            return services;
        }
    }
}