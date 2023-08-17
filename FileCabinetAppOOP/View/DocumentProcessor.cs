using FileCabinetAppOOP.Attributes;
using FileCabinetAppOOP.Documents;

namespace FileCabinetAppOOP.View
{
    public class DocumentProcessor : IDocumentsPrint, ICacheExpirationManager
    {
        public static void PrintSearchResults(List<IDocument> searchResults)
        {
            if (searchResults == null || searchResults.Count == 0)
            {
                Console.WriteLine("No matching documents found.");
                return;
            }

            Console.WriteLine("Search results:");

            foreach (var document in searchResults)
            {
                document.PrintDocumentInfo();
            }

            Console.WriteLine();
        }

        public static int GetCacheExpirationTime(Type documentType)
        {
            // Get the CacheExpirationAttribute associated with the document type
            // If the attribute is not found, return 0
            if (Attribute.GetCustomAttribute(documentType, typeof(CacheExpirationAttribute)) is not CacheExpirationAttribute cacheExpirationAttribute)
            {
                return 0;
            }
            // Return the cache expiration time from the attribute
            return cacheExpirationAttribute.ExpirationTime;
        }
    }
}
