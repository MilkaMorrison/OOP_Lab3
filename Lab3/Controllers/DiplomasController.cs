using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab3;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class DiplomasController : Controller
    {
        private readonly ApplicationContext _context;

        public DiplomasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Diplomas
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Diplomas.Include(d => d.Student);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Diplomas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diploma = await _context.Diplomas
                .Include(d => d.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diploma == null)
            {
                return NotFound();
            }

            return View(diploma);
        }

        // GET: Diplomas/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Diplomas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StudentId")] Diploma diploma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diploma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", diploma.StudentId);
            return View(diploma);
        }

        // GET: Diplomas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diploma = await _context.Diplomas.FindAsync(id);
            if (diploma == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", diploma.StudentId);
            return View(diploma);
        }

        // POST: Diplomas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StudentId")] Diploma diploma)
        {
            if (id != diploma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diploma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiplomaExists(diploma.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", diploma.StudentId);
            return View(diploma);
        }

        // GET: Diplomas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diploma = await _context.Diplomas
                .Include(d => d.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diploma == null)
            {
                return NotFound();
            }

            return View(diploma);
        }

        // POST: Diplomas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diploma = await _context.Diplomas.FindAsync(id);
            if (diploma != null)
            {
                _context.Diplomas.Remove(diploma);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiplomaExists(int id)
        {
            return _context.Diplomas.Any(e => e.Id == id);
        }
    }
}
