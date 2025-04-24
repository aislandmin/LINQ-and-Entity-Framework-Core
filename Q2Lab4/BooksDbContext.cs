using Microsoft.EntityFrameworkCore;

public class BooksDbContext: DbContext
{
    public DbSet<AuthorISBN> AuthorISBN { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Titles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=Books;Integrated Security=True;Trust Server Certificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Define AuthorISBN as keyless
        modelBuilder.Entity<AuthorISBN>().HasNoKey();
    }

}
