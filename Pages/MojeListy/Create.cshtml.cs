using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ListaZakupów.Data;
using ListaZakupów.Models;

namespace ListaZakupów.Pages.MojeListy
{
    public class CreateModel : PageModel
    {
        private readonly ListaZakupów.Data.ListaZakupówContext _context;

        public CreateModel(ListaZakupów.Data.ListaZakupówContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JednaLista JednaLista { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.JednaLista == null || JednaLista == null)
            {
                return Page();
            }

            _context.JednaLista.Add(JednaLista);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
