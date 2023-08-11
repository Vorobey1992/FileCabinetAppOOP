using System.Collections.Generic;

namespace FileCabinetAppOOP.Storage
{
    public interface IDocumentStorage
    {
        // Method to add a document to the storage.
        void AddDocument(IDocument document);

        // Method to search for documents by document number.
        List<IDocument> SearchDocumentsByNumber(string documentNumber);

        // Method to get all documents from the storage.
        List<IDocument> GetAllDocuments();
    }
}
