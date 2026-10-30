namespace PWC.Json;

public class PJVector2JsonConverter : JsonConverter<Vector2>
{

	public PJVector2JsonConverter() { }

	public virtual Vector2 ReadJson(JsonReader reader, Type objectType, Vector2 existingValue, bool hasExistingValue, JsonSerializer serializer) { }

	public virtual void WriteJson(JsonWriter writer, Vector2 vector2, JsonSerializer serializer) { }

}

