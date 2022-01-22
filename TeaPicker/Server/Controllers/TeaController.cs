using Microsoft.AspNetCore.Mvc;
using TeaPicker.Shared;

namespace TeaPicker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeaController : ControllerBase
    {
        private static List<Tea> Teas = new()
        {
            new() { Id = 1, Name = "Black", Description = "Typical black tea", BrewingTemp = 100, BrewingTime = 3, ImageUri = "https://media.istockphoto.com/photos/black-tea-in-glass-cup-picture-id177555555" }
        };

        // Read
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var coffee = Teas.Find(o => o.Id == id);

            if (coffee is not null)
            {
                return Ok(coffee);
            }

            return NotFound("Tea not found");
        }

        // Read
        [HttpGet("list")]
        public ActionResult List()
        {
            return Ok(Teas);
        }

        // Create
        [HttpPost]
        public ActionResult Create(Tea tea)
        {
            tea.Id = Teas.Count + 1;
            Teas.Add(tea);

            var newTea = Teas.Find(o => o.Id == tea.Id);

            return Ok(newTea);
        }

        // Update
        [HttpPut]
        public ActionResult Update(Tea newTea)
        {
            var oldTea = Teas.FirstOrDefault(o => o.Id == newTea.Id);

            if (oldTea is not null)
            {
                oldTea.Name = newTea.Name;
                oldTea.Description = newTea.Description;
                oldTea.BrewingTime = newTea.BrewingTime;
                oldTea.BrewingTemp = newTea.BrewingTemp;
                oldTea.ImageUri = newTea.ImageUri;

                return Ok(newTea);
            }

            return NotFound("Tea not found");
        }

        // Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tea = Teas.FirstOrDefault(o => o.Id == id);

            if (tea is not null)
            {
                Teas.Remove(tea);

                return Ok();
            }

            return NotFound("Tea not found");
        }
    }
}