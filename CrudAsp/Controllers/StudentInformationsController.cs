using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudAsp.Models;

namespace CrudAsp.Controllers
{
    public class StudentInformationsController : Controller
    {
        private readonly mydbcontext _context;

        public StudentInformationsController(mydbcontext context)
        {
            _context = context;
        }

        // GET: StudentInformations
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentInformation.ToListAsync());
        }

        // GET: StudentInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInformation = await _context.StudentInformation
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentInformation == null)
            {
                return NotFound();
            }

            return View(studentInformation);
        }

        // GET: StudentInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentAge,StudentPhone")] StudentInformation studentInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentInformation);
        }

        // GET: StudentInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInformation = await _context.StudentInformation.FindAsync(id);
            if (studentInformation == null)
            {
                return NotFound();
            }
            return View(studentInformation);
        }

        // POST: StudentInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentAge,StudentPhone")] StudentInformation studentInformation)
        {
            if (id != studentInformation.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentInformationExists(studentInformation.StudentId))
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
            return View(studentInformation);
        }

        // GET: StudentInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInformation = await _context.StudentInformation
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentInformation == null)
            {
                return NotFound();
            }

            return View(studentInformation);
        }

        // POST: StudentInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentInformation = await _context.StudentInformation.FindAsync(id);
            if (studentInformation != null)
            {
                _context.StudentInformation.Remove(studentInformation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentInformationExists(int id)
        {
            return _context.StudentInformation.Any(e => e.StudentId == id);
        }
    }
}
