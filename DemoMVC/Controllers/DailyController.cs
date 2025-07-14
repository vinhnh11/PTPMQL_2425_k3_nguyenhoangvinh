using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class DailyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DailyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Daily
        public async Task<IActionResult> Index()
        {
            var dailys = await _context.Dailys.ToListAsync();
            return View(dailys);
        }

        // GET: Daily/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();

            var daily = await _context.Dailys
                .FirstOrDefaultAsync(m => m.MaDaiLy == id);

            if (daily == null)
                return NotFound();

            return View(daily);
        }

        // GET: Daily/Create
        public IActionResult Create()
        {
        var lastDaiLy = _context.Dailys
        .OrderByDescending(dl => dl.MaDaiLy)
        .FirstOrDefault();

        var lastID = lastDaiLy?.MaDaiLy ?? "DL000";

        var autoGen = new AutoGenerateCode();
    string newMaDaiLy = autoGen.GenerateCode(lastID);

    ViewBag.NewMaDaiLy = newMaDaiLy;
    return View();
        }

        // POST: Daily/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDaiLy,TenDaiLy,DiaChi,NguoiDaiDien,MaHTPP,Dienthoai")] Daily daily)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daily);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daily);
        }

        // GET: Daily/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
                return NotFound();

            var daily = await _context.Dailys.FindAsync(id);
            if (daily == null)
                return NotFound();

            return View(daily);
        }

        // POST: Daily/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaDaiLy,TenDaiLy,DiaChi,NguoiDaiDien,MaHTPP,Dienthoai")] Daily daily)
        {
            if (id != daily.MaDaiLy)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daily);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyExists(daily.MaDaiLy))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(daily);
        }

        // GET: Daily/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return NotFound();

            var daily = await _context.Dailys
                .FirstOrDefaultAsync(m => m.MaDaiLy == id);

            if (daily == null)
                return NotFound();

            return View(daily);
        }

        // POST: Daily/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var daily = await _context.Dailys.FindAsync(id);
            if (daily != null)
            {
                _context.Dailys.Remove(daily);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DailyExists(string id)
        {
            return _context.Dailys.Any(e => e.MaDaiLy == id);
        }
    }
}