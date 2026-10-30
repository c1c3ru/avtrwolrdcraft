namespace Unity.Networking.QoS;

internal struct NetworkEndPoint
{
	internal Baselib_NetworkAddress rawNetworkAddress; //Field offset: 0x0

	internal string Address
	{
		internal get { } //Length: 4
	}

	private NetworkFamily Family
	{
		private get { } //Length: 32
	}

	private bool IsValid
	{
		private get { } //Length: 20
	}

	private ushort Port
	{
		private get { } //Length: 16
	}

	private string AddressAsString() { }

	private static NetworkFamily FromBaselibFamily(Baselib_NetworkAddress_Family family) { }

	internal string get_Address() { }

	private NetworkFamily get_Family() { }

	private bool get_IsValid() { }

	private ushort get_Port() { }

	private static Baselib_NetworkAddress_Family ToBaselibFamily(NetworkFamily family) { }

	internal static bool TryParse(string address, ushort port, out NetworkEndPoint endpoint, NetworkFamily family = 2) { }

}

