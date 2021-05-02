using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Areas.Admin.Models
{
    public class VehicleImageViewModel
    {
        [Display(Name = "Araç")]
        public int VehicleId { get; set; }

        [Display(Name = "Resim")]
        public IFormFile Image { get; set; }
    }
}