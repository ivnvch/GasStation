using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Station.BusinessLogic.Interfaces;

namespace Station.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefuellingController : ControllerBase
    {
        IRefuellingService _refuellingService;
        public RefuellingController(IRefuellingService refuellingService)
        {
            _refuellingService = refuellingService;
        }

        [HttpPost]
        public IActionResult Parser()
        {
            _refuellingService.Parser();
            return Ok();
        }
    }
}
