using System.ComponentModel.DataAnnotations;

namespace BD_BACK.Models
{
    public class ClientModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
