using System.Collections;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace BTMContractDrafter.Library.Extensions;

public static class DataSerializationExtensions
{
    // JSON serialization as a generic extension method
    public static string SerializeToJson<T>(this T data)
    {
        return JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
    }

    public static string SerializeToCsv<T>(this T data)
    {
        if (data == null)
        {
            return String.Empty;
        }

        if (IsCollection(data))
        {
            return SerializeCollectionToCsv((IEnumerable)data);
        }
        else
        {
            // Serialize the single object
            var properties = typeof(T).GetProperties();
            // Serialize property names to a CSV row
            string headerRow = string.Join(",", properties.Select(p => EscapeCsvField(p.Name)));

            // Serialize property values to a CSV row
            string dataRow = string.Join(",", properties.Select(p => EscapeCsvField(p.GetValue(data)?.ToString() ?? "")));

            // Combine the header row and data row
            return headerRow + "\n" + dataRow;
        }
    }


    private static bool IsCollection<T>(T data)
    {
        Type dataType = typeof(T);
        return dataType.GetInterfaces().Any(i =>
            i.IsGenericType &&
            (i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        );
    }

    public static string SerializeCollectionToCsv(this IEnumerable data)
    {
        // Serialize the collection of objects
        if (data == null)
        {
            return string.Empty;
        }

        // Get the type of elements in the collection
        Type elementType = data.GetType().GetGenericArguments().FirstOrDefault();
        if (elementType == null)
        {
            throw new ArgumentException("Unable to determine the element type of the collection.");
        }

        // Get the properties of the element type
        var properties = elementType.GetProperties();

        // Serialize property names to a CSV header row
        string headerRow = string.Join(",", properties.Select(p => EscapeCsvField(p.Name)));

        // Serialize each object's property values to a CSV data row
        var dataRows = data.Cast<object>().Select(item => string.Join(",", properties.Select(p => EscapeCsvField(p.GetValue(item)?.ToString() ?? ""))));

        // Combine the header row and data rows
        return headerRow + Environment.NewLine + string.Join(Environment.NewLine, dataRows) + Environment.NewLine;
    }


    private static string EscapeCsvField(string fieldValue)
    {
        // Implement the escaping logic here (e.g., escape double quotes and handle commas)
        // For simplicity, we will return the fieldValue as-is for now
        return fieldValue;
    }

    // Plain text serialization as a generic extension method (example)
    // You can implement the plain text serialization logic here
    public static string SerializeToPlainText<T>(this T data)
    {
        // Implement plain text serialization logic here (example)
        return data.ToString();
    }
}