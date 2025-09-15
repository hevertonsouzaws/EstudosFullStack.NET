﻿using System.ComponentModel.DataAnnotations;

namespace StatusWS.Dtos
{
    public class StatusTypeCreateDto
    {
        [Required]
        public string Description { get; set; }
        public string IconUrl { get; set; } = "https://cdn-icons-png.flaticon.com/512/4785/4785876.png";
    }
}
