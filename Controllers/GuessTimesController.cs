using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MMLinkedInAttempt57.Data;
using MMLinkedInAttempt57.Models;

namespace MMLinkedInAttempt57.Controllers
{
    public class GuessTimesController : Controller
    {
        private readonly MMLinkedInAttempt57Context _context;

        public GuessTimesController(MMLinkedInAttempt57Context context)
        {
            _context = context;
        }

        // GET: GuessTimes
        public async Task<IActionResult> Index()
        {
            var mMLinkedInAttempt57Context = _context.GuessTimes.Include(g => g.Guess);
            return View(await mMLinkedInAttempt57Context.ToListAsync());
        }

        // GET: GuessTimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guessTime = await _context.GuessTimes
                .Include(g => g.Guess)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guessTime == null)
            {
                return NotFound();
            }

            return View(guessTime);
        }

        // GET: GuessTimes/Create
        public IActionResult Create()
        {
            ViewData["FKGuessId"] = new SelectList(_context.Set<Guess>(), "Id", "Id");
            return View();
        }

        // POST: GuessTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FKGuessId,TimeOfGuess")] GuessTime guessTime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guessTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FKGuessId"] = new SelectList(_context.Set<Guess>(), "Id", "Id", guessTime.FKGuessId);
            return View(guessTime);
        }

        // GET: GuessTimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guessTime = await _context.GuessTimes.FindAsync(id);
            if (guessTime == null)
            {
                return NotFound();
            }
            ViewData["FKGuessId"] = new SelectList(_context.Set<Guess>(), "Id", "Id", guessTime.FKGuessId);
            return View(guessTime);
        }

        // POST: GuessTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FKGuessId,TimeOfGuess")] GuessTime guessTime)
        {
            if (id != guessTime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guessTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuessTimeExists(guessTime.Id))
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
            ViewData["FKGuessId"] = new SelectList(_context.Set<Guess>(), "Id", "Id", guessTime.FKGuessId);
            return View(guessTime);
        }

        // GET: GuessTimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guessTime = await _context.GuessTimes
                .Include(g => g.Guess)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guessTime == null)
            {
                return NotFound();
            }

            return View(guessTime);
        }

        // POST: GuessTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guessTime = await _context.GuessTimes.FindAsync(id);
            _context.GuessTimes.Remove(guessTime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuessTimeExists(int id)
        {
            return _context.GuessTimes.Any(e => e.Id == id);
        }
    }
}
