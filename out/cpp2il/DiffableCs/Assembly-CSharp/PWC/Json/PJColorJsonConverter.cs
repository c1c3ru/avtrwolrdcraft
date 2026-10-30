namespace PWC.Json;

public class PJColorJsonConverter : JsonConverter<Color>
{

	public PJColorJsonConverter() { }

	public virtual Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer) { }

	public virtual void WriteJson(JsonWriter writer, Color color, JsonSerializer serializer) { }

}

