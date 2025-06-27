namespace LibrarySystem.Model
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string Borrower { get; set; }

        public Book(string isbn, string title, string author, int year, decimal price, bool isAvailable, string borrower)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Year = year;
            Price = price;
            IsAvailable = isAvailable;
            Borrower = borrower;
        }

        public override string ToString()
        {
            return $"{Title}, {Author} - {Year}";
        }
    }
}
