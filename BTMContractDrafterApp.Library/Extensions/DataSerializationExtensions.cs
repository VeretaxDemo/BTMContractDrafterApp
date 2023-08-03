using System.Collections;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace BTMContractDrafter.Library.Extensions;

public static class DataSerializationExtensions
{
    public static Type GetElementTypeOfCollection<T>(IEnumerable<T> data)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        Type dataType = typeof(T);
        Type elementType = data.GetType().GetGenericArguments().FirstOrDefault();

        if (elementType == null)
        {
            throw new ArgumentException("Unable to determine the element type of the collection.");
        }

        return elementType;
    }


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
            var elementType = data.GetType().GetGenericArguments().FirstOrDefault();
            if (elementType == null)
            {
                throw new ArgumentException("Unable to determine the element type of the collection.");
            }

            // Check if all elements in the collection have the same type
            var items = ((IEnumerable)data).Cast<object>().ToList();
            var differentTypes = items.Where(item => item.GetType() != elementType).ToList();

            if (differentTypes.Any())
            {
                Console.WriteLine("Different Types Detected:");
                foreach (var item in differentTypes)
                {
                    Console.WriteLine(item.GetType().FullName);
                }

                throw new ArgumentException("Collection contains elements of different types.");
            }

            return SerializeCollectionToCsv((IEnumerable)data, elementType);
        }
        else
        {
            // Serialize the single object
            // ... (existing code)
        }

        return String.Empty;
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

        return SerializeCollectionToCsv(data, elementType);
    }

    public static string SerializeCollectionToCsv(IEnumerable data, Type elementType)
    {
        // Serialize the collection of objects
        if (data == null)
        {
            return string.Empty;
        }

        // Get the properties of the element type
        var properties = elementType.GetProperties();

        // Serialize property names to a CSV header row
        string headerRow = GetCsvHeaderRow(elementType);

        // Serialize each object's property values to a CSV data row
        string dataRows = GetCsvDataRows(data, elementType);

        // Combine the header row and data rows with Windows CRLF line endings
        //string csvContent = headerRow + Environment.NewLine + string.Join(Environment.NewLine, dataRows);
        string csvContent = headerRow + Environment.NewLine + dataRows + Environment.NewLine;

        // Trim any trailing whitespace and return the CSV string
        string output = csvContent.TrimEnd();

        // Check if the output ends with Environment.NewLine, if not, append it
        if (!output.EndsWith(Environment.NewLine))
        {
            output += Environment.NewLine;
        }

        return output;
    }


    //private static string CreateCsvContent(IEnumerable<PropertyInfo> properties, IEnumerable data)
    //{
    //    // Serialize property names to a CSV header row
    //    string headerRow = string.Join(",", properties.Select(p => EscapeCsvField(p.Name)));

    //    // Serialize each object's property values to a CSV data row
    //    var dataRows = data.Cast<object>().Select(item => string.Join(",", properties.Select(p => EscapeCsvField(p.GetValue(item)?.ToString() ?? ""))));

    //    // Combine the header row and data rows with Windows CRLF line endings
    //    return headerRow + Environment.NewLine + string.Join(Environment.NewLine, dataRows);
    //}

    private static string GetCsvHeaderRow(Type elementType)
    {
        // Get the properties of the element type
        var properties = elementType.GetProperties();

        // Serialize property names to a CSV header row
        return string.Join(",", properties.Select(p => EscapeCsvField(p.Name)));
    }

    private static string GetCsvDataRows(IEnumerable data, Type elementType)
    {
        // Get the properties of the element type
        var properties = elementType.GetProperties();

        // Serialize each object's property values to a CSV data row
        var dataRows = data.Cast<object>().Select(item => string.Join(",", properties.Select(p => EscapeCsvField(p.GetValue(item)?.ToString() ?? ""))));

        // Combine the data rows with Windows CRLF line endings
        return string.Join(Environment.NewLine, dataRows);
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
        if (data == null)
        {
            return String.Empty;
        }

        if (data is IPlainTextSerializable plainTextData)
        {
            return plainTextData.SerializeToPlainText();
        }

        if (IsCollection(data))
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in (IEnumerable)data)
            {
                sb.AppendLine(SerializeNestedObject(item).Trim());
            }

            // Trim any trailing whitespace and return the Stringbuilder string
            string output = sb.ToString().TrimEnd();

            // Check if the output ends with Environment.NewLine, if not, append it
            while (!output.EndsWith($"{Environment.NewLine}{Environment.NewLine}"))
            {
                output += Environment.NewLine;
            }

            return output;
        }

        // If its not IPlainTextSerializable or a Collection, we serialize the top-level object using SerializeNestedObject
        return SerializeNestedObject(data);
    }

    private static string SerializeNestedObject(object data)
    {
        var properties = data.GetType().GetProperties();

        StringBuilder sb = new StringBuilder();

        foreach (var property in properties)
        {
            var value = property.GetValue(data);
            if (value is IPlainTextSerializable valuePlainTextData)
            {
                sb.AppendLine($"{property.Name}: {valuePlainTextData.SerializeToPlainText()}");
            }
            else if (IsCollection(value))
            {
                sb.AppendLine($"{property.Name}:");
                var nestedItems = (IEnumerable)value;
                foreach (var nestedItem in nestedItems)
                {
                    sb.AppendLine(SerializeNestedObject(nestedItem).Trim());
                }
            }
            else
            {
                sb.AppendLine($"{property.Name}: {value}");
            }
        }

        return sb.ToString().Trim();
    }
    //public static string SerializeToPlainText<T>(this T data)
    //{
    //    if (data == null)
    //    {
    //        return String.Empty;
    //    }

    //    if (data is IPlainTextSerializable plainTextData)
    //    {
    //        return plainTextData.SerializeToPlainText();
    //    }
    //    if (IsCollection(data))
    //    {
    //        StringBuilder sb = new StringBuilder();

    //        foreach (var item in (IEnumerable)data)
    //        {
    //            if (item is IPlainTextSerializable newPlainTextData)
    //            {
    //                sb.Append(newPlainTextData.SerializeToPlainText().Trim());
    //                sb.Append(Environment.NewLine);
    //                sb.Append(Environment.NewLine);
    //            }
    //            else
    //            {
    //                sb.Append(data.ToString());
    //            }

    //        }

    //        // Trim any trailing whitespace and return the Stringbuilder string
    //        string output = sb.ToString().TrimEnd();

    //        // Check if the output ends with Environment.NewLine, if not, append it
    //        while (!output.EndsWith($"{Environment.NewLine}{Environment.NewLine}"))
    //        {
    //            output += Environment.NewLine;
    //        }

    //        return output;
    //    }

    //    // If its not IPlainTextSerializable or a Collection, we are going to throw an Argument
    //    throw new ArgumentException($"Data type does not implement IPlainTextSerializable: {typeof(T).FullName}");
    //}
}