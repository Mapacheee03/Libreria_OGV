

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;
using System.Linq;

namespace Libreria_OGV.Data.Models
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Titulo = "1st Book Tittle",
                        Descripcion = "1st Book Desciption",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genero = "Biography",
                        Autor = "1st Author",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,

                    },
                    new Book()
                    {
                        Titulo = "2nd Book Tittle",
                        Descripcion = "2nd Book Desciption",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genero = "Biography",
                        Autor = "2nd Author",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
