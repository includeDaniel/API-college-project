using BD_BACK.Models;
using BD_BACK.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BD_BACK.Controllers
{
    [Route("api/Projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationContext Db;
        private readonly DbSet<ProjectsModel> DbSet;
        private readonly ILogger<ProjectsController> _logger;
        public ProjectsController(ILogger<ProjectsController> logger, ApplicationContext db)
        {
            _logger = logger;
            Db = db;
            DbSet = db.Set<ProjectsModel>();
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectsModel>> All()
        {
            return await DbSet.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<IEnumerable<ProjectsModel>> Get(Guid id)
        {
            return await DbSet
                .AsNoTracking()
                .Where(u => u.Id == id)
                .ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<IEnumerable<ProjectsModel>> Put(ProjectsModel newClient)
        {
            DbSet.Update(newClient);
            return await DbSet.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ProjectsViewModel>> Add(RequestProjectViewModel model)
        {
            var projectModel = new ProjectsModel { ClientId = model.ClientId, Custom = model.Custom, Description = model.Description, Goal = model.Goal };
            DbSet.Add(projectModel);
            await Db.SaveChangesAsync();
            return Ok(projectModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IEnumerable<ProjectsModel>> Delete(Guid id)
        {
            DbSet.Remove(new ProjectsModel { Id = id });
            await Db.SaveChangesAsync();
            return await DbSet.ToListAsync();
        }
    }
}
