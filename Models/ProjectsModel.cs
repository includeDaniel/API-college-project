﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BD_BACK.Models
{
    public class ProjectsModel : Entity
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Goal { get; set; }
        [Required]
        public bool Custom { get; set; }
        [Required]
        public Guid ClientId { get; set; }
        [JsonIgnore]
        public ClientModel Client { get; set; } = null!;
    }
}
