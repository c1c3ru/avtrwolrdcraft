namespace Unity.Services.Lobbies.Http;

[JsonConverter(typeof(JsonObjectConverter))]
[Preserve]
public interface IDeserializable
{

	public T GetAs(DeserializationSettings deserializationSettings = null) { }

	public string GetAsString() { }

}

