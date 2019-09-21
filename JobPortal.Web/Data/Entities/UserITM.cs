using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Web.Data.Entities
{
    public class UserITM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength (20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Document { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display (Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public int Semester { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(10, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Carnet { get; set; }
                
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Address { get; set; }

        [Display(Name = "UserITM")]
        public string FullName => $" {FirstName} {LastName}";

        [Display(Name = "UserITM")]
        public string FullNameWithDocument => $" {FirstName} {LastName} - {Document}";

        public Program Program{ get; set; }

        public UserType UserType { get; set; }

        public ICollection<VancancyPostulations> VancancyPostulations { get; set; }

    }
}
