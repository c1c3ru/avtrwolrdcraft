namespace Unity.Services.Wire.Protocol.Internal;

[JsonObject(ItemNullValueHandling = NullValueHandling::Ignore (1))]
internal class SubscribeResult
{
	public bool expires; //Field offset: 0x10
	public uint ttl; //Field offset: 0x14
	public bool recoverable; //Field offset: 0x18
	public string epoch; //Field offset: 0x20
	public bool recovered; //Field offset: 0x28
	public ulong offset; //Field offset: 0x30
	public bool positioned; //Field offset: 0x38
	public string data; //Field offset: 0x40
	public Publication[] publications; //Field offset: 0x48

	[Preserve]
	public SubscribeResult() { }

}

