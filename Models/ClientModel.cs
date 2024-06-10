using System.ComponentModel.DataAnnotations;

namespace BD_BACK.Models
{
    public class ClientModel : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<ProjectsModel> Projects { get; } = new List<ProjectsModel>();
    }
}
