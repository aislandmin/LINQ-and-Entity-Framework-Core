// See https://aka.ms/new-console-template for more information
Console.WriteLine("Question 02 - Lab 04");

using BooksDbContext books = new BooksDbContext();

// Invokes methods
Question2_1();
Question2_2();
Question2_3();

//1.Get a list of all the titles and the authors who wrote them. Sort the results by title. [2 marks]
void Question2_1()
{
    // Retrieve title, authors by joining Titles, Authors, AuthorISBN
    var bookTitleAuthors = from b in books.Titles
                           join ai in books.AuthorISBN on b.ISBN equals ai.ISBN
                           join a in books.Authors on ai.AuthorID equals a.AuthorID
                           orderby b.Title
                           select new
                           {
                               b.Title,
                               AuthorFirstName = a.FirstName,
                               AuthorLastName = a.LastName
                           };


    // put names of all authors of one book into a comma-separated string
    var groupedBooks = bookTitleAuthors
                        .GroupBy(b => b.Title)
                        .Select(g => new
                        {
                            Title = g.Key,
                            Authors = string.Join(", ", g.Select(b => b.AuthorFirstName + " " + b.AuthorLastName))
                        })
                        .OrderBy(b => b.Title);

    Console.WriteLine("1.Get a list of all the titles and the authors who wrote them. Sort the results by title");
    foreach (var book in groupedBooks)
    {
        Console.WriteLine($"\nTitle: {book.Title} \nAuthor: {book.Authors}");
    }
}

//2.Get a list of all the titles and the authors who wrote them. Sort the results by title. Each title sort the authors alphabetically by last name, then first name[4 marks]
void Question2_2()
{
    // Retrieve title, authors by joining Titles, Authors, AuthorISBN
    var bookTitleAuthors = from b in books.Titles
                           join ai in books.AuthorISBN on b.ISBN equals ai.ISBN
                           join a in books.Authors on ai.AuthorID equals a.AuthorID
                           orderby b.Title
                           select new
                           {
                               b.Title,
                               AuthorFirstName = a.FirstName,
                               AuthorLastName = a.LastName
                           };

    // Group by title, then sort authors by last name, then first name, and join author names into a comma-separated string
    var groupedBooks = bookTitleAuthors
                        .GroupBy(b => b.Title)
                        .Select(g => new
                        {
                            Title = g.Key,
                            Authors = string.Join(", ", g.OrderBy(a => a.AuthorLastName).ThenBy(a => a.AuthorFirstName)
                                                           .Select(a => a.AuthorFirstName + " " + a.AuthorLastName))
                        })
                        .OrderBy(b => b.Title);
                          

    Console.WriteLine("\n2.Get a list of all the titles and the authors who wrote them. Sort the results by title. Each title sort the authors alphabetically by last name, then first name");
    foreach (var book in groupedBooks)
    {
        Console.WriteLine($"\nTitle: {book.Title} \nAuthors: {book.Authors}");
    }
}

//3.Get a list of all the authors grouped by title, sorted by title; for a given title sort the author names alphabetically by last name then first name.[4 marks]
void Question2_3()
{
    // Retrieve title, authors by joining Titles, Authors, AuthorISBN
    var bookTitleAuthors = from b in books.Titles
                           join ai in books.AuthorISBN on b.ISBN equals ai.ISBN
                           join a in books.Authors on ai.AuthorID equals a.AuthorID
                           orderby b.Title
                           select new
                           {
                               b.Title,
                               AuthorFirstName = a.FirstName,
                               AuthorLastName = a.LastName
                           };

    // Group by title, then sort authors by last name, then first name, and join author names into a comma-separated string
    var groupedBooks = bookTitleAuthors
                        .GroupBy(b => b.Title)
                        .Select(g => new
                        {
                            Title = g.Key,
                            Authors = string.Join(", ", g.OrderBy(a => a.AuthorLastName).ThenBy(a => a.AuthorFirstName)
                                                           .Select(a => a.AuthorFirstName + " " + a.AuthorLastName))
                        })
                        .OrderBy(b => b.Title);

    Console.WriteLine("\n3. Get a list of all the authors grouped by title, sorted by title; for a given title sort the author names alphabetically by last name then first name.");
    foreach (var book in groupedBooks)
    {
        Console.WriteLine($"\nAuthors for Title: {book.Title} \n{book.Authors}");
    }
}

// Prevent console from closing immediately
Console.WriteLine("\nPress Enter to exit...");
Console.ReadLine();
