using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinetAppOOP
{
    // In the IDocument interface, we define the method for printing document information.
    public interface IDocument
    {
        string? Title { get; set; }
        string? Authors { get; set; }
        DateTime DatePublished { get; set; }

        // Method for getting the document number as a string.
        string GetDocumentNumber();

        // Method for printing document information.
        void PrintDocumentInfo();
    }
}
