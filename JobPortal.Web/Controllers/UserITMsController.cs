using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortal.Web.Data;
using JobPortal.Web.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace JobPortal.Web.Controllers
{   
    [Authorize(Roles = "Admin")]
    public class UserITMsController : Controller
    {
        private readonly DataContext _context;

        public UserITMsController(DataContext context)
        {
            _context = context;
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
        public async Task<IActionResult> Create([Bind("Id")] UserITM userITM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userITM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userITM);
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
