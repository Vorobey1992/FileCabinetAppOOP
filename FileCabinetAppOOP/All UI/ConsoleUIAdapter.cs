

using FileCabinetAppOOP.Storage;
using FileCabinetAppOOP.Task1;

namespace FileCabinetAppOOP.All_UI
{
    public class ConsoleUIAdapter : IDocumentStorage
    {
        private readonly FileCabinet fileCabinet;

        public ConsoleUIAdapter(FileCabinet fileCabinet)
        {
            this.fileCabinet = fileCabinet;
        }

        public void AddDocument(IDocument document)
        {
            fileCabinet.AddDocument(document);
        }

        public List<IDocument> GetAllDocuments()
        {
            // Не реализовано, так как не используется в консольном интерфейсе
            return new List<IDocument>();
        }

        public List<IDocument> SearchDocumentsByNumber(string documentNumber)
        {
            return fileCabinet.SearchByDocumentNumber(documentNumber);
        }
    }
}
