using MySqlOnFire.Models;

namespace MySqlOnFire.Data;

public class LibraryContext : DbContext {
   public DbSet<Book>? Books { get; set; }
   public DbSet<Publisher>? Publishers { get; set; }
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
     optionsBuilder.UseMySQL("server=localhost;database=library;user=root;port=3333;password=secret");
   }
   protected override void OnModelCreating(ModelBuilder modelBuilder) {
     base.OnModelCreating(modelBuilder);
     modelBuilder.Entity<Publisher>(entity => {
         entity.HasKey(e => e.PublisherId);
         entity.Property(e => e.Name).IsRequired();
     });
     modelBuilder.Entity<Book>(entity => {
         entity.HasKey(e => e.ISBN);
         entity.Property(e => e.Title).IsRequired();
         entity.HasOne(d => d.Publisher)
         .WithMany(p => p!.Books);
     });
     modelBuilder.Entity<Publisher>().HasData(
         new Publisher {
             PublisherId = 1,
             Name = "Mariner Books"
         },
         new Publisher {
             PublisherId = 2,
             Name = "Penguin Books"
         }
     );
     modelBuilder.Entity<Book>().HasData(
         new Book {
             ISBN = "978-0544003415",
             Title = "The Lord of the Rings",
             Author = "J.R.R. Tolkien",
             Language = "English",
             Pages = 1216,
             PublisherId = 1
         },
         new Book {
             ISBN = "978-0547247762",
             Title = "The Sealed Letter",
             Author = "Emma Donoghue",
             Language = "English",
             Pages = 416,
             PublisherId = 1
         },
         new Book {
             ISBN = "978-0143107569",
             Title = "Les Miserables",
             Author = "Victor Hugo",
             Language = "English",
             Pages = 1456,
             PublisherId = 2
         },
         new Book {
             ISBN = "978-0140449174",
             Title = "Anna Karenina",
             Author = "Leo Tolstoy",
             Language = "English",
             Pages = 880,
             PublisherId = 2
         }
     );
   }
}
