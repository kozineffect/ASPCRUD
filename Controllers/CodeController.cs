using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPCRUD.Models;

namespace ASPCRUD.Controllers
{
    public class CodeController : Controller
    {
        private readonly CodeContext _context;

        public CodeController(CodeContext context)
        {
            _context = context;    
        }

        // GET: Code
        public async Task<IActionResult> Index()
        {
            return View(await _context.Code.ToListAsync());
        }

        // GET: Code/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var code = await _context.Code
                .SingleOrDefaultAsync(m => m.ID == id);
            if (code == null)
            {
                return NotFound();
            }

            return View(code);
        }

        // GET: Code/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Code/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,Snippet,Language")] Code code)
        {
            if (ModelState.IsValid)
            {
                _context.Add(code);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(code);
        }

        // GET: Code/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var code = await _context.Code.SingleOrDefaultAsync(m => m.ID == id);
            if (code == null)
            {
                return NotFound();
            }
            return View(code);
        }

        // POST: Code/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,Snippet,Language")] Code code)
        {
            if (id != code.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(code);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodeExists(code.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(code);
        }

        // GET: Code/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var code = await _context.Code
                .SingleOrDefaultAsync(m => m.ID == id);
            if (code == null)
            {
                return NotFound();
            }

            return View(code);
        }

        // POST: Code/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var code = await _context.Code.SingleOrDefaultAsync(m => m.ID == id);
            _context.Code.Remove(code);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CodeExists(int id)
        {
            return _context.Code.Any(e => e.ID == id);
        }
    }
}
