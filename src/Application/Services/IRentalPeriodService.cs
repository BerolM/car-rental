using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IRentalPeriodService
    {
        Response Add(RentalPeriod rentalPeriod);
        Response Update(RentalPeriod rentalPeriod);
        Response Delete(int id);
        RentalPeriod GetById(int id);
        List<RentalPeriod> Get(RentalPeriodFilter filter);
    }
}
