namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            //var command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, command));
            //Console.WriteLine(GetGoldenBooks(dbContext));
            //Console.WriteLine(GetBooksByPrice(dbContext));
            var year = int.Parse(Console.ReadLine());
            Console.WriteLine(GetBooksNotReleasedIn(dbContext, year));
        }

        //Problem 01
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books.Where(b => Enum.Parse<AgeRestriction>(command, true) == b.AgeRestriction)
                .Select(b => new { b.Title })
                .OrderBy(b => b.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 02
        public static string GetGoldenBooks(BookShopContext context)
        {
            EditionType editionType = Enum.Parse<EditionType>("gold", true);

            var books = context.Books
                .Where(b => b.EditionType == editionType)
                .Where(b => b.Copies < 5000)
                .Select(b => new { b.Title, b.BookId })
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 03
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new { b.Title, b.Price })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books.OrderByDescending(b => b.Price))
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 04
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new { b.Title, b.BookId })
                .OrderBy(b => b.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }
    }
}