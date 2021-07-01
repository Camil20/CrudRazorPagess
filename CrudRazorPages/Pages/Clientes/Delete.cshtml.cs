using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrudRazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudRazorPages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly CrudRazorPages.VentasContext _context;

        public DeleteModel(CrudRazorPages.VentasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente = await _context.Clientes.Include(x => x.Estado).FirstOrDefaultAsync(m => m.ClienteId == id);

            if (Cliente == null)
            {
                return NotFound();
            }
            
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nombres");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente = await _context.Clientes.FindAsync(id);

            if (Cliente != null)
            {
                _context.Clientes.Remove(Cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
