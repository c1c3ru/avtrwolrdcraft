namespace Unity.Networking.Transport.TLS;

internal static class ManagedSecureFunctions
{
	private struct ManagedSecureFunctionsKey
	{

	}

	private const int UNITYTLS_ERR_SSL_WANT_READ = -26880; //Field offset: 0x0
	private const int UNITYTLS_ERR_SSL_WANT_WRITE = -26752; //Field offset: 0x0
	private static unitytls_client_data_send_callback s_sendCallback; //Field offset: 0x0
	private static unitytls_client_data_receive_callback s_recvCallback; //Field offset: 0x8
	private static bool IsInitialized; //Field offset: 0x10
	internal static readonly SharedStatic<FunctionPointer`1<unitytls_client_data_send_callback>> s_SendCallback; //Field offset: 0x18
	internal static readonly SharedStatic<FunctionPointer`1<unitytls_client_data_receive_callback>> s_RecvMethod; //Field offset: 0x20

	private static ManagedSecureFunctions() { }

	internal static void Initialize() { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(unitytls_client_data_receive_callback))]
	private static int SecureDataReceiveCallback(IntPtr userData, Byte* data, UIntPtr dataLen, uint status) { }

	[BurstCompile(DisableDirectCall = True)]
	[MonoPInvokeCallback(typeof(unitytls_client_data_send_callback))]
	private static int SecureDataSendCallback(IntPtr userData, Byte* data, UIntPtr dataLen, uint status) { }

}

