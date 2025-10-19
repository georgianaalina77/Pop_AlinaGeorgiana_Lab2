using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pop_AlinaGeorgiana_Lab2.Data;
using Pop_AlinaGeorgiana_Lab2.Models;

namespace Pop_AlinaGeorgiana_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Pop_AlinaGeorgiana_Lab2.Data.Pop_AlinaGeorgiana_Lab2Context _context;

        public IndexModel(Pop_AlinaGeorgiana_Lab2.Data.Pop_AlinaGeorgiana_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = new List<Book>() ;

        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
        }
    }
}
