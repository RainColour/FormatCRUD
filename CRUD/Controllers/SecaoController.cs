using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class SecaoController : Controller
    {
        private readonly FormatDbContext _context;

        public SecaoController(FormatDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var secoes = await _context.Secoes.Include(s => s.Trabalho).ToListAsync();
            return View(secoes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secao = await _context.Secoes
                .Include(s => s.Trabalho)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (secao == null)
            {
                return NotFound();
            }

            return View(secao);
        }

        public IActionResult Create()
        {
            ViewData["TrabalhoId"] = new SelectList(_context.Trabalhos, "Id", "Titulo");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Conteudo,TrabalhoId")] Secao secao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(secao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrabalhoId"] = new SelectList(_context.Trabalhos, "Id", "Titulo", secao.TrabalhoId);
            return View(secao);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secao = await _context.Secoes.FindAsync(id);
            if (secao == null)
            {
                return NotFound();
            }
            ViewData["TrabalhoId"] = new SelectList(_context.Trabalhos, "Id", "Titulo", secao.TrabalhoId);
            return View(secao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Conteudo,TrabalhoId")] Secao secao)
        {
            if (id != secao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(secao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecaoExists(secao.Id))
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
            ViewData["TrabalhoId"] = new SelectList(_context.Trabalhos, "Id", "Titulo", secao.TrabalhoId);
            return View(secao);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secao = await _context.Secoes
                .Include(s => s.Trabalho)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (secao == null)
            {
                return NotFound();
            }

            return View(secao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var secao = await _context.Secoes.FindAsync(id);
            _context.Secoes.Remove(secao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SecaoExists(int id)
        {
            return _context.Secoes.Any(e => e.Id == id);
        }
    }
}
