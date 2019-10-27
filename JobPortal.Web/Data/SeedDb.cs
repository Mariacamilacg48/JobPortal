using JobPortal.Web.Data;
using JobPortal.Web.Data.Entities;
using JobPortal.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Summary description for Class1
/// </summary>
    public class SeedDb
{
    private readonly DataContext _context;
    private readonly IUserHelper _userHelper;

    public SeedDb(DataContext context, IUserHelper userHelper)
    {
        _context = context;
        _userHelper = userHelper;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckRoles();
        var manager = await CheckUserAsync("1040739413", "Daniela", "Sanchez", "dsanchep7@gmail.com", "3206416083", "Calle Luna Calle Sol", "Admin");
        var customer = await CheckUserAsync("1017241448", "Camila", "Chica", "mariacamilacg48@hotmail.com", "3317901412", "Calle Luna Calle Sol", "Customer");
        await CheckAcademicProgramAsync();
        await CheckAgendasAsync();
        await CheckEnterpriseAsync();
        await CheckInterviewMeetingAsync();
        await CheckManagerAsync(manager);
        await CheckMeetingStateAsync();
        await CheckUserITMAsync(customer);
        await CheckPostulationStatesAsync();       
        await CheckUsertypeAsync();
        await CheckVacanciesAsync();
        await CheckVacanciesTypesAsync();
       

    }

    
    private async Task CheckVacanciesTypesAsync()
    {
        if (!_context.VacancyTypes.Any())
        {
            _context.VacancyTypes.Add(new VacancyTypes { Name = "Social Internships" });
            _context.VacancyTypes.Add(new VacancyTypes { Name = "Professional Internships"});
            _context.VacancyTypes.Add(new VacancyTypes { Name = "Professional" });
        }
    }

    private async Task CheckVacanciesAsync()
    {
        if(!_context.Vacancies.Any())
        {
            _context.Vacancies.Add(new Vacancies { Name = "Ingreniero desarrollo" });
            _context.Vacancies.Add(new Vacancies { Name = "Administrador" });
            _context.Vacancies.Add(new Vacancies { Name = "Productor Musical" });
            _context.Vacancies.Add(new Vacancies { Name = "Ingreniero Biomedico" });
        }
    }

    private async Task CheckUsertypeAsync()
    {
        if(!_context.UserType.Any())
        {
            _context.UserType.Add(new UserType { Name = "Student" });
            _context.UserType.Add(new UserType { Name = "Graduated" });
            _context.UserType.Add(new UserType { Name = "Administrator" });
        }
    }

    private async Task CheckPostulationStatesAsync()
    {
        if(!_context.PostulationStates.Any())
        {
            _context.PostulationStates.Add(new PostulationStates { Name = "Active" });
            _context.PostulationStates.Add(new PostulationStates { Name = "In progress" });
            _context.PostulationStates.Add(new PostulationStates { Name = "Finished" });
        }
    }

    private async Task<User> CheckUserAsync(
        string document,
        string firstName,
        string lastName,
        string email,
        string phone,
        string address,
        string role)
       
    {
        var user = await _userHelper.GetUserByEmailAsync(email);
        if (user == null)
        {
            user = new User
            {
                Document = document,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                PhoneNumber = phone,
                Address = address
            
            };

            await _userHelper.AddUserAsync(user, "123456");
            await _userHelper.AddUserToRoleAsync(user, role);
        }

        return user;
    }

    private async Task CheckMeetingStateAsync()
    {
        if (!_context.MeetingStates.Any())
        {
            _context.MeetingStates.Add(new MeetingState { });
        }

    }

    private async Task CheckManagerAsync(User user)
    {
        if (!_context.Managers.Any())
        {
            _context.Managers.Add(new Manager { User = user });
            await _context.SaveChangesAsync();
        }
    }


    private async Task CheckInterviewMeetingAsync()
    {
        if (!_context.InterviewMeetings.Any())

            _context.InterviewMeetings.Add(new InterviewMeeting {Remarks = "First Interview"  });
        await _context.SaveChangesAsync();
    }



    private async Task CheckRoles()
    {
        await _userHelper.CheckRoleAsync("Admin");
        await _userHelper.CheckRoleAsync("Customer");
    }
          
    private async Task CheckAcademicProgramAsync()
    {
        if (!_context.AcademicPrograms.Any())
        {
            AddAcademicProgram("Ingenieria de Sistemas", "Ingenierias");
            AddAcademicProgram("Costo y Presupuesto", "Ciencias Economicas");
            AddAcademicProgram("Informatica Musical", "Artes");
            AddAcademicProgram("Ingenieria Biomedica", "Ciencas Exactas y Aplicadas");
            await _context.SaveChangesAsync();
        }
    }

    private void AddAcademicProgram(string name, string facultyName)
    {
        _context.AcademicPrograms.Add(new AcademicProgram
        {
            Name = name,
            FacultyName = facultyName,

        });
    }
    private async Task CheckEnterpriseAsync()
    {
        if (!_context.Enterprises.Any())
        {
            _context.Enterprises.Add(new Enterprise { Name = "Snacks Food", NIT = "1017152736", Phone = "3876543", Remarks = "Comidas" });
            await _context.SaveChangesAsync();
        }
    }


    private async Task CheckUserITMAsync(User user)
    {
        if (!_context.UserITMs.Any())
        {
            _context.UserITMs.Add(new UserITM { User = user });
            await _context.SaveChangesAsync();
        }
    }

      private async Task CheckAgendasAsync()
    {
        if (!_context.Agendas.Any())
        {
            var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            var finalDate = initialDate.AddYears(1);
            while (initialDate < finalDate)
            {
                if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var finalDate2 = initialDate.AddHours(10);
                    while (initialDate < finalDate2)
                    {
                        _context.Agendas.Add(new Agenda
                        {
                            Date = initialDate,
                            IsAvailable = true
                        });

                        initialDate = initialDate.AddMinutes(30);
                    }

                    initialDate = initialDate.AddHours(14);
                }
                else
                {
                    initialDate = initialDate.AddDays(1);
                }
            }
        }

        await _context.SaveChangesAsync();
    }

}