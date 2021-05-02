using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IVehicleImageService
    {
        Task<Response> Add(VehicleImage vehicleImage, IFormFile file);
        Response Delete(int id);
        List<VehicleImage> GetByVehicle(int vehicleId);
        VehicleImage GetById(int id);
    }
}