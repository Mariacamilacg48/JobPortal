using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Web.Data.Entities
{
    public class Enterprise
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string NIT { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        public string Remarks { get; set; }

        [Display(Name = "image")]
        public string Logo { get; set; }
        public string imageFullPath => string.IsNullOrEmpty(Logo) 
        ? null
            : $"http://TBD.azurewebsites.net{Logo.Substring(1)}";

        public ICollection<VancancyPostulations> VancancyPostulations { get; set; }

    }
}