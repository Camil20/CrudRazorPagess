﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrudRazorPages;

namespace CrudRazorPages.Clientes
{
    public class DetailsModel : PageModel
    {
        private readonly CrudRazorPages.VentasContext _context;

        public DetailsModel(CrudRazorPages.VentasContext context)
        {
            _context = context;
        }

        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.ClienteId == id);

            if (Cliente == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
