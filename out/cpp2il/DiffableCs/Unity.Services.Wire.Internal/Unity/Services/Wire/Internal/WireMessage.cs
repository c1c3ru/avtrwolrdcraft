namespace Unity.Services.Wire.Internal;

internal class WireMessage
{
	public string payload; //Field offset: 0x10
	public string version; //Field offset: 0x18

	[Preserve]
	public WireMessage() { }

}

