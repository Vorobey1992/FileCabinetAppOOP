

namespace FileCabinetAppOOP
{
    /// <summary>
    /// Represents a document with title, authors, and date of publication.
    /// All classes implementing this interface should have a parameterless constructor.
    /// </summary>
    // In the IDocument interface, we define the method for printing document information.
    public interface IDocument
    {
        string? Title { get; set; }
        string? Authors { get; set; }
        DateTime DatePublished { get; set; }
        string DocumentType { get; }

        // Method for getting the document number as a string.
        string GetDocumentNumber();

        // Method for printing document information.
        void PrintDocumentInfo();
    }
}
