using LibrarySystem.Model;
using System.Text.Json;

namespace LibrarySystem.Data
{
    public class DataContext
    {
        public List<Book> Books { get; private set; }

        private string dataPath;

        private StreamWriter writer;
        private StreamReader reader;

        public DataContext(string _dataPath)
        {
            dataPath = _dataPath;
            LoadBooks();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            Save();
        }

        public bool BorrowBook(string isbn, string borrowerName)
        {
            Book? bookToBorrow = Books.Find(b => b.ISBN == isbn);
            if(bookToBorrow != null && bookToBorrow.IsAvailable)
            {
                bookToBorrow.IsAvailable = false;
                bookToBorrow.Borrower = borrowerName;
                Save();
                return true;
            }
            return false;
        }

        public bool ReturnBook(string isbn)
        {
            Book? bookToReturn = Books.Find(b => b.ISBN == isbn);
            if (bookToReturn != null && !bookToReturn.IsAvailable)
            {
                bookToReturn.IsAvailable = true;
                bookToReturn.Borrower = string.Empty;
                Save();
                return true;
            }
            return false;
        }

        private void Save()
        {
            using (writer = new StreamWriter(dataPath))
            {
                string data = JsonSerializer.Serialize(Books);
                writer.Write(data);
            }
        }

        private void LoadBooks()
        {
            using (reader = new StreamReader(dataPath))
            {
                string data = reader.ReadToEnd();
                Books = JsonSerializer.Deserialize<List<Book>>(data)!;
            }
        }
    }
}
