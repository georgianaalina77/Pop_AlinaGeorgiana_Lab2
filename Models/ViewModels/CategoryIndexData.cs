using System.Collections.Generic;
using Pop_AlinaGeorgiana_Lab2.Models;

namespace Pop_AlinaGeorgiana_Lab2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}

