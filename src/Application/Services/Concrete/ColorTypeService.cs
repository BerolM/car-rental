using Application.Services.Commons;
using Application.Infrastructure.Persistence;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class ColorTypeService : BaseService, IColorTypeService
    {
        public ColorTypeService(ICarRentalDbContext concent) :base(concent)
        {

        }
        public Response Add(ColorType colorType)
        {
            var chechResponse = ChechToAddOrUpdate(colorType);
            if (!chechResponse.IsSuccess)
                return chechResponse;

            Context.ColorType.Add(colorType);
            Context.SaveChanges();
            return Response.Success("Renk başarıyla kaydedildi");
        }
        private Response ChechToAddOrUpdate(ColorType colorType)
        {
            int sameNumberOfRecords = (from c in Context.ColorType
                                       where c.Name == colorType.Name && c.Id != colorType.Id
                                       select c
                                          ).Count();
            if (sameNumberOfRecords > 0)
            {
                return Response.Fail($"{colorType.Name} rengi sistemde zaten kayıtlıdır.");
            }
            return Response.Success();

        }
        public Response Update(ColorType colorType)
        {
            var checkResponse = ChechToAddOrUpdate(colorType);
            if (!checkResponse.IsSuccess)
                return checkResponse;
            var colorTypeToUpdate = GetById(colorType.Id);
            colorTypeToUpdate.Name = colorType.Name;
            Context.SaveChanges();
            return Response.Success("Renk başarıyla güncellendi.");
        }

        public Response Delete(int id)
        {
            var colorTypeToDelete = GetById(id);
            Context.ColorType.Remove(colorTypeToDelete);
            Context.SaveChanges();

            return Response.Success("Renk başarıyla silindi.");
        }

        public List<ColorType> Get(ColorTypeFilter filter)
        {
            var items = (from v in Context.ColorType
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }

        public ColorType GetById(int id)
        {
            return Context.ColorType.Where(v => v.Id == id).SingleOrDefault();
        }

        
    }
}
