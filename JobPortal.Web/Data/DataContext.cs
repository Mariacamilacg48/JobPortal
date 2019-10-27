using JobPortal.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<InterviewMeeting> InterviewMeetings { get; set; }
        public DbSet<MeetingState> MeetingStates { get; set; }
        public DbSet<PostulationStates> PostulationStates { get; set; }
        public DbSet<AcademicProgram> AcademicPrograms { get; set; }
        public DbSet<UserITM> UserITMs { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Vacancies> Vacancies { get; set; }
        public DbSet<VacancyTypes> VacancyTypes { get; set; }
        public DbSet<VancancyPostulations> VancancyPostulations { get; set; }
    }
}
