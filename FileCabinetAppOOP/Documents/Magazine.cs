using FileCabinetAppOOP.Attributes;
using FileCabinetAppOOP.Task1;
using FileCabinetAppOOP.View;

namespace FileCabinetAppOOP.Documents
{
    [CacheExpiration(ExpirationTime = 60)]
    public class Magazine : IDocument
    {
        public string? Title { get; set; }
        public string? Authors { get; set; }
        public DateTime DatePublished { get; set; }
        public string? Publisher { get; set; }
        public int ReleaseNumber { get; set; }

        public string DocumentType { get; }

        public Magazine()
        {
            DocumentType = typeof(Magazine).AssemblyQualifiedName ?? throw new ArgumentNullException(nameof(DocumentType));
        }

        public void PrintDocumentInfo()
        {
            Console.WriteLine($"Type: {GetType().Name}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Authors: {Authors}");
            Console.WriteLine($"Date Published: {DatePublished}");
            Console.WriteLine($"Publisher: {Publisher}");
            Console.WriteLine($"Release Number: {ReleaseNumber}");
            int cacheExpirationTime = DocumentProcessor.GetCacheExpirationTime(GetType());
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
