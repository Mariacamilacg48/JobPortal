using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortal.Web.Data;
using JobPortal.Web.Data.Entities;

namespace JobPortal.Web.Controllers
{
    public class VacanciesController : Controller
    {
        private readonly DataContext _context;

        public VacanciesController(DataContext context)
        {
            _context = context;
        }

        // GET: Vacancies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vacancies.ToListAsync());
        }

        // GET: Vacancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancies = await _context.Vacancies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancies == null)
            {
                return NotFound();
            }

            return View(vacancies);
        }

        // GET: Vacancies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vacancies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Vacancies vacancies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacancies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacancies);
        }

        // GET: Vacancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancies = await _context.Vacancies.FindAsync(id);
            if (vacancies == null)
            {
                return NotFound();
            }
            return View(vacancies);
        }

        // POST: Vacancies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Vacancies vacancies)
        {
            if (id != vacancies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacanciesExists(vacancies.Id))
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
            return View(vacancies);
        }

        // GET: Vacancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancies = await _context.Vacancies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancies == null)
            {
                return NotFound();
            }

            return View(vacancies);
        }

        // POST: Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacancies = await _context.Vacancies.FindAsync(id);
            _context.Vacancies.Remove(vacancies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacanciesExists(int id)
        {
            return _context.Vacancies.Any(e => e.Id == id);
        }
    }
}
