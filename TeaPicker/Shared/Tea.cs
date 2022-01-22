using System.ComponentModel.DataAnnotations;

namespace TeaPicker.Shared
{
    public class Tea
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double BrewingTemp { get; set; }

        [Required]
        public double BrewingTime { get; set; }
    }
}