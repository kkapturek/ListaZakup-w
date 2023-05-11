using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ListaZakupów.Models;

namespace ListaZakupów.Data
{
    public class ListaZakupówContext : DbContext
    {
        public ListaZakupówContext (DbContextOptions<ListaZakupówContext> options)
            : base(options)
        {
        }

        public DbSet<ListaZakupów.Models.JednaLista> JednaLista { get; set; } = default!;
    }
}
