using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class VehicleClassType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Adı")]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
