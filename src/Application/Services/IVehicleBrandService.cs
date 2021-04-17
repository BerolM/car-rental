using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;


namespace Application.Services
{
    public interface IVehicleBrandService
    {
        void Add(VehicleBrand vehicleBrand);
        void Update(VehicleBrand vehicleBrand);
        void Delete(int id);
        VehicleBrand GetById(int id);
        List<VehicleBrand> Get(VehicleBrandFilter filter);

        string GetName();

    }
}
