using BD_BACK.Models;
using System.ComponentModel.DataAnnotations;

namespace BD_BACK.ViewModels
{
    public class RequestClientViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
