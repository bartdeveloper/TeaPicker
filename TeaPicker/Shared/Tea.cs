using System.ComponentModel.DataAnnotations;

namespace TeaPicker.Shared
{
    public class Tea
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double BrewingTemp { get; set; }

        [Required]
        public double BrewingTime { get; set; }

        public string ImageUri { get; set; }
    }
}