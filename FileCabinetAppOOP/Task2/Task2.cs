using FileCabinetAppOOP.All_UI;
using FileCabinetAppOOP.Caching;
using FileCabinetAppOOP.Storage;
using FileCabinetAppOOP.Task1;
using FileCabinetAppOOP.View;

namespace FileCabinetAppOOP.Task2
{
    public static class Task2
    {
        public static void Run()
        {
            Console.WriteLine("\nTask 2 - Add support for a new type of document - Magazine.");

            // Получаем путь к временной директории
            string tempPath = Path.GetTempPath();

            // Создаем экземпляр FileDocumentStorage и MemoryCacheManager
            var documentStorage = new FileDocumentStorage(tempPath); // Передаем путь к директории, где будут храниться файлы документов
            var cacheManager = new MemoryCacheManager();

            // Создаем экземпляр FileCabinet и передаем зависимости
            var fileCabinet = new FileCabinet(documentStorage, cacheManager);

            // Создаем экземпляр ConsoleUIAdapter и передаем FileCabinet
            var consoleUIAdapter = new ConsoleUIAdapter(fileCabinet);

            // Пример добавления журнала
            consoleUIAdapter.AddDocument(new Magazine
            {
                Title = "Magazine Title 1",
                Authors = "Author D",
                Publisher = "Publisher M",
                ReleaseNumber = 5,
                DatePublished = DateTime.Now.AddDays(-15)
            });

            // Пример поиска карточек по номеру документа для журналов
            var documentNumber = "5";
            var searchResults = consoleUIAdapter.SearchDocumentsByNumber(documentNumber);
            DocumentProcessor.PrintSearchResults(searchResults);
        }
    }

}
