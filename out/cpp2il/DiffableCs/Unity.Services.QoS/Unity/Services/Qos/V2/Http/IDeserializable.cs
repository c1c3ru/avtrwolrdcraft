namespace Unity.Services.Qos.V2.Http;

[JsonConverter(typeof(JsonObjectConverter))]
[Preserve]
internal interface IDeserializable
{

	public T GetAs(DeserializationSettings deserializationSettings = null) { }

	public string GetAsString() { }

}

