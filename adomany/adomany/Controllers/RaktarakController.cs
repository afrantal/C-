using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using adomany.Data;
using adomany.Models;
using Microsoft.AspNetCore.Authorization;

namespace adomany.Controllers
{
    public class RaktarakController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaktarakController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Raktarak
        public async Task<IActionResult> Index(string NevKereso, string KategoriaKereso)
        {
            Kereso keresoNev = new Kereso();
            var aruk = _context.Raktar.Select(x => x);
            if (!string.IsNullOrEmpty(NevKereso))
            {
                keresoNev.NevKereso = NevKereso;
                aruk = aruk.Where(x => x.Elnevezes.Contains(NevKereso));
            }

            if (!string.IsNullOrEmpty(KategoriaKereso))
            {
                keresoNev.KategoriaKereso = KategoriaKereso;
                aruk = aruk.Where(x => x.Kategoria.Equals(KategoriaKereso));
            }

            keresoNev.KategoriaLista = new SelectList(await _context.Raktar.Select(x => x.Kategoria).Distinct().ToListAsync());
            keresoNev.Aruk = await aruk.ToListAsync();

            return View(keresoNev);
        }

        // GET: Raktarak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raktar = await _context.Raktar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raktar == null)
            {
                return NotFound();
            }

            return View(raktar);
        }

        [Authorize]
        // GET: Raktarak/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Raktarak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Elnevezes,Kategoria,Csomagolas,Darab")] Raktar raktar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raktar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raktar);
        }

        [Authorize]
        // GET: Raktarak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raktar = await _context.Raktar.FindAsync(id);
            if (raktar == null)
            {
                return NotFound();
            }
            return View(raktar);
        }

        // POST: Raktarak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Elnevezes,Kategoria,Csomagolas,Darab")] Raktar raktar)
        {
            if (id != raktar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raktar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaktarExists(raktar.Id))
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
            return View(raktar);
        }

        [Authorize]
        // GET: Raktarak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raktar = await _context.Raktar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raktar == null)
            {
                return NotFound();
            }

            return View(raktar);
        }

        // POST: Raktarak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raktar = await _context.Raktar.FindAsync(id);
            _context.Raktar.Remove(raktar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaktarExists(int id)
        {
            return _context.Raktar.Any(e => e.Id == id);
        }
    }
}
