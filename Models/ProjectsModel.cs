using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD_BACK.Models
{
    public class ProjectsModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Goal { get; set; }
        [Required]
        public bool Custom { get; set; }

        [Required]
        [ForeignKey("Clients")]
        public int Client_Id { get; set; }
        [Required]
        public ClientModel Client { get; set; }
    }
}
