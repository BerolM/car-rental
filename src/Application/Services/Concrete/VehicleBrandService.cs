using Application.Infrastructure.Persistence;
using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Concrete
{
    public class VehicleBrandService:IVehicleBrandService
    {
        private ICarRentalDbContext Context { get; }
        public VehicleBrandService(ICarRentalDbContext context)
        {
            Context = context;
        }
        public void Add(VehicleBrand vehicleBrand)
        {
            Context.VehicleBrand.Add(vehicleBrand);
            Context.SaveChanges();
        }
        public void Update(VehicleBrand vehicleBrand)
        {
            var vehicleBrandToUpdate = GetById(vehicleBrand.Id);
            vehicleBrandToUpdate.Name = vehicleBrand.Name;
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            var vehicleBrandToDelete = GetById(id);
            Context.VehicleBrand.Remove(vehicleBrandToDelete);
            Context.SaveChanges();
        }
        public VehicleBrand GetById(int id)
        {
            return Context.VehicleBrand.Where(v => v.Id == id).SingleOrDefault();
        }
        public List<VehicleBrand> Get(VehicleBrandFilter filter)
        {
            var items = (from v in Context.VehicleBrand
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }
        public string GetName()
        {
            return "Vehicle brand service";
        }
    }
   
}
