

using Domain.Models;
using Infrastructure.Repository;

BookRepository bookrepo = new();
AuthorRepository authrepo = new();


while (true)
{
    System.Console.WriteLine("===============================");
    System.Console.WriteLine(@"    Book
1 - Show all Book.
2 - Show Book.
3 - Add new Book.
4 - Update Book.
5 - Delete Book.
    Author
6 - Show all Author
7 - Show Author
8 - Add Author
9 - Update Author
10 - Delete Author
0 - Exit.");
    var a = Console.ReadLine();
    System.Console.WriteLine("===============================");
    switch (a)
    {
        case "1":
            var all = bookrepo.GetBooks();
            foreach (var item in all)
            {
                System.Console.WriteLine(item.Id + " | " + item.Title + " | " + item.PublishedYear + " | " + item.TotalCopies);
            }
            break;

        case "2":
            System.Console.Write("Enter id: ");
            var id2 = Convert.ToInt32(Console.ReadLine());
            var get2 = bookrepo.GetBook(id2);
            if (get2 == null)
            {
                System.Console.WriteLine("Not fiend");
            }
            else
            {
                System.Console.WriteLine(get2.Title + " | " + get2.PublishedYear + " | " + get2.TotalCopies);
            }
            break;

        case "3":
            System.Console.Write("Enter title: ");
            var title3 = Console.ReadLine()!;
            System.Console.Write("Enter PublishedYear: ");
            var published3 = Convert.ToInt32(Console.ReadLine())!;
            System.Console.Write("Enter TotalCopies: ");
            var total3 = Convert.ToInt32(Console.ReadLine()!);
            var book = new Book()
            {
                Title = title3,
                PublishedYear = published3,
                TotalCopies = total3
            };
            bookrepo.AddBook(book);
            break;

        case "4":
            System.Console.WriteLine("Enter Id: ");
            var id4 = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter new Title: ");
            var title4 = Console.ReadLine()!;
            System.Console.Write("Enter new PublishedYear: ");
            var publish4 = Convert.ToInt32(Console.ReadLine())!;
            System.Console.Write("Enter new Totalcopies: ");
            var total4 = Convert.ToInt32(Console.ReadLine())!;
            var book4 = new Book()
            {
                Id = id4,
                Title = title4,
                PublishedYear = publish4,
                TotalCopies = total4
            };
            bookrepo.UpdateBook(book4);
            break;

        case "5":
            System.Console.Write("Enter id: ");
            var delete = Convert.ToInt32(Console.ReadLine());
            bookrepo.DeleteBook(delete);
            break;

        case "6":
            var all6 = authrepo.GetAuthors();
            foreach (var it in all6)
            {
                Console.WriteLine($"{it.Id} | {it.FullName} | {it.Country} | {it.BirthYear}");
            }
            break;

        case "7":
            Console.Write("Enter id: ");
            var id7 = Convert.ToInt32(Console.ReadLine());
            var show7 = authrepo.GetAuthor(id7);
            if (show7 == null)
            {
                System.Console.WriteLine("Author not fiend");
            }
            else
            {
                Console.WriteLine($"{show7!.Id} | {show7.FullName} | {show7.Country} | {show7.BirthYear}");
            }
            break;
        case "8":
            Console.Write("Enter new Fullname: ");
            string name8 = Console.ReadLine()!;
            Console.Write("Enter new Country: ");
            string country8 = Console.ReadLine()!;
            Console.Write("Enter new Birthyear: ");
            int birth = Convert.ToInt32(Console.ReadLine());
            Author author = new()
            {
                FullName = name8,
                Country = country8,
                BirthYear = birth
            };
            authrepo.AddAuthor(author);
            break;

        case "9":
            Console.Write("Enter Id: ");
            int id9 = Convert.ToInt32(Console.ReadLine());
            var auth9 = authrepo.GetAuthor(id9);
            if (auth9 == null)
            {
                System.Console.WriteLine("Author not fiend");
            }
            else
            {
                Console.Write("Enter new Fullname: ");
                string name9 = Console.ReadLine()!;
                Console.Write("Enter new Country: ");
                string country9 = Console.ReadLine()!;
                Console.Write("Enter new Birthyear: ");
                int birth9 = Convert.ToInt32(Console.ReadLine());
                Author author9 = new()
                {
                    Id = id9,
                    FullName = name9,
                    Country = country9,
                    BirthYear = birth9
                };
                authrepo.UpdateAuthor(author9);
            }
            break;

        case "10":
            Console.Write("Enter id: ");
            var id10 = Convert.ToInt32(Console.ReadLine());
            authrepo.DeleteAuthor(id10);
            break;

        case "0":
            System.Console.WriteLine("Exiting ...");
            return;
    }
}
