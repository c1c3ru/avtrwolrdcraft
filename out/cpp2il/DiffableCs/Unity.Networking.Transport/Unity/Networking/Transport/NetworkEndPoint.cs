namespace Unity.Networking.Transport;

public struct NetworkEndPoint
{
	private enum AddressType
	{
		Any = 0,
		Loopback = 1,
	}

	private const int rawIpv4Length = 4; //Field offset: 0x0
	private const int rawIpv6Length = 16; //Field offset: 0x0
	private const int rawDataLength = 16; //Field offset: 0x0
	private const int rawLength = 24; //Field offset: 0x0
	private static readonly bool IsLittleEndian; //Field offset: 0x0
	internal Baselib_NetworkAddress rawNetworkAddress; //Field offset: 0x0

	public string Address
	{
		 get { } //Length: 84
	}

	public static NetworkEndPoint AnyIpv4
	{
		 get { } //Length: 164
	}

	public static NetworkEndPoint AnyIpv6
	{
		 get { } //Length: 164
	}

	public NetworkFamily Family
	{
		 get { } //Length: 108
		 set { } //Length: 116
	}

	public bool IsAny
	{
		 get { } //Length: 320
	}

	public bool IsLoopback
	{
		 get { } //Length: 320
	}

	public bool IsValid
	{
		 get { } //Length: 96
	}

	public int Length
	{
		 get { } //Length: 112
	}

	public static NetworkEndPoint LoopbackIpv4
	{
		 get { } //Length: 164
	}

	public static NetworkEndPoint LoopbackIpv6
	{
		 get { } //Length: 164
	}

	public ushort Port
	{
		 get { } //Length: 16
		 set { } //Length: 16
	}

	public ushort RawPort
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private static NetworkEndPoint() { }

	private string AddressAsString() { }

	internal static FixedString128Bytes AddressToString(ref Baselib_NetworkAddress rawNetworkAddress) { }

	private static ushort ByteSwap(ushort val) { }

	private static uint ByteSwap(uint val) { }

	private bool Compare(NetworkEndPoint other) { }

	private static NetworkEndPoint CreateAddress(ushort port, AddressType type = 0, NetworkFamily family = 2) { }

	public virtual bool Equals(object other) { }

	private static NetworkFamily FromBaselibFamily(Baselib_NetworkAddress_Family family) { }

	public string get_Address() { }

	public static NetworkEndPoint get_AnyIpv4() { }

	public static NetworkEndPoint get_AnyIpv6() { }

	public NetworkFamily get_Family() { }

	public bool get_IsAny() { }

	public bool get_IsLoopback() { }

	public bool get_IsValid() { }

	public int get_Length() { }

	public static NetworkEndPoint get_LoopbackIpv4() { }

	public static NetworkEndPoint get_LoopbackIpv6() { }

	public ushort get_Port() { }

	public ushort get_RawPort() { }

	public virtual int GetHashCode() { }

	public NativeArray<Byte> GetRawAddressBytes() { }

	public static bool op_Equality(NetworkEndPoint lhs, NetworkEndPoint rhs) { }

	public static bool op_Inequality(NetworkEndPoint lhs, NetworkEndPoint rhs) { }

	public static NetworkEndPoint Parse(string address, ushort port, NetworkFamily family = 2) { }

	public void set_Family(NetworkFamily value) { }

	public void set_Port(ushort value) { }

	public void set_RawPort(ushort value) { }

	public void SetRawAddressBytes(NativeArray<Byte> bytes, NetworkFamily family = 2) { }

	private static Baselib_NetworkAddress_Family ToBaselibFamily(NetworkFamily family) { }

	public virtual string ToString() { }

	public static bool TryParse(string address, ushort port, out NetworkEndPoint endpoint, NetworkFamily family = 2) { }

	public NetworkEndPoint WithPort(ushort port) { }

}

