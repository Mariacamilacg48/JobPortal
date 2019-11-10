using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortal.Web.Data;
using JobPortal.Web.Data.Entities;
using JobPortal.Web.Models;
using JobPortal.Web.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace JobPortal.Web.Controllers
{   
    [Authorize(Roles = "Admin")]
    public class UserITMsController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public UserITMsController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        // GET: UserITMs
        public IActionResult Index()
        {
            return View( _context.UserITMs
                .Include(o => o.User)
                .Include(o => o.UserType)
                .Include(o => o.AcademicProgram));
        }

        // GET: UserITMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userITM = await _context.UserITMs
                .Include(o => o.User)
                .Include(o => o.UserType)
                .Include(o => o.AcademicProgram)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userITM == null)
            {
                return NotFound();
            }

            return View(userITM);
        }

        // GET: UserITMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserITMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Document = model.Document,
                    Address = model.Address,
                    Email = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CellPhone = model.CellPhone,
                    UserName = model.Username,
                    Semester = model.Semester,
                    Carnet = model.Carnet,
                    
                };

                var response = await _userHelper.AddUserAsync(user, model.Password);
                if (response.Succeeded)
                {
                    var userInDB = await _userHelper.GetUserByEmailAsync(model.Username);
                    await _userHelper.AddUserToRoleAsync(userInDB, "Customer");

                    var userITM = new UserITM
                    {
                        AcademicProgram = new AcademicProgram(),
                        UserType = new UserType(),
                        VancancyPostulations = new List<VancancyPostulations>(),  
                        User = userInDB
                    };

                    _context.UserITMs.Add(userITM);
                    try
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {

                        ModelState.AddModelError(string.Empty, ex.ToString());
                        return View(model);
                    }
                    
                    
                }
                ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
            }
            return View(model);
        }

        // GET: UserITMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userITM = await _context.UserITMs.FindAsync(id);
            if (userITM == null)
            {
                return NotFound();
            }
            return View(userITM);
        }

        // POST: UserITMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] UserITM userITM)
        {
            if (id != userITM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userITM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserITMExists(userITM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userITM);
        }

        // GET: UserITMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userITM = await _context.UserITMs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userITM == null)
            {
                return NotFound();
            }

            return View(userITM);
        }

        // POST: UserITMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userITM = await _context.UserITMs.FindAsync(id);
            _context.UserITMs.Remove(userITM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserITMExists(int id)
        {
            return _context.UserITMs.Any(e => e.Id == id);
        }
    }
}
