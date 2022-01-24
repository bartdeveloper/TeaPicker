using System.ComponentModel.DataAnnotations;

namespace TeaPicker.DataAccess.Models
{
    public class Tea
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(1024, ErrorMessage = "The description is too long, try a shorter one (1024 characters limit)")]
        public string Description { get; set; }

        [Required]
        [Range(0.0, 100)]
        public double BrewingTemp { get; set; }

        [Required]
        [Range(1, 15)]
        public double BrewingTime { get; set; }

        public string? ImageUri { get; set; }
    }
}