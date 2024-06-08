using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD_BACK.Models
{
    public class ProjectsModel
    {
        [Key]
        public string Id { get; set; }
        public string Description { get; set; }
        public string Goal { get; set; }
        public bool Custom { get; set; }

        [ForeignKey("Clients")]
        public int Client_Id { get; set; }
        public ClientModel Client { get; set; }
    }
}
