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
    public class DetailsModel : PageModel
    {
        private readonly ListaZakupów.Data.ListaZakupówContext _context;

        public DetailsModel(ListaZakupów.Data.ListaZakupówContext context)
        {
            _context = context;
        }

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
    }
}
