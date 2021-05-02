using Domain.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Utilities.FileUpload
{
    public interface IFileUploadService
    {
        Task<Response<FileUploadResult>> Upload(IFormFile file, string directory);
        Response Delete(string path);
    }
}