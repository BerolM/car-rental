using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITireTypeService
    {
        Response Add(TireType tireType);
        Response Update(TireType tireType);
        Response Delete(int id);
        TireType GetById(int id);
        List<TireType> Get(TireTypeFilter filter);
    }
}
