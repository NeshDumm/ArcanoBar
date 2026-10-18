using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCombos()
        {
            var combos = new[] { "COMBO: SAPO" };
            return Ok(combos);
        }
    }
}
