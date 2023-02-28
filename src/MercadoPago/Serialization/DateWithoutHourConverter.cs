using System;
using Newtonsoft.Json;

public class DateWithoutHourConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var date = (DateTime)value;
        var newLookingDate = date.ToString("yyyy-MM-dd");
        writer.WriteValue(newLookingDate);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
    }

    public override bool CanRead
    {
        get { return false; }
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(DateTime);
    }
}