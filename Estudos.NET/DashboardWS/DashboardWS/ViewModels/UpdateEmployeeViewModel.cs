﻿using System.ComponentModel.DataAnnotations;

namespace DashboardWS.ViewModels
{
    public class UpdateEmployeeViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }

    }
}
