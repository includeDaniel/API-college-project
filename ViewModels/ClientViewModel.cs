using BD_BACK.Models;
using System.ComponentModel.DataAnnotations;

namespace BD_BACK.ViewModels
{
    public class ClientViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<ProjectsModel> Projects { get; } = new List<ProjectsModel>();
    }
}
