namespace MercadoPago.Tests.Serialization
{
    using System;
    using System.Globalization;
    using System.IO;
    using MercadoPago.Serialization;
    using Xunit;

    public class DefaultSerializerTest
    {
        private readonly ISerializer serializer;

        public DefaultSerializerTest()
        {
            serializer = new DefaultSerializer();
        }

        [Fact]
        public void Deserialize_ObjectFromJson_Success()
        {
            string json = File.ReadAllText("Serialization/DummySerializableObject.json");
            var dummyObject = serializer.DeserializeFromJson<DummySerializableObject>(json);

            Assert.Equal("some text", dummyObject.Text);
            Assert.Equal(1234567890, dummyObject.Number);
            Assert.Equal(
                DateTime.ParseExact(
                    "2000-01-01T18:37:42.985Z",
                    "yyyy-MM-dd'T'HH:mm:ss.fffK",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AdjustToUniversal),
                dummyObject.DateTime);
        }

        [Fact]
        public void Serialize_ObjectToJson_Success()
        {
            var dummyObject = new DummySerializableObject
            {
                Text = "some text",
                Number = 1234567890,
                DateTime = DateTime.ParseExact(
                    "2000-01-01T18:37:42.985+00:00",
                    "yyyy-MM-dd'T'HH:mm:ss.fffK",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AdjustToUniversal),
            };
            string json = serializer.SerializeToJson(dummyObject);

            Assert.Equal(File.ReadAllText("Serialization/DummySerializableObject.json"), json);
        }

        [Fact]
        public async void Serialize_ObjectToQueryString_Success()
        {
            var dummyObject = new DummySerializableObject
            {
                Text = "some text",
                Number = 1234567890,
                DateTime = DateTime.ParseExact(
                    "2000-01-01T18:37:42.985+00:00",
                    "yyyy-MM-dd'T'HH:mm:ss.fffK",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AdjustToUniversal),
            };
            string queryString = await serializer.SerializeToQueryStringAsync(dummyObject);

            Assert.Equal("text=some+text&number=1234567890&date_time=2000-01-01T18%3A37%3A42.985Z", queryString);
        }
    }
}
