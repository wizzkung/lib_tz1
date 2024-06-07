using lib_tz1.models;
using Microsoft.EntityFrameworkCore;

namespace lib_tz1.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> books { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Book_issue> book_issues { get; set; }
        public DbSet<ReturnedBooks> returnedBooks { get; set; }
        public DbSet<UnreturnedBook> unreturnedBooks { get; set; }
    }
}
