using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int VehicleBrandId { get; set; }
        public VehicleBrand VehicleBrand { get; set; }
    }
}
