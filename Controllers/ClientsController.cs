using BD_BACK.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BD_BACK.Controllers
{

    [Route("api/Clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationContext Db;
        private readonly DbSet<ClientModel> DbSet;
        private readonly ILogger<ClientsController> _logger;
        public ClientsController(ILogger<ClientsController> logger, ApplicationContext db)
        {
            _logger = logger;
            Db = db;
            DbSet = db.Set<ClientModel>();
        }

        [HttpGet]
        public async Task<IEnumerable<ClientModel>> All()
        {

            return await DbSet.AsNoTracking().Include(c => c.Projects).ToListAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<IEnumerable<ClientModel>> Get(Guid id)
        {
            return await DbSet
                .AsNoTracking()
                .Where(u => u.Id == id)
                .ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<IEnumerable<ClientModel>> Put(ClientModel newClient)
        {
            DbSet.Update(newClient);
            return await DbSet.ToListAsync();
        }

        [HttpPost]
        public async Task<IEnumerable<ClientModel>> Add(ClientModel newClient)
        {
            DbSet.Add(newClient);
            await Db.SaveChangesAsync();
            return await DbSet.ToListAsync();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IEnumerable<ClientModel>> Delete(Guid id)
        {
            DbSet.Remove(new ClientModel { Id = id });
            await Db.SaveChangesAsync();
            return await DbSet.ToListAsync();
        }
    }

}
