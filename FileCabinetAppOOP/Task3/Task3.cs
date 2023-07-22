using FileCabinetAppOOP.Task1;
using FileCabinetAppOOP.Task2;

namespace FileCabinetAppOOP.Task3
{
    public static class Task3
    {
        public static void Run()
        {
            Console.WriteLine("\nTask 3 - Add ability to cache card info once read.");

            FileCabinet fileCabinet = new();

            // Example of adding documents
            fileCabinet.AddDocument(new Patent
            {
                Title = "Patent Title 1",
                Authors = "Author A",
                DatePublished = DateTime.Now.AddDays(-30),
                UniqueId = 1
            });

            fileCabinet.AddDocument(new Book
            {
                ISBN = "1234567890",
                Title = "Book Title 1",
                Authors = "Author B",
                NumberOfPages = 200,
                Publisher = "Publisher X",
                DatePublished = DateTime.Now.AddDays(-60)
            });

            // Example of adding a localized book
            fileCabinet.AddDocument(new LocalizedBook
            {
                ISBN = "0987654321",
                Title = "Localized Book Title 1",
                Authors = "Author C",
                NumberOfPages = 300,
                OriginalPublisher = "Publisher Y",
                CountryOfLocalization = "Country Z",
                LocalPublisher = "Local Publisher Z",
                DatePublished = DateTime.Now.AddDays(-90)
            });

            // Example of adding a magazine
            fileCabinet.AddDocument(new Magazine
            {
                Title = "Magazine Title 1",
                Authors = "Author D",
                Publisher = "Publisher M",
                ReleaseNumber = 5,
                DatePublished = DateTime.Now.AddDays(-15)
            });

            // Example of caching document cards
            fileCabinet.CacheDocuments();

            // Example of using cached patent cards
            var cachedPatents = fileCabinet.GetCachedDocuments<Patent>();
            if (cachedPatents != null)
            {
                DocumentProcessor.PrintSearchResults(cachedPatents);
            }

            // Example of using cached book cards
            var cachedBooks = fileCabinet.GetCachedDocuments<Book>();
            if (cachedBooks != null)
            {
                DocumentProcessor.PrintSearchResults(cachedBooks);
            }

            // Example of using cached localized book cards
            var cachedLocalizedBooks = fileCabinet.GetCachedDocuments<LocalizedBook>();
            if (cachedLocalizedBooks != null)
            {
                DocumentProcessor.PrintSearchResults(cachedLocalizedBooks);
            }

            // Example of using cached magazine cards
            var cachedMagazines = fileCabinet.GetCachedDocuments<Magazine>();
            if (cachedMagazines != null)
            {
                DocumentProcessor.PrintSearchResults(cachedMagazines);
            }

        }
    }
}
