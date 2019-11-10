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
    public class VancancyPostulationsController : Controller
    {
        private readonly DataContext _context;

        public VancancyPostulationsController(DataContext context)
        {
            _context = context;
        }

        // GET: VancancyPostulations
        public async Task<IActionResult> Index()
        {
            return View(await _context.VancancyPostulations.ToListAsync());
        }

        // GET: VancancyPostulations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vancancyPostulations = await _context.VancancyPostulations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vancancyPostulations == null)
            {
                return NotFound();
            }

            return View(vancancyPostulations);
        }

        // GET: VancancyPostulations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VancancyPostulations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date")] VancancyPostulations vancancyPostulations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vancancyPostulations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vancancyPostulations);
        }

        // GET: VancancyPostulations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vancancyPostulations = await _context.VancancyPostulations.FindAsync(id);
            if (vancancyPostulations == null)
            {
                return NotFound();
            }
            return View(vancancyPostulations);
        }

        // POST: VancancyPostulations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date")] VancancyPostulations vancancyPostulations)
        {
            if (id != vancancyPostulations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vancancyPostulations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VancancyPostulationsExists(vancancyPostulations.Id))
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
            return View(vancancyPostulations);
        }

        // GET: VancancyPostulations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vancancyPostulations = await _context.VancancyPostulations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vancancyPostulations == null)
            {
                return NotFound();
            }

            return View(vancancyPostulations);
        }

        // POST: VancancyPostulations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vancancyPostulations = await _context.VancancyPostulations.FindAsync(id);
            _context.VancancyPostulations.Remove(vancancyPostulations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VancancyPostulationsExists(int id)
        {
            return _context.VancancyPostulations.Any(e => e.Id == id);
        }
    }
}
