
﻿using System.ComponentModel.DataAnnotations;

namespace Flash_Card.Dtos
{
    public class CreateTestDto
    {
        [Required(ErrorMessage = "required")]
        public string Name { get; set; }
    }
}