using FileCabinetAppOOP.All_UI;
using FileCabinetAppOOP.Task2;
using FileCabinetAppOOP.Storage;
using FileCabinetAppOOP.Caching;
using FileCabinetAppOOP.View;

namespace FileCabinetAppOOP.Task1
{
    public static class Task1
    {
        public static void Run()
        {
            Console.WriteLine("Task 1 - Ability to search for document cards by a document number.");

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
                Title = "Patent Title 123",
                Authors = "Author ABC",
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

            // Example of searching for document cards by a document number
            var documentNumber = "1234567890";
            var searchResults = consoleUIAdapter.SearchDocumentsByNumber(documentNumber);
            DocumentProcessor.PrintSearchResults(searchResults); 
        }
    }
}
