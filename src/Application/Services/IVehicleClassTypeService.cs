using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IVehicleClassTypeService
    {
        Response Add(VehicleClassType vehicleClassType);
        Response Update(VehicleClassType vehicleClassType);
        Response Delete(int id);
        VehicleClassType GetById(int id);
        List<VehicleClassType> Get(VehicleClassTypeFilter filter);
    }
}
