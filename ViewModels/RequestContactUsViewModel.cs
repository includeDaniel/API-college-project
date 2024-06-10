using System.ComponentModel.DataAnnotations;

namespace BD_BACK.ViewModels
{
    public class RequestContactUsViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
