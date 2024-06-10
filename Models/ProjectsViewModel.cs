using System.ComponentModel.DataAnnotations;

namespace BD_BACK.Models
{
    public class ProjectsViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Goal { get; set; }
        [Required]
        public bool Custom { get; set; }
        [Required]
        public Guid ClientId { get; set; }
    }
}
