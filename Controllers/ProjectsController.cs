using BD_BACK.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BD_BACK.Controllers
{
    [Route("api/Bd-Back/Projects")]
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
        public async Task<IEnumerable<ProjectsModel>> Get(int id)
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
        public async Task<IEnumerable<ProjectsModel>> Add(ProjectsModel newClient)
        {
            DbSet.Add(newClient);
            await Db.SaveChangesAsync();
            return await DbSet.ToListAsync();
        }

        [HttpDelete("{id:int}")]
        public async Task<IEnumerable<ProjectsModel>> Delete(int id)
        {
            DbSet.Remove(new ProjectsModel { Id = id });
            await Db.SaveChangesAsync();
            return await DbSet.ToListAsync();
        }
    }
}
