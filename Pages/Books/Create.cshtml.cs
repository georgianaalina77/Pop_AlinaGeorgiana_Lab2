using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pop_AlinaGeorgiana_Lab2.Data;
using Pop_AlinaGeorgiana_Lab2.Models;

namespace Pop_AlinaGeorgiana_Lab2.Pages.Books
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : BookCategoriesPageModel

    {
        private readonly Pop_AlinaGeorgiana_Lab2Context _context;

        public CreateModel(Pop_AlinaGeorgiana_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet()
        {
            
            ViewData["AuthorID"] = new SelectList(
                _context.Author
                    .Select(a => new
                    {
                        a.ID,
                        FullName = a.FirstName + " " + a.LastName
                    }),
                "ID",
                "FullName"
            );

            
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");

            
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();

            
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    newBook.BookCategories.Add(new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    });
                }
            }

            
            newBook.Title = Book.Title;
            newBook.Price = Book.Price;
            newBook.PublishingDate = Book.PublishingDate;
            newBook.PublisherID = Book.PublisherID;
            newBook.AuthorID = Book.AuthorID; 

            newBook.BookCategories = newBook.BookCategories;

            
            _context.Book.Add(newBook);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
