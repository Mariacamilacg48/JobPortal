﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Web.Data.Entities
{
    public class Vacancies
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Vacancies Name")]
        public string Name { get; set; }

        public ICollection<Enterprise> Enterprises { get; set; }

        public ICollection<VacancyTypes> VacancyTypes { get; set; }

    }
}
