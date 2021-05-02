using Domain.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Application.Utilities.FileUpload.Concrete
{
    internal class PhysicalFileUploadService : IFileUploadService
    {
        private const string ROOT = "wwwroot/";

        public async Task<Response<FileUploadResult>> Upload(IFormFile file, string directory)
        {
            if (file == null || file.Length == 0)
                return Response<FileUploadResult>.Fail("Lütfen dosyayı seçiniz");

            string extension = file.FileName.Substring(file.FileName.LastIndexOf("."));
            string fileName = Guid.NewGuid().ToString().Replace("-", "") + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), ROOT, directory, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Response<FileUploadResult>.Success("", new FileUploadResult
            {
                //      img/cars/clio.jpg
                Url = $"{directory}{fileName}"
            });
        }

        public Response Delete(string path)
        {//path: img/cars/clio.jpg
            path = ROOT + path; //   wwwroot/img/cars/clio.jpg
            if (File.Exists(path))
            {
                File.Delete(path);
                return Response.Success();
            }
            else
            {
                return Response.Fail("Dosya bulunamadı");
            }
        }

    }
}