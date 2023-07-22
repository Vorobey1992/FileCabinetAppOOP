
namespace FileCabinetAppOOP.Task2
{
    [CacheExpiration(ExpirationTime = 60)]
    public class Magazine : IDocument
    {
        public string? Title { get; set; }
        public string? Authors { get; set; }
        public DateTime DatePublished { get; set; }
        public string? Publisher { get; set; }
        public int ReleaseNumber { get; set; }

        public void PrintDocumentInfo()
        {
            Console.WriteLine($"Type: {this.GetType().Name}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Authors: {Authors}");
            Console.WriteLine($"Date Published: {DatePublished}");
            Console.WriteLine($"Publisher: {Publisher}");
            Console.WriteLine($"Release Number: {ReleaseNumber}");
            int cacheExpirationTime = DocumentProcessor.GetCacheExpirationTime(this.GetType());
            Console.WriteLine($"Cache Expiration Time: {cacheExpirationTime} minutes");
            Console.WriteLine();
        }

        public string GetDocumentNumber()
        {
            // Implementation specific to Magazine.
            return ReleaseNumber.ToString();
        }
    }
}
