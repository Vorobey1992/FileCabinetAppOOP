
namespace FileCabinetAppOOP.Task1
{
    [CacheExpiration(ExpirationTime = 10)]
    public class Book : IDocument
    {
        public string? ISBN { get; set; }
        public string? Title { get; set; }
        public string? Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string? Publisher { get; set; }
        public DateTime DatePublished { get; set; }

        public void PrintDocumentInfo()
        {
            Console.WriteLine($"Type: {this.GetType().Name}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Authors: {Authors}");
            Console.WriteLine($"Number of Pages: {NumberOfPages}");
            Console.WriteLine($"Publisher: {Publisher}");
            Console.WriteLine($"Date Published: {DatePublished}");
            int cacheExpirationTime = DocumentProcessor.GetCacheExpirationTime(this.GetType());
            Console.WriteLine($"Cache Expiration Time: {cacheExpirationTime} minutes");
            Console.WriteLine();
        }
        public string GetDocumentNumber()
        {
            // Implementation specific to Book.
            return ISBN ?? "";
        }
    }
}
