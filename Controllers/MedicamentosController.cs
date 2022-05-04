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
    public class MedicamentosController : Controller
    {
        private readonly Contexto _context;

        public MedicamentosController(Contexto context)
        {
            _context = context;
        }

        // GET: Medicamentos
        public async Task<IActionResult> Index(string filtro = null)
        {

            if (filtro != null)
            {
                var contexto = _context.Medicamentos.Where(x => x.Medicamento.Contains(filtro) || x.Registro.Contains(filtro))
                    .Include(m => m.Fabricante);
                return View(await contexto.ToListAsync());
            }
            else
            {
                var contexto = _context.Medicamentos.Include(m => m.Fabricante);
                return View(await contexto.ToListAsync());
            }
        }

        // GET: Medicamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentos = await _context.Medicamentos
                .Include(m => m.Fabricante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamentos == null)
            {
                return NotFound();
            }

            var listaReacoes = _context.Reacoes.ToList();

            if (!string.IsNullOrWhiteSpace(medicamentos.ReacoesMedicamento))
            {
                var reacoesMedicamento = medicamentos.ReacoesMedicamento.Split(";");

                listaReacoes.ForEach(item =>
                {
                    if (reacoesMedicamento.Where(x => x == item.Id.ToString()).Any())
                    {
                        item.Checked = true;
                    }
                    else
                    {
                        item.Checked = false;
                    }
                });
            }
            ViewData["Reacoes"] = listaReacoes;

            return View(medicamentos);
        }

        // GET: Medicamentos/Create
        public IActionResult Create()
        {
            ViewData["IdFabricante"] = new SelectList(_context.Fabricante, "Id", "Nome");
            ViewData["Reacoes"] = _context.Reacoes.ToList();

            return View();
        }

        // POST: Medicamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Registro,Medicamento,Validade,Telefone,Preço,Quantidade,IdFabricante,Nome,ReacoesMedicamento")] Medicamentos medicamentos)
        {
            //var novaData = new DateTime(medicamentos.Validade.Year, medicamentos.Validade.Month, medicamentos.Validade.Day, 0, 0, 0, DateTimeKind.Unspecified); 
            _context.Add(medicamentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
            //ViewData["IdFabricante"] = new SelectList(_context.Fabricante, "Id", "Nome", medicamentos.IdFabricante);
            //return View(medicamentos);
        }

        // GET: Medicamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentos = await _context.Medicamentos.FindAsync(id);
            if (medicamentos == null)
            {
                return NotFound();
            }

            var listaReacoes = _context.Reacoes.ToList();

            if (!string.IsNullOrWhiteSpace(medicamentos.ReacoesMedicamento))
            {
                var reacoesMedicamento = medicamentos.ReacoesMedicamento.Split(";");

                listaReacoes.ForEach(item =>
                {
                    if (reacoesMedicamento.Where(x => x == item.Id.ToString()).Any())
                    {
                        item.Checked = true;
                    }
                    else
                    {
                        item.Checked = false;
                    }
                });
            }
            ViewData["Reacoes"] = listaReacoes;

            ViewData["IdFabricante"] = new SelectList(_context.Fabricante, "Id", "Nome", medicamentos.IdFabricante);


            return View(medicamentos);
        }

        // POST: Medicamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Registro,Medicamento,Validade,Telefone,Preço,Quantidade,IdFabricante,Nome,ReacoesMedicamento")] Medicamentos medicamentos)
        {
            if (id != medicamentos.Id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(medicamentos);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentosExists(medicamentos.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            ViewData["IdFabricante"] = new SelectList(_context.Fabricante, "Id", "Nome", medicamentos.IdFabricante);
            return View(medicamentos);
        }

        // GET: Medicamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentos = await _context.Medicamentos
                .Include(m => m.Fabricante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamentos == null)
            {
                return NotFound();
            }

            return View(medicamentos);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicamentos = await _context.Medicamentos.FindAsync(id);
            _context.Medicamentos.Remove(medicamentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentosExists(int id)
        {
            return _context.Medicamentos.Any(e => e.Id == id);
        }
    }
}
