namespace Unity.Services.Wire.Protocol.Internal;

[JsonObject(ItemNullValueHandling = NullValueHandling::Ignore (1))]
internal class Command
{
	public uint id; //Field offset: 0x10
	public ConnectRequest connect; //Field offset: 0x18
	public SubscribeRequest subscribe; //Field offset: 0x20
	public UnsubscribeRequest unsubscribe; //Field offset: 0x28
	public PingRequest ping; //Field offset: 0x30

	[Preserve]
	public Command() { }

	public Command(PingRequest request) { }

	public Command(ConnectRequest request) { }

	public Command(SubscribeRequest request) { }

	public Command(UnsubscribeRequest request) { }

	public static Command FromJSON(Byte[] data) { }

	public Byte[] GetBytes() { }

	public string GetMethod() { }

	internal bool IsPing() { }

	public string ToString() { }

}

