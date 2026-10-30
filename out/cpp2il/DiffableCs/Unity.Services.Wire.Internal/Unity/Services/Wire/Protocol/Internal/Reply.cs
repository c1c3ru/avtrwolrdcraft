namespace Unity.Services.Wire.Protocol.Internal;

[JsonObject(ItemNullValueHandling = NullValueHandling::Ignore (1))]
internal class Reply
{
	public uint id; //Field offset: 0x10
	public Error error; //Field offset: 0x18
	public ConnectResult connect; //Field offset: 0x20
	public SubscribeResult subscribe; //Field offset: 0x28
	public UnsubscribeResult unsubscribe; //Field offset: 0x30
	public Push push; //Field offset: 0x38
	public PingResult ping; //Field offset: 0x40
	[JsonIgnore]
	public string originalString; //Field offset: 0x48

	[Preserve]
	public Reply() { }

	internal static Reply ConnectReply(uint id, ConnectResult result) { }

	internal static Reply ErrorReply(uint id, Error error) { }

	public static Reply FromJson(Byte[] jsonData) { }

	public static Reply FromJson(string jsonData) { }

	public bool HasError() { }

	internal static Reply PingReply(uint id) { }

	internal static Reply PushReply(Push push) { }

	internal static Reply SubscribeReply(uint id, SubscribeResult result) { }

	public Byte[] ToJson() { }

	internal static Reply UnsubscribeReply(uint id) { }

}

