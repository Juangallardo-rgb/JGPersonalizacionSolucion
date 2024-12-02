using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JGwebTienda.Models;

namespace JGwebTienda.Controllers
{
    public class JGadornosController : Controller
    {
        private readonly JGwebTiendaContext _context;

        public JGadornosController(JGwebTiendaContext context)
        {
            _context = context;
        }

        // GET: JGadornos
        public async Task<IActionResult> Index()
        {
            return View(await _context.JGadornos.ToListAsync());
        }

        // GET: JGadornos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jGadornos = await _context.JGadornos
                .FirstOrDefaultAsync(m => m.JGadornosId == id);
            if (jGadornos == null)
            {
                return NotFound();
            }

            return View(jGadornos);
        }

        // GET: JGadornos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JGadornos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JGadornosId,JGName,JGnavideno,JGprice")] JGadornos jGadornos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jGadornos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jGadornos);
        }

        // GET: JGadornos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jGadornos = await _context.JGadornos.FindAsync(id);
            if (jGadornos == null)
            {
                return NotFound();
            }
            return View(jGadornos);
        }

        // POST: JGadornos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JGadornosId,JGName,JGnavideno,JGprice")] JGadornos jGadornos)
        {
            if (id != jGadornos.JGadornosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jGadornos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JGadornosExists(jGadornos.JGadornosId))
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
            return View(jGadornos);
        }

        // GET: JGadornos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jGadornos = await _context.JGadornos
                .FirstOrDefaultAsync(m => m.JGadornosId == id);
            if (jGadornos == null)
            {
                return NotFound();
            }

            return View(jGadornos);
        }

        // POST: JGadornos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jGadornos = await _context.JGadornos.FindAsync(id);
            if (jGadornos != null)
            {
                _context.JGadornos.Remove(jGadornos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JGadornosExists(int id)
        {
            return _context.JGadornos.Any(e => e.JGadornosId == id);
        }
    }
}
