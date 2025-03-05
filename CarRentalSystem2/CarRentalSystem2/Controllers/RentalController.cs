using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        [HttpGet]
        public IActionResult List()
        {
            return Ok("RentalController");
        }
    }
}
