using System;
using Newtonsoft.Json;

/// <summary>
/// A write-only <see cref="JsonConverter"/> that serializes <see cref="DateTime"/> values
/// as date-only strings in the <c>yyyy-MM-dd</c> format, omitting the time component.
/// </summary>
/// <remarks>
/// Apply this converter via <c>[JsonConverter(typeof(DateWithoutHourConverter))]</c> on
/// properties where the MercadoPago API expects a date without a time portion (e.g., expiration
/// dates). Deserialization is not supported; <see cref="CanRead"/> returns <c>false</c>, so
/// Newtonsoft.Json will use its default <see cref="DateTime"/> parsing on read.
/// </remarks>
public class DateWithoutHourConverter : JsonConverter
{
    /// <summary>
    /// Serializes the <see cref="DateTime"/> <paramref name="value"/> as a <c>yyyy-MM-dd</c> string.
    /// </summary>
    /// <param name="writer">The <see cref="JsonWriter"/> to write the formatted date to.</param>
    /// <param name="value">The <see cref="DateTime"/> value to serialize.</param>
    /// <param name="serializer">The calling <see cref="JsonSerializer"/> (unused).</param>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var date = (DateTime)value;
        var newLookingDate = date.ToString("yyyy-MM-dd");
        writer.WriteValue(newLookingDate);
    }

    /// <summary>
    /// Not implemented. This converter is write-only; <see cref="CanRead"/> returns <c>false</c>,
    /// so Newtonsoft.Json never calls this method during deserialization.
    /// </summary>
    /// <exception cref="NotImplementedException">Always thrown if called directly.</exception>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
    }

    /// <summary>
    /// Gets a value indicating whether this converter can read (deserialize) JSON.
    /// Always returns <c>false</c>, deferring deserialization to the default handler.
    /// </summary>
    public override bool CanRead
    {
        get { return false; }
    }

    /// <summary>
    /// Determines whether this converter can handle the specified type.
    /// Returns <c>true</c> only for <see cref="DateTime"/>.
    /// </summary>
    /// <param name="objectType">The type to check.</param>
    /// <returns><c>true</c> if <paramref name="objectType"/> is <see cref="DateTime"/>; otherwise, <c>false</c>.</returns>
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(DateTime);
    }
}