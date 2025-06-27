using LibrarySystem.Model;
using System.Text.Json;

namespace LibrarySystem.Data
{
    public class DataContext
    {
        private string dataPath;

        private StreamWriter writer;
        private StreamReader reader;

        public DataContext(string _dataPath)
        {
            dataPath = _dataPath;
        }

        public List<Book> Books { get; set; }

        public List<Book> GetAllBooks()
        {
            using(reader = new StreamReader(dataPath))
            {
                string data = reader.ReadToEnd();
                return JsonSerializer.Deserialize<List<Book>>(data)!;
            }
        }

        public void Save(List<Book> books)
        {
            using (writer = new StreamWriter(dataPath))
            {
                string data = JsonSerializer.Serialize(books);
                writer.Write(data);
            }
        }
    }
}
