using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pop_AlinaGeorgiana_Lab2.Models;

namespace Pop_AlinaGeorgiana_Lab2.Data
{
    public class Pop_AlinaGeorgiana_Lab2Context : DbContext
    {
        public Pop_AlinaGeorgiana_Lab2Context (DbContextOptions<Pop_AlinaGeorgiana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Pop_AlinaGeorgiana_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Pop_AlinaGeorgiana_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Pop_AlinaGeorgiana_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Pop_AlinaGeorgiana_Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Pop_AlinaGeorgiana_Lab2.Models.Member> Member { get; set; } = default!;
        public DbSet<Pop_AlinaGeorgiana_Lab2.Models.Borrowing> Borrowing { get; set; } = default!;
        
        
    }
}
