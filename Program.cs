using MySqlOnFire.Data;

CreateDbSeedData();
PrintPublishers();
PrintBooks();

static void CreateDbSeedData() {
    using (var context = new LibraryContext()) {
        // Creates the database if not exists
        context.Database.EnsureCreated();
    }
}

static void PrintBooks() {
    // Gets and prints all books in database
    using (var context = new LibraryContext()) {
        var books = context.Books!
          .Include(p => p.Publisher);
        Console.WriteLine(new string('=', 30));
        foreach (var book in books!) {
            Console.WriteLine(book);
        }
    }
}

static void PrintPublishers() {
    // Gets and prints all books in database
    using (var context = new LibraryContext()) {
        var data = context.Publishers;
        Console.WriteLine(new string('=', 30));
        foreach (var item in data!) {
            Console.WriteLine(item);
        }
    }
}