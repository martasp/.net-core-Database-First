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
    public class StudentasController : Controller
    {
        private readonly TestStudContext _context;

        public StudentasController(TestStudContext context)
        {
            _context = context;
        }

        // GET: Studentas
        public async Task<IActionResult> Index()
        {
            //_con
            var testStudContext = _context.Studentas.Include(s => s.FkDestytojasidDestytojasNavigation);
            return View(await testStudContext.ToListAsync());
        }

        // GET: Studentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentas = await _context.Studentas
                .Include(s => s.FkDestytojasidDestytojasNavigation)
                .SingleOrDefaultAsync(m => m.IdStudentas == id);
            if (studentas == null)
            {
                return NotFound();
            }

            return View(studentas);
        }

        // GET: Studentas/Create
        public IActionResult Create()
        {
            ViewData["FkDestytojasidDestytojas"] = new SelectList(_context.Destytojas, "IdDestytojas", "IdDestytojas");
            return View();
        }

        // POST: Studentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Vardas,Pavarde,Metai,Universitetas,IdStudentas,FkDestytojasidDestytojas")] Studentas studentas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkDestytojasidDestytojas"] = new SelectList(_context.Destytojas, "IdDestytojas", "IdDestytojas", studentas.FkDestytojasidDestytojas);
            return View(studentas);
        }

        // GET: Studentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentas = await _context.Studentas.SingleOrDefaultAsync(m => m.IdStudentas == id);
            if (studentas == null)
            {
                return NotFound();
            }
            ViewData["FkDestytojasidDestytojas"] = new SelectList(_context.Destytojas, "IdDestytojas", "IdDestytojas", studentas.FkDestytojasidDestytojas);
            return View(studentas);
        }

        // POST: Studentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Vardas,Pavarde,Metai,Universitetas,IdStudentas,FkDestytojasidDestytojas")] Studentas studentas)
        {
            if (id != studentas.IdStudentas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentasExists(studentas.IdStudentas))
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
            ViewData["FkDestytojasidDestytojas"] = new SelectList(_context.Destytojas, "IdDestytojas", "IdDestytojas", studentas.FkDestytojasidDestytojas);
            return View(studentas);
        }

        // GET: Studentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentas = await _context.Studentas
                .Include(s => s.FkDestytojasidDestytojasNavigation)
                .SingleOrDefaultAsync(m => m.IdStudentas == id);
            if (studentas == null)
            {
                return NotFound();
            }

            return View(studentas);
        }

        // POST: Studentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentas = await _context.Studentas.SingleOrDefaultAsync(m => m.IdStudentas == id);
            _context.Studentas.Remove(studentas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentasExists(int id)
        {
            return _context.Studentas.Any(e => e.IdStudentas == id);
        }
    }
}
