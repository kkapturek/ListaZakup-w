using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ListaZakupów.Data;
using ListaZakupów.Models;

namespace ListaZakupów.Pages.MojeListy
{
    public class DeleteModel : PageModel
    {
        private readonly ListaZakupów.Data.ListaZakupówContext _context;

        public DeleteModel(ListaZakupów.Data.ListaZakupówContext context)
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

            var jednalista = await _context.JednaLista.FirstOrDefaultAsync(m => m.Id == id);

            if (jednalista == null)
            {
                return NotFound();
            }
            else 
            {
                JednaLista = jednalista;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.JednaLista == null)
            {
                return NotFound();
            }
            var jednalista = await _context.JednaLista.FindAsync(id);

            if (jednalista != null)
            {
                JednaLista = jednalista;
                _context.JednaLista.Remove(JednaLista);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
