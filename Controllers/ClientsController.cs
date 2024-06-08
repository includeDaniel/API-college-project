using BD_BACK.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BD_BACK.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        public DbSet<Clients> Db;
        private readonly ILogger<ClientsController> _logger;
        public ClientsController(ILogger<ClientsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetClients")]
        public async Task<IEnumerable<Clients>> Get()
        {
            return await Db.ToListAsync();

        }
    }
}
