using Microsoft.EntityFrameworkCore;
using Pop_AlinaGeorgiana_Lab2.Models;

namespace Pop_AlinaGeorgiana_Lab2.Data
{
    public class Pop_AlinaGeorgiana_Lab2Context : DbContext
    {
        public Pop_AlinaGeorgiana_Lab2Context(DbContextOptions<Pop_AlinaGeorgiana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Member> Member { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Borrowing> Borrowing { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Author> Author { get; set; }
    }
}

