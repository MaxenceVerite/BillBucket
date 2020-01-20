using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BillBucket.Models;

namespace BillBucket.Controllers
{
    public class FacturesController : Controller
    {
        private readonly BillBucketContext _context;

        public FacturesController(BillBucketContext context)
        {
            _context = context;
        }

        // GET: Factures
        public async Task<IActionResult> Index()
        {
            var billBucketContext = _context.Factures.Include(f => f.Client);
            return View(await billBucketContext.ToListAsync());
        }

        // GET: Factures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facture = await _context.Factures
                .Include(f => f.Client)
                .Include(f=> f.Prestations)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facture == null)
            {
                return NotFound();
            }

            ViewBag.IsPaid = facture.DateReglement == null ? false : true;

            return View(facture);
        }

        // GET: Factures/Create
        public IActionResult Create()
        {
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Nom");
            return View();
        }

        // POST: Factures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdClient,NoFacture,DateEmission,DateReglement,Description")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                facture.Id = Guid.NewGuid();
                _context.Add(facture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Nom", facture.IdClient);
            return View(facture);
        }

        // GET: Factures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facture = await _context.Factures
                .Include(f => f.Prestations)
                .FirstOrDefaultAsync(m => m.Id == id);


            if (facture == null)
            {
                return NotFound();
            }
            double montantTotal = 0;

            foreach(var pre in facture.Prestations.ToList())
            {
                montantTotal += pre.Montant;
            }

            ViewBag.MontantTotal = montantTotal * 1.20 ;
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Nom", facture.IdClient);
            return View(facture);
        }

        // POST: Factures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,IdClient,NoFacture,DateEmission,DateReglement,Description")] Facture facture)
        {
            if (id != facture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactureExists(facture.Id))
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
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Nom", facture.IdClient);
            return View(facture);
        }

        // GET: Factures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facture = await _context.Factures
                .Include(f => f.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facture == null)
            {
                return NotFound();
            }

            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var facture = await _context.Factures.FindAsync(id);
            _context.Factures.Remove(facture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactureExists(Guid id)
        {
            return _context.Factures.Any(e => e.Id == id);
        }


        public async Task<IActionResult> AddPrestation(Guid id, [Bind("Id, IdFacture, Nom, Montant,Description")] Prestation pres)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Prestations.Add(pres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            
            return View();
        }
    }


}
