using Microsoft.AspNetCore.Mvc;
using TeaPicker.DataAccess.Models;
using TeaPicker.Server.Services;

namespace TeaPicker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeaController : ControllerBase
    {
        private readonly ITeaService _teaService;

        public TeaController(ITeaService teaService)
        {
            _teaService = teaService;
        }

        // Create
        [HttpPost]
        public ActionResult Create(Tea tea)
        {
      
            var newTea = _teaService.Create(tea);

            return Ok(newTea);
        }

        // Read
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var tea = _teaService.Get(id);

            if (tea is not null)
            {
                return Ok(tea);
            }

            return NotFound("Tea not found");
        }

        // Read
        [HttpGet("list")]
        public ActionResult List()
        {
            return Ok(_teaService.List());
        }

        // Update
        [HttpPut]
        public ActionResult Update(Tea newTea)
        {
            var res = _teaService.Update(newTea);

            if (res is not null)
            {
                return Ok(newTea);
            }

            return NotFound("Tea not found");
        }

        // Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var res = _teaService.Delete(id);

            if (res)
            {
                return Ok();
            }

            return NotFound("Tea not found");
        }
    }
}