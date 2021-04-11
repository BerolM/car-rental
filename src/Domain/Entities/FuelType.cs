using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class FuelType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
