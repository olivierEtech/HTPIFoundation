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
    public class DonHtpisController : Controller
    {
        private readonly HTPIFoundationContext _context;

        public DonHtpisController(HTPIFoundationContext context)
        {
            _context = context;
        }

        // GET: DonHtpis
        public async Task<IActionResult> Index()
        {
            return View(await _context.DonHtpi.ToListAsync());
        }

        public IActionResult Recu()
        {
            return View();
        }

        // GET: DonHtpis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHtpi = await _context.DonHtpi
                .SingleOrDefaultAsync(m => m.ID == id);
            var membre = await _context.Membre.SingleOrDefaultAsync(m => m.ID == donHtpi.MembreID);
            ViewBag.membre = membre;
            if (donHtpi == null)
            {
                return NotFound();
            }

            return View(donHtpi);
        }

        // GET: DonHtpis/Create
        public IActionResult Create(int? id)
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
            ViewBag.nomPrenom = membre.Nom+" "+ membre.Prenom;
            return View();
        }

        // POST: DonHtpis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembreID,MontantTotal,Detail,MontantAvance,FraisTransfert,DatePayement,MoyenPayement,NumRecue,IDTransaction")] DonHtpi donHtpi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHtpi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donHtpi);
        }

        // GET: DonHtpis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHtpi = await _context.DonHtpi.SingleOrDefaultAsync(m => m.ID == id);
            if (donHtpi == null)
            {
                return NotFound();
            }
            return View(donHtpi);
        }

        // POST: DonHtpis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,membreID,Montant_total,Detail,Montant_avance,Frais_transfert,Date_payement,Moyen_payement,Num_Recue,ID_Transaction")] DonHtpi donHtpi)
        {
            if (id != donHtpi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHtpi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHtpiExists(donHtpi.ID))
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
            return View(donHtpi);
        }

        // GET: DonHtpis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHtpi = await _context.DonHtpi
                .SingleOrDefaultAsync(m => m.ID == id);
            if (donHtpi == null)
            {
                return NotFound();
            }

            return View(donHtpi);
        }

        // POST: DonHtpis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donHtpi = await _context.DonHtpi.SingleOrDefaultAsync(m => m.ID == id);
            _context.DonHtpi.Remove(donHtpi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHtpiExists(int id)
        {
            return _context.DonHtpi.Any(e => e.ID == id);
        }
    }
}
