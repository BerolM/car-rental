using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.DTOs;

namespace Application.Services
{
    public interface ITransmissionTypeService
    {
        Response Add(TransmissionType transmissionType);
        Response Update(TransmissionType transmissionType);
        Response Delete(int id);
        TransmissionType GetById(int id);
        List<TransmissionType> Get(TransmissionTypeFilter filter);
    }
}
