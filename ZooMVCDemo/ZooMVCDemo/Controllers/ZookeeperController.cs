using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZooMVCDemo.Data;
using ZooMVCDemo.Models;

namespace ZooMVCDemo.Controllers
{

    public class ZookeeperController : Controller
    {
        private readonly string _imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

        private readonly ApplicationDbContext _context;

        public ZookeeperController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zookeepers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zookeeper.ToListAsync());
        }

        // GET: Zookeepers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zookeeper = await _context.Zookeeper
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zookeeper == null)
            {
                return NotFound();
            }

            return View(zookeeper);
        }

        // GET: Zookeepers/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zookeepers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Department,ImagePath")] Zookeeper zookeeper, IFormFile ImagePath)
        {
            if (ModelState.IsValid)
            {
                if (ImagePath != null && ImagePath.Length > 0)
                {

                    if (!Directory.Exists(_imagePath))
                    {
                        Directory.CreateDirectory(_imagePath);
                    }


                    var filename = Path.GetFileNameWithoutExtension(ImagePath.FileName) + Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
                    var filepath = Path.Combine(_imagePath, filename);

                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        await ImagePath.CopyToAsync(stream);
                    }
                    zookeeper.ImagePath = $"/images/{filename}";

                }
                else
                {
                    ModelState.AddModelError("", "Please upload an image.");
                }
                _context.Add(zookeeper);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zookeeper);
        }

        // GET: Zookeepers/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zookeeper = await _context.Zookeeper.FindAsync(id);
            if (zookeeper == null)
            {
                return NotFound();
            }
            return View(zookeeper);
        }

        // POST: Zookeepers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Department,ImagePath")] Zookeeper zookeeper)
        {
            if (id != zookeeper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zookeeper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZookeeperExists(zookeeper.Id))
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
            return View(zookeeper);
        }

        // GET: Zookeepers/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zookeeper = await _context.Zookeeper
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zookeeper == null)
            {
                return NotFound();
            }

            return View(zookeeper);
        }

        // POST: Zookeepers/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zookeeper = await _context.Zookeeper.FindAsync(id);
            _context.Zookeeper.Remove(zookeeper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZookeeperExists(int id)
        {
            return _context.Zookeeper.Any(e => e.Id == id);
        }

        public async Task <IActionResult> HomepageView()
        {
            return View(await _context.Zookeeper.ToListAsync());
        }
    }
}
