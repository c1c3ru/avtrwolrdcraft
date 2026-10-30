namespace Unity.TLS.LowLevel;

[NativeHeader("External/unitytls/builds/CSharp/BindingsUnity/TLSAgent.gen.bindings.h")]
internal static class Binding
{
	internal struct unitytls_client
	{
		public uint role; //Field offset: 0x0
		public uint state; //Field offset: 0x4
		public uint handshakeState; //Field offset: 0x8
		public IntPtr ctx; //Field offset: 0x10
		public unitytls_client_config* config; //Field offset: 0x18
		public IntPtr internalCtx; //Field offset: 0x20

	}

	internal struct unitytls_client_config
	{
		public unitytls_dataRef caPEM; //Field offset: 0x0
		public unitytls_dataRef serverPEM; //Field offset: 0x10
		public unitytls_dataRef privateKeyPEM; //Field offset: 0x20
		public uint clientAuth; //Field offset: 0x30
		public uint transportProtocol; //Field offset: 0x34
		public unitytls_dataRef psk; //Field offset: 0x38
		public unitytls_dataRef pskIdentity; //Field offset: 0x48
		public IntPtr onDataCB; //Field offset: 0x58
		public IntPtr dataSendCB; //Field offset: 0x60
		public IntPtr dataReceiveCB; //Field offset: 0x68
		public IntPtr dataReceiveTimeoutCB; //Field offset: 0x70
		public IntPtr transportUserData; //Field offset: 0x78
		public IntPtr applicationUserData; //Field offset: 0x80
		public int handshakeReturnsOnStep; //Field offset: 0x88
		public int handshakeReturnsIfWouldBlock; //Field offset: 0x8C
		public uint ssl_read_timeout_ms; //Field offset: 0x90
		public Byte* hostname; //Field offset: 0x98
		public uint tracelevel; //Field offset: 0xA0
		public IntPtr logCallback; //Field offset: 0xA8
		public uint ssl_handshake_timeout_min; //Field offset: 0xB0
		public uint ssl_handshake_timeout_max; //Field offset: 0xB4
		public ushort mtu; //Field offset: 0xB8

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class unitytls_client_data_receive_callback : MulticastDelegate
	{

		public unitytls_client_data_receive_callback(object object, IntPtr method) { }

		public override int Invoke(IntPtr arg0, Byte* arg1, UIntPtr arg2, uint arg3) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class unitytls_client_data_send_callback : MulticastDelegate
	{

		public unitytls_client_data_send_callback(object object, IntPtr method) { }

		public override int Invoke(IntPtr arg0, Byte* arg1, UIntPtr arg2, uint arg3) { }

	}

	internal struct unitytls_dataRef
	{
		public Byte* dataPtr; //Field offset: 0x0
		public UIntPtr dataLen; //Field offset: 0x8

	}


	[FreeFunction(IsThreadSafe = True)]
	public static unitytls_client* unitytls_client_create(uint role, unitytls_client_config* config) { }

	[FreeFunction(IsThreadSafe = True)]
	public static void unitytls_client_destroy(unitytls_client* clientInstance) { }

	[FreeFunction(IsThreadSafe = True)]
	public static uint unitytls_client_get_handshake_state(unitytls_client* clientInstance) { }

	[FreeFunction(IsThreadSafe = True)]
	public static uint unitytls_client_get_role(unitytls_client* clientInstance) { }

	[FreeFunction(IsThreadSafe = True)]
	public static uint unitytls_client_get_state(unitytls_client* clientInstance) { }

	[FreeFunction(IsThreadSafe = True)]
	public static uint unitytls_client_handshake(unitytls_client* clientInstance) { }

	[FreeFunction(IsThreadSafe = True)]
	public static int unitytls_client_init(unitytls_client* clientInstance) { }

	[FreeFunction(IsThreadSafe = True)]
	public static void unitytls_client_init_config(unitytls_client_config* config) { }

	[FreeFunction(IsThreadSafe = True)]
	public static uint unitytls_client_read_data(unitytls_client* clientInstance, Byte* buffer, UIntPtr bufferLen, UIntPtr* bytesRead) { }

	[FreeFunction(IsThreadSafe = True)]
	public static uint unitytls_client_send_data(unitytls_client* clientInstance, Byte* data, UIntPtr dataLen) { }

}

