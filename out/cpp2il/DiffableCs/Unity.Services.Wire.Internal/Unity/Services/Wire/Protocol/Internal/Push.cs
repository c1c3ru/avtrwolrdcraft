namespace Unity.Services.Wire.Protocol.Internal;

[JsonObject(ItemNullValueHandling = NullValueHandling::Ignore (1))]
internal class Push
{
	public string channel; //Field offset: 0x10
	public Publication pub; //Field offset: 0x18
	public Unsubscribe unsubscribe; //Field offset: 0x20

	[Preserve]
	public Push() { }

	internal string GetPushType() { }

	internal bool IsPub() { }

	internal bool IsUnsub() { }

}

