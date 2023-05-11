using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ListaZakupów.Data;
using ListaZakupów.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListaZakupów.Pages.MojeListy
{
    public class IndexModel : PageModel
    {
        private readonly ListaZakupów.Data.ListaZakupówContext _context;

        public IndexModel(ListaZakupów.Data.ListaZakupówContext context)
        {
            _context = context;
        }

        public IList<JednaLista> JednaLista { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Item { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? ItemName { get; set; }

        public async Task OnGetAsync()
        {
            var mojelisty = from l in _context.JednaLista
                            select l;
            if (!string.IsNullOrEmpty(SearchString))
            {
                mojelisty = mojelisty.Where(s => s.Item.Contains(SearchString));
            }

            JednaLista = await mojelisty.ToListAsync();
        }
    }
}
