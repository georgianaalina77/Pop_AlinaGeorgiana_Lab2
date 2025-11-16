using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pop_AlinaGeorgiana_Lab2.Data;
using Pop_AlinaGeorgiana_Lab2.Models;

namespace Pop_AlinaGeorgiana_Lab2.Pages.Books
{
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Pop_AlinaGeorgiana_Lab2Context _context;

        public EditModel(Pop_AlinaGeorgiana_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories).ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
                return NotFound();

            
            ViewData["AuthorID"] = new SelectList(
                _context.Author.Select(a => new
                {
                    a.ID,
                    FullName = a.FirstName + " " + a.LastName
                }),
                "ID",
                "FullName",
                Book.AuthorID   
            );

            ViewData["PublisherID"] = new SelectList(
                _context.Publisher,
                "ID",
                "PublisherName",
                Book.PublisherID
            );

            PopulateAssignedCategoryData(_context, Book);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
                return NotFound();

            var bookToUpdate = await _context.Book
                .Include(b => b.BookCategories).ThenInclude(bc => bc.Category)
                .FirstOrDefaultAsync(b => b.ID == id);

            if (bookToUpdate == null)
                return NotFound();

           
            if (await TryUpdateModelAsync<Book>(
                bookToUpdate,
                "Book",
                b => b.Title,
                b => b.Price,
                b => b.PublishingDate,
                b => b.PublisherID,
                b => b.AuthorID      
            ))
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

           
            ViewData["AuthorID"] = new SelectList(
                _context.Author,
                "ID",
                "FirstName",
                bookToUpdate.AuthorID
            );
            ViewData["PublisherID"] = new SelectList(
                _context.Publisher,
                "ID",
                "PublisherName",
                bookToUpdate.PublisherID
            );

            PopulateAssignedCategoryData(_context, bookToUpdate);
            return Page();
        }
    }
}
