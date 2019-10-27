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

        public User User { get; set; }
        public AcademicProgram AcademicProgram { get; set; }

        public UserType UserType { get; set; }

        public ICollection<VancancyPostulations> VancancyPostulations { get; set; }

    }
}
