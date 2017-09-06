using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvctest.Models;

namespace mvctest.Controllers
{
    public class DestytojasController : Controller
    {
        private readonly TestStudContext _context;

        public DestytojasController(TestStudContext context)
        {
            _context = context;
        }

        // GET: Destytojas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Destytojas.ToListAsync());
        }

        // GET: Destytojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destytojas = await _context.Destytojas
                .SingleOrDefaultAsync(m => m.IdDestytojas == id);
            if (destytojas == null)
            {
                return NotFound();
            }

            return View(destytojas);
        }

        // GET: Destytojas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Destytojas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Vardas,Pavarde,Metai,IdDestytojas")] Destytojas destytojas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destytojas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destytojas);
        }

        // GET: Destytojas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destytojas = await _context.Destytojas.SingleOrDefaultAsync(m => m.IdDestytojas == id);
            if (destytojas == null)
            {
                return NotFound();
            }
            return View(destytojas);
        }

        // POST: Destytojas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Vardas,Pavarde,Metai,IdDestytojas")] Destytojas destytojas)
        {
            if (id != destytojas.IdDestytojas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destytojas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestytojasExists(destytojas.IdDestytojas))
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
            return View(destytojas);
        }

        // GET: Destytojas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destytojas = await _context.Destytojas
                .SingleOrDefaultAsync(m => m.IdDestytojas == id);
            if (destytojas == null)
            {
                return NotFound();
            }

            return View(destytojas);
        }

        // POST: Destytojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destytojas = await _context.Destytojas.SingleOrDefaultAsync(m => m.IdDestytojas == id);
            _context.Destytojas.Remove(destytojas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestytojasExists(int id)
        {
            return _context.Destytojas.Any(e => e.IdDestytojas == id);
        }
    }
}
