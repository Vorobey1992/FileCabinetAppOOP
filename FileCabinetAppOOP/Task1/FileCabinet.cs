using FileCabinetAppOOP.Caching;
using FileCabinetAppOOP.Storage;
using FileCabinetAppOOP.View;

namespace FileCabinetAppOOP.Task1
{
    public class FileCabinet
    {
        private readonly IDocumentStorage documentStorage;
        private readonly ICacheManager cacheManager;

        public FileCabinet(IDocumentStorage documentStorage, ICacheManager cacheManager)
        {
            this.documentStorage = documentStorage;
            this.cacheManager = cacheManager;
        }

        public void AddDocument(IDocument document)
        {
            // Добавляем документ в хранилище
            documentStorage.AddDocument(document);

            // Получаем уникальный идентификатор документа (например, номер документа)
            string documentNumber = document.GetDocumentNumber();

            // Проверяем, что атрибуты для кэша больше 0
            if (DocumentProcessor.GetCacheExpirationTime(document.GetType()) > 0)
            {
                // Добавляем результаты поиска в кэш с соответствующим временем жизни
                var cacheExpirationTime = DocumentProcessor.GetCacheExpirationTime(document.GetType());
                cacheManager.Add(documentNumber, document, TimeSpan.FromMinutes(cacheExpirationTime));
            }
        }


        public List<IDocument> SearchByDocumentNumber(string documentNumber)
        {
            // Сначала проверяем, есть ли документы в кэше
            var cachedDocuments = cacheManager.Get<IDocument>(documentNumber);
            if (cachedDocuments != null)
            {
                return cachedDocuments;
            }

            // Если в кэше нет, то ищем в хранилище данных
            var searchResults = documentStorage.SearchDocumentsByNumber(documentNumber);

            return searchResults;
        }
    }
}
