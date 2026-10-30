namespace Unity.Services.Relay.Http;

[JsonConverter(typeof(JsonObjectConverter))]
[Preserve]
internal interface IDeserializable
{

	public T GetAs(DeserializationSettings deserializationSettings = null) { }

	public string GetAsString() { }

}

