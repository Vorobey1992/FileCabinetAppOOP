using System.IO;
using System.Text.Json;

namespace FileCabinetAppOOP.Storage
{
    public class FileDocumentStorage : IDocumentStorage
    {
        private readonly string dataDirectory;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public FileDocumentStorage(string dataDirectory)
        {
            this.dataDirectory = dataDirectory;

            jsonSerializerOptions = new JsonSerializerOptions
            {
                Converters = { new DocumentConverter() }, // Добавляем наш конвертер
                WriteIndented = true // Для форматирования JSON-документов
            };
        }

        public void AddDocument(IDocument document)
        {
            // Serialize the document to a byte array without additional outer brackets
            byte[] jsonBytes = JsonSerializer.SerializeToUtf8Bytes(document, jsonSerializerOptions);

            // Формируем имя файла на основе типа документа и номера
            string fileName = $"{document.GetType().Name}_{document.GetDocumentNumber()}.json";

            // Определяем путь к файлу для сохранения документа
            string filePath = Path.Combine(dataDirectory, fileName);

            // Сохраняем JSON-строку в файл
            File.WriteAllBytes(filePath, jsonBytes);
        }

        public List<IDocument> SearchDocumentsByNumber(string documentNumber)
        {
            // Ищем все файлы в указанной директории, соответствующие формату имени
            string searchPattern = $"*_{documentNumber}.json";
            string[] matchingFiles = Directory.GetFiles(dataDirectory, searchPattern);

            List<IDocument> searchResults = new List<IDocument>();

            // Если найдены файлы, считываем документы из каждого файла и добавляем их в результат
            foreach (string filePath in matchingFiles)
            {
                // Deserialize the document using System.Text.Json.JsonSerializer
                IDocument document = JsonSerializer.Deserialize<IDocument>(File.ReadAllText(filePath), jsonSerializerOptions);

                // Check if the document number matches the provided number
                if (document.GetDocumentNumber() == documentNumber)
                {
                    searchResults.Add(document);
                }
            }

            return searchResults;
        }

        public List<IDocument> GetAllDocuments()
        {
            // Ищем все файлы с расширением .json в указанной директории
            string[] jsonFiles = Directory.GetFiles(dataDirectory, "*.json");

            List<IDocument> allDocuments = new();

            // Считываем документы из каждого файла и добавляем их в результат
            foreach (string filePath in jsonFiles)
            {
                string jsonDocument = File.ReadAllText(filePath);
                IDocument document = JsonSerializer.Deserialize<IDocument>(jsonDocument);
                allDocuments.Add(document);
            }

            return allDocuments;
        }
    }
}
