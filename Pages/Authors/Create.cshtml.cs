using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pop_AlinaGeorgiana_Lab2.Data;
using Pop_AlinaGeorgiana_Lab2.Models;

namespace Pop_AlinaGeorgiana_Lab2.Pages.Authores
{
    public class CreateModel : PageModel
    {
        private readonly Pop_AlinaGeorgiana_Lab2.Data.Pop_AlinaGeorgiana_Lab2Context _context;

        public CreateModel(Pop_AlinaGeorgiana_Lab2.Data.Pop_AlinaGeorgiana_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Author.Add(Author);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
