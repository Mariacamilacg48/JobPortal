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
    public class VacancyTypesController : Controller
    {
        private readonly DataContext _context;

        public VacancyTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: VacancyTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VacancyTypes.ToListAsync());
        }

        // GET: VacancyTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancyTypes = await _context.VacancyTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyTypes == null)
            {
                return NotFound();
            }

            return View(vacancyTypes);
        }

        // GET: VacancyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VacancyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] VacancyTypes vacancyTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacancyTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacancyTypes);
        }

        // GET: VacancyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancyTypes = await _context.VacancyTypes.FindAsync(id);
            if (vacancyTypes == null)
            {
                return NotFound();
            }
            return View(vacancyTypes);
        }

        // POST: VacancyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] VacancyTypes vacancyTypes)
        {
            if (id != vacancyTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancyTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyTypesExists(vacancyTypes.Id))
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
            return View(vacancyTypes);
        }

        // GET: VacancyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancyTypes = await _context.VacancyTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyTypes == null)
            {
                return NotFound();
            }

            return View(vacancyTypes);
        }

        // POST: VacancyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacancyTypes = await _context.VacancyTypes.FindAsync(id);
            _context.VacancyTypes.Remove(vacancyTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacancyTypesExists(int id)
        {
            return _context.VacancyTypes.Any(e => e.Id == id);
        }
    }
}
