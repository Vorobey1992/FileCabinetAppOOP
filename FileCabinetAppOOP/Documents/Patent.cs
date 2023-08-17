
using FileCabinetAppOOP.Attributes;
using FileCabinetAppOOP.View;

namespace FileCabinetAppOOP.Task1
{
    [CacheExpiration(ExpirationTime = 5)]
    public class Patent : IDocument
    {
        public string? Title { get; set; }
        public string? Authors { get; set; }
        public DateTime DatePublished { get; set; }
        public int UniqueId { get; set; }

        public string DocumentType { get; }

        public Patent()
        {
            DocumentType = typeof(Patent).AssemblyQualifiedName ?? throw new ArgumentNullException(nameof(DocumentType));
        }

        public void PrintDocumentInfo()
        {
            Console.WriteLine($"Type: {this.GetType().Name}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Authors: {Authors}");
            Console.WriteLine($"Date Published: {DatePublished}");
            Console.WriteLine($"Unique ID: {UniqueId}");
            int cacheExpirationTime = DocumentProcessor.GetCacheExpirationTime(this.GetType());
            Console.WriteLine($"Cache Expiration Time: {cacheExpirationTime} minutes");
            Console.WriteLine();
        }
        public string GetDocumentNumber()
        {
            // Implementation specific to Patent.
            return UniqueId.ToString();
        }
    }
}
