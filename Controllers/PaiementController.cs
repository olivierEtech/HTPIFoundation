using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HTPIFoundation.Models;

namespace HTPIFoundation.Controllers
{
    public class PaiementController : Controller
    {
        private readonly HTPIFoundationContext _context;

        public PaiementController(HTPIFoundationContext context)
        {
            _context = context;
        }

        // GET: Paiement
        public async Task<IActionResult> Index(int?id)
        {
            if (id == null) {
                return View(await _context.Paiement.ToListAsync());
            }
            return View(await _context.Paiement.Where(p => p.MembreID == id).ToListAsync());
        }

        // GET: Paiement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paiement = await _context.Paiement
                .SingleOrDefaultAsync(m => m.ID == id);
            var membre = await _context.Membre.SingleOrDefaultAsync(m => m.ID == paiement.MembreID);
            ViewBag.membre = membre;
            if (paiement == null)
            {
                return NotFound();
            }

            return View(paiement);
        }

        // GET: Paiement/Create
        public IActionResult Create(int?id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var membre = _context.Membre.SingleOrDefault(c => c.ID == id);
            if (membre == null)
            {
                return NotFound();
            }
            ViewBag.id = membre.ID;
            ViewBag.nomPrenom = membre.Nom + " " + membre.Prenom;
            return View();
        }

        public IActionResult Recu(int? id)
        {
            var paiement = _context.Paiement.Find(id);
            var membre = _context.Membre.Where(m => m.ID == paiement.MembreID);
            ViewBag.paiment = paiement;
            ViewBag.membre = membre;
            if (id == null)
            {
                return NotFound();
            }
            return  View();
        }

        // POST: Paiement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembreID,MontantPayer,DatePayement,MoyenPayement,IDTransaction,AvanceAccord,MontantAvance,MembreReference")] Paiement paiement)
        {
            //if (ModelState.IsValid)
            if (paiement!=null)
            {
                if (paiement.MembreReference != null)
                {
                    Membre membreReference = _context.Membre.FirstOrDefault(m => (m.Nom + " " + m.Prenom).ToLower().Contains(paiement.MembreReference.ToLower()));
                    if (membreReference != null)
                        paiement.MembreAvanceID = membreReference.ID;
                }
                _context.Add(paiement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paiement);
        }

        // GET: Paiement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paiement = await _context.Paiement.SingleOrDefaultAsync(m => m.ID == id);
            if (paiement == null)
            {
                return NotFound();
            }
            return View(paiement);
        }

        // POST: Paiement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MembreID,MontantPayer,DatePayement,MoyenPayement,IDTransaction,AvanceAccord,MontantAvance,MembreAvanceID")] Paiement paiement)
        {
            if (id != paiement.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paiement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaiementExists(paiement.ID))
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
            return View(paiement);
        }

        // GET: Paiement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paiement = await _context.Paiement
                .SingleOrDefaultAsync(m => m.ID == id);
            if (paiement == null)
            {
                return NotFound();
            }

            return View(paiement);
        }

        // POST: Paiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paiement = await _context.Paiement.SingleOrDefaultAsync(m => m.ID == id);
            _context.Paiement.Remove(paiement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaiementExists(int id)
        {
            return _context.Paiement.Any(e => e.ID == id);
        }
    }
}
