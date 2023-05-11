using Microsoft.EntityFrameworkCore;
using ListaZakupów.Data;

namespace ListaZakupów.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ListaZakupówContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ListaZakupówContext>>()))
            {
                if (context == null || context.JednaLista == null)
                {
                    throw new ArgumentNullException("Null ListaZakupówContext");
                }

                // Look for any movies.
                if (context.JednaLista.Any())
                {
                    return;   // DB has been seeded
                }

                context.JednaLista.AddRange(
                    new JednaLista
                    {
                        Id = "1",
                        Item = "Jajka",
                        IsBought = "No"

                    },

                    new JednaLista
                    {
                        Id = "2",
                        Item = "Mleko",
                        IsBought = "No"
                    },

                    new JednaLista
                    {
                        Id = "3",
                        Item = "Bułki",
                        IsBought = "No"
                    },

                    new JednaLista
                    {
                        Id = "4",
                        Item = "Masło",
                        IsBought = "No"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
