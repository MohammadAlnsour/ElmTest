using ElmTest.Domain.Entities;

namespace ElmTest.Domain.Factories
{
    public interface IBookFactory
    {
        public Book CreateBook(string bookTitle, string bookDescription, string author, DateTime publishDate, string coverBase64);
        public Book CreateBookDefault();
    }
}
