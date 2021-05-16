using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IVehicleService
    {
        Response Add(Vehicle vehicle);
        Response Update(Vehicle vehicle);
        Response Delete(int id);
        Vehicle GetById(int id);
        List<VehicleDTO> Get(VehicleFilter filter);
        VehicleDTO GetDetail(int id);
        List<VehicleListItemDTO> GetListItems(VehicleFilter filter);
    }
}
