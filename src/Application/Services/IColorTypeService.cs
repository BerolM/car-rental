using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.DTOs;

namespace Application.Services
{
    public interface IColorTypeService
    {
        Response Add(ColorType colorType);
        Response Update(ColorType colorType);
        Response Delete(int id);
        ColorType GetById(int id);
        List<ColorType> Get(ColorTypeFilter filter);

    }
}
