using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Web.Data.Entities
{
    public class InterviewMeeting
    {
        public int Id { get; set; }

        [Display(Name = "InterviewDate")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "InterviewDate")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime DateLocal => Date.ToLocalTime();

        public string Remarks { get; set; }

        public VancancyPostulations VancancyPostulations { get; set; }

        public ICollection<MeetingState> MeetingStates { get; set; }

    }
}
