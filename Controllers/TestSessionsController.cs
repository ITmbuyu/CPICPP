using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPICPP.Data;
using CPICPP.Models;

namespace CPICPP.Controllers
{
    public class TestSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestSessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TestSessions
        public async Task<IActionResult> Index()
        {
              return _context.TestSessions != null ? 
                          View(await _context.TestSessions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TestSessions'  is null.");
        }

        // GET: TestSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TestSessions == null)
            {
                return NotFound();
            }

            var testSession = await _context.TestSessions
                .FirstOrDefaultAsync(m => m.TestSessionId == id);
            if (testSession == null)
            {
                return NotFound();
            }

            return View(testSession);
        }

        // GET: TestSessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestSessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestSessionId,UserId,UserResponsesJson,QuestionsAskedJson,GeneratedMBTIType,Score,TestName")] TestSession testSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testSession);
        }

        // GET: TestSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TestSessions == null)
            {
                return NotFound();
            }

            var testSession = await _context.TestSessions.FindAsync(id);
            if (testSession == null)
            {
                return NotFound();
            }
            return View(testSession);
        }

        // POST: TestSessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestSessionId,UserId,UserResponsesJson,QuestionsAskedJson,GeneratedMBTIType,Score,TestName")] TestSession testSession)
        {
            if (id != testSession.TestSessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestSessionExists(testSession.TestSessionId))
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
            return View(testSession);
        }

        // GET: TestSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TestSessions == null)
            {
                return NotFound();
            }

            var testSession = await _context.TestSessions
                .FirstOrDefaultAsync(m => m.TestSessionId == id);
            if (testSession == null)
            {
                return NotFound();
            }

            return View(testSession);
        }

        // POST: TestSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TestSessions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TestSessions'  is null.");
            }
            var testSession = await _context.TestSessions.FindAsync(id);
            if (testSession != null)
            {
                _context.TestSessions.Remove(testSession);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestSessionExists(int id)
        {
          return (_context.TestSessions?.Any(e => e.TestSessionId == id)).GetValueOrDefault();
        }
    }
}
