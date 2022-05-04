#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebGerenciamento.Models;

namespace WebGerenciamento.Controllers
{
    public class ReacoesController : Controller
    {
        private readonly Contexto _context;

        public ReacoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Reacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reacoes.ToListAsync());
        }

        // GET: Reacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reacoes = await _context.Reacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reacoes == null)
            {
                return NotFound();
            }

            return View(reacoes);
        }

        // GET: Reacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Reacoes reacoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reacoes);
        }

        // GET: Reacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reacoes = await _context.Reacoes.FindAsync(id);
            if (reacoes == null)
            {
                return NotFound();
            }
            return View(reacoes);
        }

        // POST: Reacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Reacoes reacoes)
        {
            if (id != reacoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReacoesExists(reacoes.Id))
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
            return View(reacoes);
        }

        // GET: Reacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reacoes = await _context.Reacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reacoes == null)
            {
                return NotFound();
            }

            return View(reacoes);
        }

        // POST: Reacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reacoes = await _context.Reacoes.FindAsync(id);
            _context.Reacoes.Remove(reacoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReacoesExists(int id)
        {
            return _context.Reacoes.Any(e => e.Id == id);
        }
    }
}
