using BD_BACK.Models;
using BD_BACK.ViewModels;
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

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ClientModel>> Put(ClientModel model)
        {
            ClientModel Client = model;
            DbSet.Update(Client);
            await Db.SaveChangesAsync();
            return Ok(Client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientViewModel>> Add(RequestClientViewModel model)
        {
            var newClient = new ClientModel { Email = model.Email, Name = model.Name };
            DbSet.Add(newClient);
            await Db.SaveChangesAsync();
            return Ok(newClient);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ClientModel>> Delete(Guid id)
        {
            DbSet.Remove(new ClientModel { Id = id });
            await Db.SaveChangesAsync();
            return Ok("Removido com Sucesso");
        }
    }

}
