using FileCabinetAppOOP.Task2;

namespace FileCabinetAppOOP.Task1
{
    public static class Task1
    {
        public static void Run()
        {
            Console.WriteLine("Task 1 - Ability to search for document cards by a document number.");

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

            // Example of searching for document cards by a document number
            var documentNumber = "1234567890";
            var searchResults = fileCabinet.SearchByDocumentNumber(documentNumber);
            DocumentProcessor.PrintSearchResults(searchResults); 
        }
    }
}
