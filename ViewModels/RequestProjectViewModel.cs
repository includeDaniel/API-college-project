﻿using System.ComponentModel.DataAnnotations;

namespace BD_BACK.ViewModels
{
    public class RequestProjectViewModel
    {
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
