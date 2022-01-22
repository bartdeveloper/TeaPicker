using Microsoft.AspNetCore.Mvc;
using TeaPicker.Shared;

namespace TeaPicker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeaController : ControllerBase
    {
        private readonly ILogger<TeaController> _logger;

        public TeaController(ILogger<TeaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Tea> Get()
        {
            List<Tea> list = new();
            list.Add(new Tea() { Id = 1, Title = "Black", Description = "Typical tea"});
            return list;
        }
    }
}