using System.Text.Json;
using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.Infrastructure.Serialization;

internal sealed class DecimalJsonConverter : JsonConverter<decimal>
{
    private const int Multiplier = 1000;

    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetDecimal() / Multiplier;

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options) =>
        writer.WriteNumberValue((long)(value * Multiplier));
}