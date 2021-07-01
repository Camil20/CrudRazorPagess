using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrudRazorPages;

namespace CrudRazorPages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly CrudRazorPages.VentasContext _context;

        public CreateModel(CrudRazorPages.VentasContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nombres");
            return Page();
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
