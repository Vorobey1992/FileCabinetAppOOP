
using System.Xml;
using FileCabinetAppOOP.Attributes;
using FileCabinetAppOOP.View;

namespace FileCabinetAppOOP.Task1
{
    [CacheExpiration(ExpirationTime = 0)]
    public class LocalizedBook : IDocument
    {
        public string? ISBN { get; set; }
        public string? Title { get; set; }
        public string? Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string? OriginalPublisher { get; set; }
        public string? CountryOfLocalization { get; set; }
        public string? LocalPublisher { get; set; }
        public DateTime DatePublished { get; set; }

        public string DocumentType { get; }

        public LocalizedBook()
        {
            DocumentType = typeof(LocalizedBook).AssemblyQualifiedName ?? throw new ArgumentNullException(nameof(DocumentType));
        }

        public void PrintDocumentInfo()
        {
            Console.WriteLine($"Type: {this.GetType().Name}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Authors: {Authors}");
            Console.WriteLine($"Number of Pages: {NumberOfPages}");
            Console.WriteLine($"Original Publisher: {OriginalPublisher}");
            Console.WriteLine($"Country of Localization: {CountryOfLocalization}");
            Console.WriteLine($"Local Publisher: {LocalPublisher}");
            Console.WriteLine($"Date Published: {DatePublished}");
            int cacheExpirationTime = DocumentProcessor.GetCacheExpirationTime(this.GetType());
            Console.WriteLine($"Cache Expiration Time: {cacheExpirationTime} minutes");
            Console.WriteLine();
        }
        public string GetDocumentNumber()
        {
            // Implementation specific to LocalizedBook.
            return ISBN ?? "";
        }
    }
}
