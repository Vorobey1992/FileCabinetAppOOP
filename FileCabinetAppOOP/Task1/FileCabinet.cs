using System;
using System.Collections.Generic;
using System.Linq;

namespace FileCabinetAppOOP.Task1
{
    public class FileCabinet
    {
        public List<IDocument> Documents { get; set; }

        // Task 3
        private readonly Dictionary<Type, List<IDocument>> cachedDocuments = new();

        public FileCabinet()
        {
            Documents = new List<IDocument>();
        }

        // Метод для добавления документов различных типов
        public void AddDocument(IDocument document)
        {
            Documents.Add(document);
        }

        // Метод для поиска карточек по номеру документа
        public List<IDocument> SearchByDocumentNumber(string documentNumber)
        {
            return Documents.Where(document => document.GetDocumentNumber() == documentNumber).ToList();
        }

        // Task 3
        public void CacheDocuments()
        {
            var documentTypes = GetDocumentTypesWithCacheAttribute();

            foreach (var documentType in documentTypes)
            {
                var documents = GetDocumentsByType(documentType);
                if (documents != null)
                {
                    if (!cachedDocuments.ContainsKey(documentType))
                    {
                        cachedDocuments.Add(documentType, documents);
                    }
                    else
                    {
                        cachedDocuments[documentType] = documents;
                    }
                }
            }
        }

        private List<IDocument> GetDocumentsByType(Type documentType)
        {
            return Documents.Where(document => document.GetType() == documentType).ToList();
        }

        private static IEnumerable<Type> GetDocumentTypesWithCacheAttribute()
        {
            var documentTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IDocument).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);

            var typesWithCacheAttribute = new List<Type>();
            foreach (var documentType in documentTypes)
            {
                var attributes = documentType.GetCustomAttributes(typeof(CacheExpirationAttribute), true);
                if (attributes.Length > 0)
                {
                    typesWithCacheAttribute.Add(documentType);
                }
            }

            return typesWithCacheAttribute;
        }

        public List<IDocument>? GetCachedDocuments<T>()
        {
            if (cachedDocuments.ContainsKey(typeof(T)))
            {
                return cachedDocuments[typeof(T)];
            }
            return null;
        }
    }
}
