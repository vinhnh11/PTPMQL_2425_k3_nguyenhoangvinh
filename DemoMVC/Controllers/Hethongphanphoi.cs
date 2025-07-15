using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class HethongphanphoiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HethongphanphoiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hethongphanphoi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hethongphanphois.ToListAsync());
        }

        // GET: Hethongphanphoi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var hethongphanphoi = await _context.Hethongphanphois
                .FirstOrDefaultAsync(m => m.MaHTPP == id);

            if (hethongphanphoi == null) return NotFound();

            return View(hethongphanphoi);
        }

        // GET: Hethongphanphoi/Create
        public async Task<IActionResult> Create()
        {
            var lastHTPP = await _context.Hethongphanphois
                .OrderByDescending(h => h.MaHTPP)
                .FirstOrDefaultAsync();

            string lastID = lastHTPP?.MaHTPP ?? "HT000";
            var autoGen = new AutoGenerateCode();
            string newMaHTPP = autoGen.GenerateCode(lastID);

            ViewBag.NewMaHTPP = newMaHTPP;

            return View();
        }

        // POST: Hethongphanphoi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHTPP,TenHTPP,TenHTPP2")] Hethongphanphoi hethongphanphoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hethongphanphoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hethongphanphoi);
        }

        // GET: Hethongphanphoi/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var hethongphanphoi = await _context.Hethongphanphois.FindAsync(id);
            if (hethongphanphoi == null) return NotFound();

            return View(hethongphanphoi);
        }

        // POST: Hethongphanphoi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHTPP,TenHTPP,TenHTPP2")] Hethongphanphoi hethongphanphoi)
        {
            if (id != hethongphanphoi.MaHTPP) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hethongphanphoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HethongphanphoiExists(hethongphanphoi.MaHTPP))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hethongphanphoi);
        }

        // GET: Hethongphanphoi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            var hethongphanphoi = await _context.Hethongphanphois
                .FirstOrDefaultAsync(m => m.MaHTPP == id);

            if (hethongphanphoi == null) return NotFound();

            return View(hethongphanphoi);
        }

        // POST: Hethongphanphoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hethongphanphoi = await _context.Hethongphanphois.FindAsync(id);
            if (hethongphanphoi != null)
            {
                _context.Hethongphanphois.Remove(hethongphanphoi);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool HethongphanphoiExists(string id)
        {
            return _context.Hethongphanphois.Any(e => e.MaHTPP == id);
        }
    }
}
