using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly ToDoListContext _context;

        public ProblemsController(ToDoListContext context)
        {
            _context = context;
        }

        // GET: Problems
        public async Task<IActionResult> Index()
        {
            var toDoListContext = _context.Problems.Include(p => p.Priority).Include(p => p.Status);
            return View(await toDoListContext.ToListAsync());
        }

        // GET: Problems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Problems == null)
            {
                return NotFound();
            }

            var problem = await _context.Problems
                .Include(p => p.Priority)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }

        // GET: Problems/Create
        public IActionResult Create()
        {
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name");
            return View();
        }

        // POST: Problems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,PriorityId,StatusId")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(problem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "Id", "Name", problem.PriorityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", problem.StatusId);
            return View(problem);
        }

        // GET: Problems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Problems == null)
            {
                return NotFound();
            }

            var problem = await _context.Problems.FindAsync(id);
            if (problem == null)
            {
                return NotFound();
            }
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "Id", "Name", problem.PriorityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", problem.StatusId);
            return View(problem);
        }

        // POST: Problems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,PriorityId,StatusId")] Problem problem)
        {
            if (id != problem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(problem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemExists(problem.Id))
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
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "Id", "Name", problem.PriorityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", problem.StatusId);
            return View(problem);
        }

        // GET: Problems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Problems == null)
            {
                return NotFound();
            }

            var problem = await _context.Problems
                .Include(p => p.Priority)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Problems == null)
            {
                return Problem("Entity set 'ToDoListContext.Problems'  is null.");
            }
            var problem = await _context.Problems.FindAsync(id);
            if (problem != null)
            {
                _context.Problems.Remove(problem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProblemExists(int id)
        {
          return (_context.Problems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
