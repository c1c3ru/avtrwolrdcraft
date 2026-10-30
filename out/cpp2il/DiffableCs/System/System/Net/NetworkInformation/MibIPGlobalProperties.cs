namespace System.Net.NetworkInformation;

internal class MibIPGlobalProperties : UnixIPGlobalProperties
{
	private static readonly Char[] wsChars; //Field offset: 0x0
	public readonly string StatisticsFile; //Field offset: 0x10
	public readonly string StatisticsFileIPv6; //Field offset: 0x18
	public readonly string TcpFile; //Field offset: 0x20
	public readonly string Tcp6File; //Field offset: 0x28
	public readonly string UdpFile; //Field offset: 0x30
	public readonly string Udp6File; //Field offset: 0x38

	private static MibIPGlobalProperties() { }

	public MibIPGlobalProperties(string procDir) { }

}

