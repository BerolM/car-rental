using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class VehicleImage
    {
        [Key]
        public int Id { get; set; }

        public int VehicleId { get; set; }

        [Display(Name = "Resim")]
        public string ImageUrl { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}