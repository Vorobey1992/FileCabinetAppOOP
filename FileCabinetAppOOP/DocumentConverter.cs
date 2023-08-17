using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FileCabinetAppOOP.Documents;

namespace FileCabinetAppOOP
{
    public class DocumentConverter : JsonConverter<IDocument>
    {
        public override IDocument Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Invalid JSON format.");
            }

            Type documentType = null;

            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();

                    if (propertyName == "DocumentType")
                    {
                        reader.Read();
                        string typeName = reader.GetString();
                        documentType = Type.GetType(typeName);
                    }
                    else
                    {
                        reader.Read(); // Move to the property value
                        reader.Skip(); // Skip the property value
                    }
                }
            }

            if (documentType == null || !typeof(IDocument).IsAssignableFrom(documentType))
            {
                throw new JsonException("Invalid document type.");
            }

            var document = (IDocument)JsonSerializer.Deserialize(ref reader, documentType, options);

            return document;
        }

        public override void Write(Utf8JsonWriter writer, IDocument value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
