namespace Unity.Networking.Transport.Relay;

internal static class RelayMessageBind
{
	private const byte k_ConnectionDataLength = 255; //Field offset: 0x0
	private const byte k_HMACLength = 32; //Field offset: 0x0
	public const int Length = 295; //Field offset: 0x0

	internal static void Write(DataStreamWriter writer, byte acceptMode, ushort nonce, Byte* connectionDataPtr, Byte* hmac) { }

}

