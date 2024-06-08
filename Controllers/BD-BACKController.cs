using Microsoft.AspNetCore.Mvc;

namespace BD_BACK.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BD_BACKController : ControllerBase
    {
        private readonly ILogger<BD_BACKController> _logger;
        public BD_BACKController(ILogger<BD_BACKController> logger)
        {
            _logger = logger;
        }
    }
}
