using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.DTOs;

namespace Application.Services
{
    public interface IFuelTypeService
    {
        Response Add(FuelType fuelType);
        Response Update(FuelType fuelType);
        Response Delete(int id);
        FuelType GetById(int id);
        List<FuelType> Get(FuelTypreFilter filter);

    }
}
