namespace oop
{
    public class Book
    {
        private string title;
        private string author;
        private string isbn;
        private bool availability;

       
        public Book(string title, string author, string isbn)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.availability = true; 
        }

       
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public bool Availability
        {
            get { return availability; }
            set { availability = value; }
        }
    }

    public class Library
    {
        private List<Book> books;

       
        public Library()
        {
            books = new List<Book>();
        }

        
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book '{book.Title}' by {book.Author} added to the library.");
        }

       
        public Book SearchBook(string searchQuery)
        {
            foreach (var book in books)
            {
                if (book.Title.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    book.Author.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return book;
                }
            }
            Console.WriteLine($"No book found matching '{searchQuery}'.");
            return null;
        }

       
        public void BorrowBook(string searchQuery)
        {
            Book book = SearchBook(searchQuery);
            if (book != null)
            {
                if (book.Availability)
                {
                    book.Availability = false;
                    Console.WriteLine($"You have successfully borrowed '{book.Title}'.");
                }
                else
                {
                    Console.WriteLine($"The book '{book.Title}' is already borrowed.");
                }
            }
        }

       
        public void ReturnBook(string searchQuery)
        {
            Book book = SearchBook(searchQuery);
            if (book != null)
            {
                if (!book.Availability)
                {
                    book.Availability = true;
                    Console.WriteLine($"You have successfully returned '{book.Title}'.");
                }
                else
                {
                    Console.WriteLine($"The book '{book.Title}' was not borrowed.");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); 

            
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); 

            Console.ReadLine();
        }
    }
}
