using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IVehicleModelService
    {
        Response Add(VehicleModel vehicleModel);
        Response Update(VehicleModel vehicleModel);
        Response Delete(int id);
        VehicleModel GetById(int id);
        List<VehicleModel> Get(VehicleModelFilter filter);
    }
}
