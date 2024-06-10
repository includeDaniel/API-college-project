using BD_BACK.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BD_BACK.Controllers
{
    [Route("api/ContactUs")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly ApplicationContext Db;
        private readonly DbSet<ContactUsModel> DbSet;
        private readonly ILogger<ContactUsModel> _logger;
        public ContactUsController(ILogger<ContactUsModel> logger, ApplicationContext db)
        {
            _logger = logger;
            Db = db;
            DbSet = db.Set<ContactUsModel>();
        }

        [HttpGet]
        public async Task<IEnumerable<ContactUsModel>> All()
        {
            return await DbSet.ToListAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<IEnumerable<ContactUsModel>> Get(Guid id)
        {
            return await DbSet
                .AsNoTracking()
                .Where(u => u.Id == id)
                .ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<IEnumerable<ContactUsModel>> Put(ContactUsModel newClient)
        {
            DbSet.Update(newClient);
            return await DbSet.ToListAsync();
        }

        [HttpPost]
        public async Task<IEnumerable<ContactUsModel>> Add(ContactUsModel newClient)
        {
            DbSet.Add(newClient);
            await Db.SaveChangesAsync();
            return await DbSet.ToListAsync();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IEnumerable<ContactUsModel>> Delete(Guid id)
        {
            DbSet.Remove(new ContactUsModel { Id = id });
            await Db.SaveChangesAsync();
            return await DbSet.ToListAsync();
        }
    }
}
