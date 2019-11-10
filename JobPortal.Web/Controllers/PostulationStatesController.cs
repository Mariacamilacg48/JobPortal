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
    public class PostulationStatesController : Controller
    {
        private readonly DataContext _context;

        public PostulationStatesController(DataContext context)
        {
            _context = context;
        }

        // GET: PostulationStates
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostulationStates.ToListAsync());
        }

        // GET: PostulationStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postulationStates = await _context.PostulationStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postulationStates == null)
            {
                return NotFound();
            }

            return View(postulationStates);
        }

        // GET: PostulationStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostulationStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PostulationStates postulationStates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postulationStates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postulationStates);
        }

        // GET: PostulationStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postulationStates = await _context.PostulationStates.FindAsync(id);
            if (postulationStates == null)
            {
                return NotFound();
            }
            return View(postulationStates);
        }

        // POST: PostulationStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PostulationStates postulationStates)
        {
            if (id != postulationStates.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postulationStates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostulationStatesExists(postulationStates.Id))
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
            return View(postulationStates);
        }

        // GET: PostulationStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postulationStates = await _context.PostulationStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postulationStates == null)
            {
                return NotFound();
            }

            return View(postulationStates);
        }

        // POST: PostulationStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postulationStates = await _context.PostulationStates.FindAsync(id);
            _context.PostulationStates.Remove(postulationStates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostulationStatesExists(int id)
        {
            return _context.PostulationStates.Any(e => e.Id == id);
        }
    }
}
