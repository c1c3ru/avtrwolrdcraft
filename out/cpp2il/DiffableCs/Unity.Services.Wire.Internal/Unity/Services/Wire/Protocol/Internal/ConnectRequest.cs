namespace Unity.Services.Wire.Protocol.Internal;

[JsonObject(ItemNullValueHandling = NullValueHandling::Ignore (1))]
internal class ConnectRequest
{
	public string token; //Field offset: 0x10
	public Dictionary<String, SubscribeRequest> subs; //Field offset: 0x18

	[Preserve]
	public ConnectRequest() { }

	public ConnectRequest(string token) { }

	public ConnectRequest(string token, Dictionary<String, SubscribeRequest> subscriptionRequests) { }

}

