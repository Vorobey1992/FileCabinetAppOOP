using FileCabinetAppOOP.All_UI;
using FileCabinetAppOOP.Caching;
using FileCabinetAppOOP.Storage;
using FileCabinetAppOOP.Task1;
using FileCabinetAppOOP.Task2;
using FileCabinetAppOOP.View;

namespace FileCabinetAppOOP.Task3
{
    public static class Task3
    {
        public static void Run()
        {
            Console.WriteLine("\nTask 3 - Add ability to cache card info once read.");

            // Получаем путь к временной директории
            string tempPath = Path.GetTempPath();

            // Создаем экземпляр FileDocumentStorage и MemoryCacheManager
            var documentStorage = new FileDocumentStorage(tempPath); // Передаем путь к директории, где будут храниться файлы документов
            var cacheManager = new MemoryCacheManager();

            // Создаем экземпляр FileCabinet и передаем зависимости
            var fileCabinet = new FileCabinet(documentStorage, cacheManager);

            // Создаем экземпляр ConsoleUIAdapter и передаем FileCabinet
            var consoleUIAdapter = new ConsoleUIAdapter(fileCabinet);

            // Example of adding documents
            consoleUIAdapter.AddDocument(new Patent
            {
                Title = "Patent Title 1",
                Authors = "Author A",
                DatePublished = DateTime.Now.AddDays(-30),
                UniqueId = 1
            });

            consoleUIAdapter.AddDocument(new Book
            {
                ISBN = "1234567890",
                Title = "Book Title 1",
                Authors = "Author B",
                NumberOfPages = 200,
                Publisher = "Publisher X",
                DatePublished = DateTime.Now.AddDays(-60)
            });

            // Example of adding a localized book
            consoleUIAdapter.AddDocument(new LocalizedBook
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
            consoleUIAdapter.AddDocument(new Magazine
            {
                Title = "Magazine Title 1",
                Authors = "Author D",
                Publisher = "Publisher M",
                ReleaseNumber = 5,
                DatePublished = DateTime.Now.AddDays(-15)
            });

            // Example of using cached documents of all types
            var allCachedDocuments = cacheManager.GetAll<IDocument>();
            DocumentProcessor.PrintSearchResults(allCachedDocuments);
        }
    }
}
