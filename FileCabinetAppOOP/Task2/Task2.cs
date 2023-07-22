using FileCabinetAppOOP.Task1;

namespace FileCabinetAppOOP.Task2
{
    public static class Task2
    {
        public static void Run()
        {
            Console.WriteLine("\nTask 2 - Add support for a new type of document - Magazine.");

            FileCabinet fileCabinet = new();

            // Пример добавления журнала
            fileCabinet.AddDocument(new Magazine
            {
                Title = "Magazine Title 1",
                Authors = "Author D",
                Publisher = "Publisher M",
                ReleaseNumber = 5,
                DatePublished = DateTime.Now.AddDays(-15)
            });

            // Пример поиска карточек по номеру документа для журналов
            var documentNumber = "5";
            var searchResults = fileCabinet.SearchByDocumentNumber(documentNumber);
            DocumentProcessor.PrintSearchResults(searchResults);
        }
    }

}
