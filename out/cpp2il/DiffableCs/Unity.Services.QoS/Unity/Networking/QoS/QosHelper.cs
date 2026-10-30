namespace Unity.Networking.QoS;

internal static class QosHelper
{
	private const ulong WSAEWOULDBLOCK = 10035; //Field offset: 0x0
	private const ulong WSAETIMEDOUT = 10060; //Field offset: 0x0
	private const ulong EAGAIN_EWOULDBLOCK_1 = 11; //Field offset: 0x0
	private const ulong EAGAIN_EWOULDBLOCK_2 = 35; //Field offset: 0x0

	internal static bool ExpiredUtc(DateTime timeUtc) { }

	internal static string Since(DateTime dt) { }

	internal static bool WouldBlock(ulong errorcode) { }

}

