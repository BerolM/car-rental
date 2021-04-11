using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class VehicleClassType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
    }
}
