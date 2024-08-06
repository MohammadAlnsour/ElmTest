namespace ElmTest.Domain.Entities
{
    public class Book : IAggregateRoot
    {
        public int BookId { get; set; }
        public string BookInfo { get; set; }
        public DateTime LastModified { get; set; }
    }
}
