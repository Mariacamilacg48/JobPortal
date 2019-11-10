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
    public class InterviewMeetingsController : Controller
    {
        private readonly DataContext _context;

        public InterviewMeetingsController(DataContext context)
        {
            _context = context;
        }

        // GET: InterviewMeetings
        public async Task<IActionResult> Index()
        {
            return View(await _context.InterviewMeetings.ToListAsync());
        }

        // GET: InterviewMeetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interviewMeeting = await _context.InterviewMeetings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interviewMeeting == null)
            {
                return NotFound();
            }

            return View(interviewMeeting);
        }

        // GET: InterviewMeetings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InterviewMeetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Remarks")] InterviewMeeting interviewMeeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interviewMeeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interviewMeeting);
        }

        // GET: InterviewMeetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interviewMeeting = await _context.InterviewMeetings.FindAsync(id);
            if (interviewMeeting == null)
            {
                return NotFound();
            }
            return View(interviewMeeting);
        }

        // POST: InterviewMeetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Remarks")] InterviewMeeting interviewMeeting)
        {
            if (id != interviewMeeting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interviewMeeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterviewMeetingExists(interviewMeeting.Id))
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
            return View(interviewMeeting);
        }

        // GET: InterviewMeetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interviewMeeting = await _context.InterviewMeetings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interviewMeeting == null)
            {
                return NotFound();
            }

            return View(interviewMeeting);
        }

        // POST: InterviewMeetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interviewMeeting = await _context.InterviewMeetings.FindAsync(id);
            _context.InterviewMeetings.Remove(interviewMeeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterviewMeetingExists(int id)
        {
            return _context.InterviewMeetings.Any(e => e.Id == id);
        }
    }
}
