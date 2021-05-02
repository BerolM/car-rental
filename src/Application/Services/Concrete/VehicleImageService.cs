using Application.Infrastructure.Persistence;
using Application.Services.Commons;
using Application.Utilities.FileUpload;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    internal class VehicleImageService : BaseService, IVehicleImageService
    {
        private IFileUploadService FileUploadService { get; }
        public VehicleImageService(ICarRentalDbContext context, IFileUploadService fileUploadService) : base(context)
        {
            FileUploadService = fileUploadService;
        }

        public async Task<Response> Add(VehicleImage vehicleImage, IFormFile file)
        {
            var fileUploadResult = await FileUploadService.Upload(file, "img/cars/");
            if (fileUploadResult.IsSuccess == false)
                return Response.Fail(fileUploadResult.Message);

            vehicleImage.ImageUrl = fileUploadResult.Data.Url;

            Context.VehicleImage.Add(vehicleImage);
            Context.SaveChanges();

            return Response.Success("Araç resmi başarıyla kaydedildi");
        }

        public Response Delete(int id)
        {
            var vehicleImageToDelete = GetById(id);

            var fileDeleteResult = FileUploadService.Delete(vehicleImageToDelete.ImageUrl);
            if (fileDeleteResult.IsSuccess == false)
                return fileDeleteResult;

            Context.VehicleImage.Remove(vehicleImageToDelete);
            Context.SaveChanges();

            return Response.Success("Araç resmi başarıyla silindi");
        }

        public VehicleImage GetById(int id)
        {
            return Context.VehicleImage.Where(i => i.Id == id).SingleOrDefault();
        }

        public List<VehicleImage> GetByVehicle(int vehicleId)
        {
            return Context.VehicleImage.Where(i => i.VehicleId == vehicleId).ToList();
        }
    }
}