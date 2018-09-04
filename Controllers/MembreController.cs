using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HTPIFoundation.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace HTPIFoundation.Controllers
{
    public class MembreController : Controller
    {
        private readonly HTPIFoundationContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public MembreController(HTPIFoundationContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this._hostingEnvironment = hostingEnvironment;
        }

        // GET: Membre
        public async Task<IActionResult> Index()
        {
            return View(await _context.Membre.Include("Pays").ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] Admin admin)
        {
            Utilisateur user = await _context.Utilisateur.Where(u => u.Email == admin.email && u.Password == admin.password).FirstOrDefaultAsync();
            if(user != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Index", "Administrateur");
            }
        }

        // GET: Membre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membre = await _context.Membre.Include("PieceIdentite").Include("PieceIdentite.TypePieceIdentite").Include("PieceIdentite.PaysDelivrance")
                .Include("PieceIdentite.TypeJustDomicile").Include("Operateur").Include("PersonneReference")
                .SingleOrDefaultAsync(m => m.ID == id);
            if (membre == null)
            {
                return NotFound();
            }

            ViewBag.UploadPieceIdentiteID = membre.PieceIdentite.UploadPieceIdentiteID;
            ViewBag.UploadJustificatifDomicileID = membre.PieceIdentite.UploadJustificatifDomicileID;
            ViewBag.UploadExtraitActeNaissanceID = membre.PieceIdentite.UploadActeDeNaissanceID;

            return View(membre);
        }

        // GET: Membre/Create
        public IActionResult Create()
        {
            ViewBag.Operateurs = _context.Operateur.ToList();
            ViewBag.TypePieceIdentites = _context.TypePieceIdentite.ToList();
            ViewBag.TypeJustDomiciles = _context.TypeJustificatifDomicile.ToList();
            ViewBag.Pays = _context.Pays.ToList();
            ViewBag.Saved = 0;
            return View();
        }

        [HttpPost]
        public JsonResult GetPays([FromBody] Term term){
            var res = _context.Pays.Where(p => p.nom_fr_fr.ToLower().Contains(term.term.ToLower())).Select(s => new {label = s.nom_fr_fr, value = s.nom_fr_fr});
            return new JsonResult(res);
        }

        public JsonResult GetHTPIMembre([FromBody] Term term){
            var res = _context.Membre.Where(p => p.Prenom.ToLower().Contains(term.term.ToLower()) || p.Nom.ToLower().Contains(term.term.ToLower())).ToList();
            var res1 = res.Select(s => new {label = s.Nom+" "+s.Prenom, value = s.ID_HTPI}).ToList();
            return new JsonResult(res1);
        }

        [HttpPost]
        public async Task<JsonResult> UploadFile(IList<IFormFile> files)
        {
            Upload upload = new Upload();
            foreach (IFormFile source in files)
            {
                string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');

                filename = this.EnsureCorrectFilename(filename);

                using (FileStream output = System.IO.File.Create(this.GetPathAndFilename(filename)))
                await source.CopyToAsync(output);

                string filePath = this.GetPathAndFilename(filename);
                upload.Date = DateTime.Now;
                upload.FileName = filename;
                upload.Uri = filePath;
                _context.Upload.Add(upload);
                _context.SaveChanges();
            }

            return new JsonResult(upload);
        }

        public async Task<IActionResult> Download(int? id)
        {
            Upload upload = _context.Upload.Find(id);
            if(upload != null){
                string filename = upload.FileName;
                if (filename == null)
                    return Content("filename not present");

                var path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/uploads/", filename);

                var memory = new MemoryStream();
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, GetContentType(path), Path.GetFileName(path));
            }else{
                return Content("filename not present"); 
            }
        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            return this._hostingEnvironment.WebRootPath + "\\uploads\\" + filename;
        }

        public IActionResult CarteMembre()
        {
            return View();
        }

        // POST: Membre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, Appellation, Nom, Prenom, DateNaissance, Nationnalite, Profession, Adresse, CodePostal, Ville, MembrePays, PieceIdentite, Email, TelephoneFixe, TelephoneMobile, NumCompatibleMobileMoney, OperateurID, MembreReference, AccepteCharteMembre, ID_HTPI")] Membre membre)
        {
            //if (ModelState.IsValid)
            //{
            Membre _membre = new Membre();
            _membre.Appellation = membre.Appellation;
            _membre.Nom = membre.Nom;
            _membre.Prenom = membre.Prenom;
            _membre.DateNaissance = membre.DateNaissance;
            _membre.Nationnalite = membre.Nationnalite;
            _membre.Profession = membre.Profession;
            _membre.Adresse = membre.Adresse;
            _membre.CodePostal = membre.CodePostal;
            _membre.Ville = membre.Ville;

            Pays pays = _context.Pays.FirstOrDefault(p => p.nom_fr_fr.ToLower().Contains(membre.MembrePays.ToLower()));
            if(pays != null){
                _membre.PaysID = pays.ID;
            }

            PieceIdentite pieceIdentite = membre.PieceIdentite;
            PieceIdentite _pieceIdentite = new PieceIdentite();

            _pieceIdentite.TypePieceIdentiteID = pieceIdentite.TypePieceIdentiteID;
            _pieceIdentite.AutreTypePieceIdentiteID = pieceIdentite.AutreTypePieceIdentiteID;
            _pieceIdentite.NumPieceIdentite = pieceIdentite.NumPieceIdentite;

            pays = _context.Pays.FirstOrDefault(p => p.nom_fr_fr.ToLower().Contains(pieceIdentite.DelivrancePays.ToLower()));
            if(pays != null){
                _pieceIdentite.PaysDelivranceID = pays.ID;
            }
            
            _pieceIdentite.DateDelivrance = pieceIdentite.DateDelivrance;
            _pieceIdentite.DateExpiration = pieceIdentite.DateExpiration;
            _pieceIdentite.UploadPieceIdentiteID = pieceIdentite.UploadPieceIdentiteID;
            _pieceIdentite.TypeJustDomicileID = pieceIdentite.TypeJustDomicileID == 0 ? null : pieceIdentite.TypeJustDomicileID;
            _pieceIdentite.AutreTypeJustDomicileID = pieceIdentite.AutreTypeJustDomicileID;
            _pieceIdentite.UploadJustificatifDomicileID = pieceIdentite.UploadJustificatifDomicileID;
            _pieceIdentite.UploadActeDeNaissanceID = pieceIdentite.UploadActeDeNaissanceID;

            _context.Add(_pieceIdentite);
            _context.SaveChanges();

            _membre.PieceIdentiteID = _pieceIdentite.ID;

            _membre.Email = membre.Email;
            _membre.TelephoneFixe = membre.TelephoneFixe;
            _membre.TelephoneMobile = membre.TelephoneMobile;
            _membre.NumCompatibleMobileMoney = membre.NumCompatibleMobileMoney;
            _membre.OperateurID = membre.OperateurID;

            if(membre.MembreReference != null){
                Membre membreReference = _context.Membre.FirstOrDefault(m => (m.Nom+" "+m.Prenom).ToLower().Contains(membre.MembreReference.ToLower()));
                if(membreReference != null)
                    _membre.PersonneReferenceID = membreReference.ID;
            }
            //_membre.AccepteCharteMembre = membre.AccepteCharteMembre;
            _context.Add(_membre);
            await _context.SaveChangesAsync();

            _membre.ID_HTPI = "HTPI_"+_membre.ID;
            _context.Update(_membre);
            await _context.SaveChangesAsync();

            //return RedirectToAction(nameof(Index));
            //}
            ViewBag.Operateurs = _context.Operateur.ToList();
            ViewBag.TypePieceIdentites = _context.TypePieceIdentite.ToList();
            ViewBag.TypeJustDomiciles = _context.TypeJustificatifDomicile.ToList();
            ViewBag.Pays = _context.Pays.ToList();
            ViewBag.Saved = 1;

            return View(_membre);
        }

        // GET: Membre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membre = await _context.Membre.SingleOrDefaultAsync(m => m.ID == id);
            if (membre == null)
            {
                return NotFound();
            }
            return View(membre);
        }

        // POST: Membre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Appellation,Nom,Prenom,Date_naissance,Nationnalite,Profession,Adresse,Code_postal,Ville,Pays,id_type_piece_identite,Num_pieece_identite,Pays_delivrance,Date_delivrance,Date_expiration,id_charger_piece_identite,id_type_justificatif_domicile,Id_Charger_justificatif_domicile,id_Charger_extrait_acte_naissance,Email,Telephone_fixe,Telephone_mobile,Num_compatible_mobile_money,id_operateur,Accepte_charte_membre")] Membre membre)
        {
            if (id != membre.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembreExists(membre.ID))
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
            return View(membre);
        }

        // GET: Membre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membre = await _context.Membre
                .SingleOrDefaultAsync(m => m.ID == id);
            if (membre == null)
            {
                return NotFound();
            }

            return View(membre);
        }

        // POST: Membre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membre = await _context.Membre.SingleOrDefaultAsync(m => m.ID == id);
            _context.Membre.Remove(membre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembreExists(int id)
        {
            return _context.Membre.Any(e => e.ID == id);
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }

    public class Term{
        public string term;
    }

    public class Admin
    {
        public string email { get; set; }
        public string password { get; set; }
}
}
