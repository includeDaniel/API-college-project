using BD_BACK.Models;
using BD_BACK.ViewModels;
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

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ContactUsModel>> Put(ContactUsModel model)
        {
            ContactUsModel newClient = model;
            DbSet.Update(newClient);
            await Db.SaveChangesAsync();
            return Ok(newClient);
        }

        [HttpPost]
        public async Task<ActionResult<ContactUsViewModel>> Add(RequestContactUsViewModel model)
        {
            var newMessage = new ContactUsModel { Email = model.Email, Name = model.Name, Message = model.Message };
            DbSet.Add(newMessage);
            await Db.SaveChangesAsync();
            return Ok(newMessage);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ContactUsViewModel>> Delete(Guid id)
        {
            DbSet.Remove(new ContactUsModel { Id = id });
            await Db.SaveChangesAsync();
            return Ok("Removido com Sucesso");
        }
    }
}
