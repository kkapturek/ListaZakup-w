using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListaZakupów.Data;
using ListaZakupów.Models;

namespace ListaZakupów.Pages.MojeListy
{
    public class EditModel : PageModel
    {
        private readonly ListaZakupów.Data.ListaZakupówContext _context;

        public EditModel(ListaZakupów.Data.ListaZakupówContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JednaLista JednaLista { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.JednaLista == null)
            {
                return NotFound();
            }

            var jednalista =  await _context.JednaLista.FirstOrDefaultAsync(m => m.Id == id);
            if (jednalista == null)
            {
                return NotFound();
            }
            JednaLista = jednalista;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(JednaLista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JednaListaExists(JednaLista.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JednaListaExists(string id)
        {
          return (_context.JednaLista?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
