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
    public class MeetingStatesController : Controller
    {
        private readonly DataContext _context;

        public MeetingStatesController(DataContext context)
        {
            _context = context;
        }

        // GET: MeetingStates
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeetingStates.ToListAsync());
        }

        // GET: MeetingStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingState = await _context.MeetingStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meetingState == null)
            {
                return NotFound();
            }

            return View(meetingState);
        }

        // GET: MeetingStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeetingStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] MeetingState meetingState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetingState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meetingState);
        }

        // GET: MeetingStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingState = await _context.MeetingStates.FindAsync(id);
            if (meetingState == null)
            {
                return NotFound();
            }
            return View(meetingState);
        }

        // POST: MeetingStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] MeetingState meetingState)
        {
            if (id != meetingState.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetingState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingStateExists(meetingState.Id))
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
            return View(meetingState);
        }

        // GET: MeetingStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingState = await _context.MeetingStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meetingState == null)
            {
                return NotFound();
            }

            return View(meetingState);
        }

        // POST: MeetingStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetingState = await _context.MeetingStates.FindAsync(id);
            _context.MeetingStates.Remove(meetingState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingStateExists(int id)
        {
            return _context.MeetingStates.Any(e => e.Id == id);
        }
    }
}
