namespace Unity.Baselib.LowLevel;

[NativeHeader("External/baselib/builds/CSharp/BindingsUnity/Baselib_ErrorState.gen.binding.h")]
[NativeHeader("External/baselib/builds/CSharp/BindingsUnity/Baselib_ErrorCode.gen.binding.h")]
[NativeHeader("External/baselib/builds/CSharp/BindingsUnity/Baselib_DynamicLibrary.gen.binding.h")]
[NativeHeader("External/baselib/builds/CSharp/BindingsUnity/Baselib_RegisteredNetwork.gen.binding.h")]
[NativeHeader("External/baselib/builds/CSharp/BindingsUnity/Baselib_Socket.gen.binding.h")]
[NativeHeader("External/baselib/builds/CSharp/BindingsUnity/Baselib_FileIO.gen.binding.h")]
[NativeHeader("External/baselib/builds/CSharp/BindingsUnity/Baselib_Timer.gen.binding.h")]
[NativeHeader("External/baselib/builds/CSharp/BindingsUnity/Baselib_ThreadLocalStorage.gen.binding.h")]
[NativeHeader("External/baselib/builds/CSharp/BindingsUnity/Baselib_Memory.gen.binding.h")]
[NativeHeader("External/baselib/builds/CSharp/BindingsUnity/Baselib_Thread.gen.binding.h")]
[NativeHeader("External/baselib/builds/CSharp/BindingsUnity/Baselib_NetworkAddress.gen.binding.h")]
[NativeHeader("External/baselib/builds/CSharp/BindingsUnity/Baselib_SourceLocation.gen.binding.h")]
internal static class Binding
{
	internal struct Baselib_DynamicLibrary_Handle
	{
		public IntPtr handle; //Field offset: 0x0

	}

	internal enum Baselib_ErrorCode
	{
		Success = 0,
		OutOfMemory = 16777216,
		OutOfSystemResources = 16777217,
		InvalidAddressRange = 16777218,
		InvalidArgument = 16777219,
		InvalidBufferSize = 16777220,
		InvalidState = 16777221,
		NotSupported = 16777222,
		Timeout = 16777223,
		UnsupportedAlignment = 33554432,
		InvalidPageSize = 33554433,
		InvalidPageCount = 33554434,
		UnsupportedPageState = 33554435,
		ThreadCannotJoinSelf = 50331648,
		NetworkInitializationError = 67108864,
		AddressInUse = 67108865,
		AddressUnreachable = 67108866,
		AddressFamilyNotSupported = 67108867,
		Disconnected = 67108868,
		InvalidPathname = 83886080,
		RequestedAccessIsNotAllowed = 83886081,
		IOError = 83886082,
		FailedToOpenDynamicLibrary = 100663296,
		FunctionNotFound = 100663297,
		UnexpectedError = -1,
	}

	internal struct Baselib_ErrorState
	{
		public Baselib_SourceLocation sourceLocation; //Field offset: 0x0
		public ulong nativeErrorCode; //Field offset: 0x18
		public ulong extraInformation; //Field offset: 0x20
		public Baselib_ErrorCode code; //Field offset: 0x28
		public Baselib_ErrorState_NativeErrorCodeType nativeErrorCodeType; //Field offset: 0x2C
		public Baselib_ErrorState_ExtraInformationType extraInformationType; //Field offset: 0x2D

	}

	internal enum Baselib_ErrorState_ExtraInformationType
	{
		None = 0,
		StaticString = 1,
		GenerationCounter = 2,
	}

	internal enum Baselib_ErrorState_NativeErrorCodeType
	{
		None = 0,
		PlatformDefined = 1,
	}

	internal struct Baselib_FileIO_AsyncFile
	{
		public IntPtr handle; //Field offset: 0x0

	}

	internal struct Baselib_FileIO_EventQueue
	{
		public IntPtr handle; //Field offset: 0x0

	}

	internal struct Baselib_FileIO_SyncFile
	{
		public IntPtr handle; //Field offset: 0x0

	}

	internal struct Baselib_Memory_PageAllocation
	{
		public IntPtr ptr; //Field offset: 0x0
		public ulong pageSize; //Field offset: 0x8
		public ulong pageCount; //Field offset: 0x10

	}

	internal struct Baselib_Memory_PageSizeInfo
	{
		public ulong defaultPageSize; //Field offset: 0x0
		public ulong pageSizes0; //Field offset: 0x8
		public ulong pageSizes1; //Field offset: 0x10
		public ulong pageSizes2; //Field offset: 0x18
		public ulong pageSizes3; //Field offset: 0x20
		public ulong pageSizes4; //Field offset: 0x28
		public ulong pageSizes5; //Field offset: 0x30
		public ulong pageSizesLen; //Field offset: 0x38

	}

	internal enum Baselib_Memory_PageState
	{
		Reserved = 0,
		NoAccess = 1,
		ReadOnly = 2,
		ReadWrite = 4,
		ReadOnly_Executable = 18,
		ReadWrite_Executable = 20,
	}

	internal struct Baselib_NetworkAddress
	{
		public byte data0; //Field offset: 0x0
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv4_0; //Field offset: 0x0
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_0; //Field offset: 0x0
		public byte data1; //Field offset: 0x1
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv4_1; //Field offset: 0x1
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_1; //Field offset: 0x1
		public byte data2; //Field offset: 0x2
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv4_2; //Field offset: 0x2
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_2; //Field offset: 0x2
		public byte data3; //Field offset: 0x3
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv4_3; //Field offset: 0x3
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_3; //Field offset: 0x3
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_4; //Field offset: 0x4
		public byte data4; //Field offset: 0x4
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_5; //Field offset: 0x5
		public byte data5; //Field offset: 0x5
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_6; //Field offset: 0x6
		public byte data6; //Field offset: 0x6
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_7; //Field offset: 0x7
		public byte data7; //Field offset: 0x7
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_8; //Field offset: 0x8
		public byte data8; //Field offset: 0x8
		public byte data9; //Field offset: 0x9
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_9; //Field offset: 0x9
		public byte data10; //Field offset: 0xA
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_10; //Field offset: 0xA
		public byte data11; //Field offset: 0xB
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_11; //Field offset: 0xB
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_12; //Field offset: 0xC
		public byte data12; //Field offset: 0xC
		public byte data13; //Field offset: 0xD
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_13; //Field offset: 0xD
		public byte data14; //Field offset: 0xE
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_14; //Field offset: 0xE
		[Ignore(DoesNotContributeToSize = True)]
		public byte ipv6_15; //Field offset: 0xF
		public byte data15; //Field offset: 0xF
		public byte port0; //Field offset: 0x10
		public byte port1; //Field offset: 0x11
		public byte family; //Field offset: 0x12
		public byte _padding; //Field offset: 0x13
		public uint ipv6_scope_id; //Field offset: 0x14

	}

	internal enum Baselib_NetworkAddress_AddressReuse
	{
		DoNotAllow = 0,
		Allow = 1,
	}

	internal enum Baselib_NetworkAddress_Family
	{
		Invalid = 0,
		IPv4 = 1,
		IPv6 = 2,
	}

	internal struct Baselib_RegisteredNetwork_Buffer
	{
		public IntPtr id; //Field offset: 0x0
		public Baselib_Memory_PageAllocation allocation; //Field offset: 0x8

	}

	internal struct Baselib_RegisteredNetwork_BufferSlice
	{
		public IntPtr id; //Field offset: 0x0
		public IntPtr data; //Field offset: 0x8
		public uint size; //Field offset: 0x10
		public uint offset; //Field offset: 0x14

	}

	internal struct Baselib_RegisteredNetwork_CompletionResult
	{
		public Baselib_RegisteredNetwork_CompletionStatus status; //Field offset: 0x0
		public uint bytesTransferred; //Field offset: 0x4
		public IntPtr requestUserdata; //Field offset: 0x8

	}

	internal enum Baselib_RegisteredNetwork_CompletionStatus
	{
		Failed = 0,
		Success = 1,
	}

	internal struct Baselib_RegisteredNetwork_Endpoint
	{
		public Baselib_RegisteredNetwork_BufferSlice slice; //Field offset: 0x0

	}

	internal enum Baselib_RegisteredNetwork_ProcessStatus
	{
		NonePendingImmediately = 0,
		Done = 0,
		Pending = 1,
	}

	internal struct Baselib_RegisteredNetwork_Request
	{
		public Baselib_RegisteredNetwork_BufferSlice payload; //Field offset: 0x0
		public Baselib_RegisteredNetwork_Endpoint remoteEndpoint; //Field offset: 0x18
		public IntPtr requestUserdata; //Field offset: 0x30

	}

	internal struct Baselib_RegisteredNetwork_Socket_UDP
	{
		public IntPtr handle; //Field offset: 0x0

	}

	internal struct Baselib_Socket_Handle
	{
		public IntPtr handle; //Field offset: 0x0

	}

	internal struct Baselib_Socket_Message
	{
		public Baselib_NetworkAddress* address; //Field offset: 0x0
		public IntPtr data; //Field offset: 0x8
		public uint dataLen; //Field offset: 0x10

	}

	internal enum Baselib_Socket_Protocol
	{
		UDP = 1,
		TCP = 2,
	}

	internal struct Baselib_SourceLocation
	{
		public Byte* file; //Field offset: 0x0
		public Byte* function; //Field offset: 0x8
		public uint lineNumber; //Field offset: 0x10

	}

	public static readonly UIntPtr Baselib_Memory_MaxAlignment; //Field offset: 0x0
	public static readonly UIntPtr Baselib_Memory_MinGuaranteedAlignment; //Field offset: 0x8
	public static readonly IntPtr Baselib_RegisteredNetwork_Buffer_Id_Invalid; //Field offset: 0x10
	public static readonly IntPtr Baselib_Thread_InvalidId; //Field offset: 0x18
	public static readonly UIntPtr Baselib_Thread_MaxThreadNameLength; //Field offset: 0x20
	public static readonly Baselib_Memory_PageAllocation Baselib_Memory_PageAllocation_Invalid; //Field offset: 0x28
	public static readonly Baselib_RegisteredNetwork_Socket_UDP Baselib_RegisteredNetwork_Socket_UDP_Invalid; //Field offset: 0x40
	public static readonly Baselib_Socket_Handle Baselib_Socket_Handle_Invalid; //Field offset: 0x48
	public static readonly Baselib_DynamicLibrary_Handle Baselib_DynamicLibrary_Handle_Invalid; //Field offset: 0x50
	public static readonly Baselib_FileIO_EventQueue Baselib_FileIO_EventQueue_Invalid; //Field offset: 0x58
	public static readonly Baselib_FileIO_AsyncFile Baselib_FileIO_AsyncFile_Invalid; //Field offset: 0x60
	public static readonly Baselib_FileIO_SyncFile Baselib_FileIO_SyncFile_Invalid; //Field offset: 0x68

	private static Binding() { }

	[FreeFunction(IsThreadSafe = True)]
	public static Baselib_Memory_PageAllocation Baselib_Memory_AllocatePages(ulong pageSize, ulong pageCount, ulong alignmentInMultipleOfPageSize, Baselib_Memory_PageState pageState, Baselib_ErrorState* errorState) { }

	private static void Baselib_Memory_AllocatePages_Injected(ulong pageSize, ulong pageCount, ulong alignmentInMultipleOfPageSize, Baselib_Memory_PageState pageState, Baselib_ErrorState* errorState, out Baselib_Memory_PageAllocation ret) { }

	[FreeFunction(IsThreadSafe = True)]
	public static void Baselib_Memory_GetPageSizeInfo(Baselib_Memory_PageSizeInfo* outPagesSizeInfo) { }

	[FreeFunction(IsThreadSafe = True)]
	public static void Baselib_Memory_ReleasePages(Baselib_Memory_PageAllocation pageAllocation, Baselib_ErrorState* errorState) { }

	private static void Baselib_Memory_ReleasePages_Injected(ref Baselib_Memory_PageAllocation pageAllocation, Baselib_ErrorState* errorState) { }

	[FreeFunction(IsThreadSafe = True)]
	public static void Baselib_NetworkAddress_Encode(Baselib_NetworkAddress* dstAddress, Baselib_NetworkAddress_Family family, Byte* ip, ushort port, Baselib_ErrorState* errorState) { }

	[FreeFunction(IsThreadSafe = True)]
	public static void Baselib_RegisteredNetwork_Buffer_Deregister(Baselib_RegisteredNetwork_Buffer buffer) { }

	private static void Baselib_RegisteredNetwork_Buffer_Deregister_Injected(ref Baselib_RegisteredNetwork_Buffer buffer) { }

	[FreeFunction(IsThreadSafe = True)]
	public static Baselib_RegisteredNetwork_Buffer Baselib_RegisteredNetwork_Buffer_Register(Baselib_Memory_PageAllocation pageAllocation, Baselib_ErrorState* errorState) { }

	private static void Baselib_RegisteredNetwork_Buffer_Register_Injected(ref Baselib_Memory_PageAllocation pageAllocation, Baselib_ErrorState* errorState, out Baselib_RegisteredNetwork_Buffer ret) { }

	[FreeFunction(IsThreadSafe = True)]
	public static Baselib_RegisteredNetwork_Endpoint Baselib_RegisteredNetwork_Endpoint_Create(Baselib_NetworkAddress* srcAddress, Baselib_RegisteredNetwork_BufferSlice dstSlice, Baselib_ErrorState* errorState) { }

	private static void Baselib_RegisteredNetwork_Endpoint_Create_Injected(Baselib_NetworkAddress* srcAddress, ref Baselib_RegisteredNetwork_BufferSlice dstSlice, Baselib_ErrorState* errorState, out Baselib_RegisteredNetwork_Endpoint ret) { }

	[FreeFunction(IsThreadSafe = True)]
	public static void Baselib_RegisteredNetwork_Endpoint_GetNetworkAddress(Baselib_RegisteredNetwork_Endpoint endpoint, Baselib_NetworkAddress* dstAddress, Baselib_ErrorState* errorState) { }

	private static void Baselib_RegisteredNetwork_Endpoint_GetNetworkAddress_Injected(ref Baselib_RegisteredNetwork_Endpoint endpoint, Baselib_NetworkAddress* dstAddress, Baselib_ErrorState* errorState) { }

	[FreeFunction(IsThreadSafe = True)]
	public static void Baselib_RegisteredNetwork_Socket_UDP_Close(Baselib_RegisteredNetwork_Socket_UDP socket) { }

	private static void Baselib_RegisteredNetwork_Socket_UDP_Close_Injected(ref Baselib_RegisteredNetwork_Socket_UDP socket) { }

	[FreeFunction(IsThreadSafe = True)]
	public static Baselib_RegisteredNetwork_Socket_UDP Baselib_RegisteredNetwork_Socket_UDP_Create(Baselib_NetworkAddress* bindAddress, Baselib_NetworkAddress_AddressReuse endpointReuse, uint sendQueueSize, uint recvQueueSize, Baselib_ErrorState* errorState) { }

	private static void Baselib_RegisteredNetwork_Socket_UDP_Create_Injected(Baselib_NetworkAddress* bindAddress, Baselib_NetworkAddress_AddressReuse endpointReuse, uint sendQueueSize, uint recvQueueSize, Baselib_ErrorState* errorState, out Baselib_RegisteredNetwork_Socket_UDP ret) { }

	[FreeFunction(IsThreadSafe = True)]
	public static uint Baselib_RegisteredNetwork_Socket_UDP_DequeueRecv(Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_RegisteredNetwork_CompletionResult* results, uint resultsCount, Baselib_ErrorState* errorState) { }

	private static uint Baselib_RegisteredNetwork_Socket_UDP_DequeueRecv_Injected(ref Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_RegisteredNetwork_CompletionResult* results, uint resultsCount, Baselib_ErrorState* errorState) { }

	[FreeFunction(IsThreadSafe = True)]
	public static uint Baselib_RegisteredNetwork_Socket_UDP_DequeueSend(Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_RegisteredNetwork_CompletionResult* results, uint resultsCount, Baselib_ErrorState* errorState) { }

	private static uint Baselib_RegisteredNetwork_Socket_UDP_DequeueSend_Injected(ref Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_RegisteredNetwork_CompletionResult* results, uint resultsCount, Baselib_ErrorState* errorState) { }

	[FreeFunction(IsThreadSafe = True)]
	public static void Baselib_RegisteredNetwork_Socket_UDP_GetNetworkAddress(Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_NetworkAddress* dstAddress, Baselib_ErrorState* errorState) { }

	private static void Baselib_RegisteredNetwork_Socket_UDP_GetNetworkAddress_Injected(ref Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_NetworkAddress* dstAddress, Baselib_ErrorState* errorState) { }

	[FreeFunction(IsThreadSafe = True)]
	public static Baselib_RegisteredNetwork_ProcessStatus Baselib_RegisteredNetwork_Socket_UDP_ProcessRecv(Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_ErrorState* errorState) { }

	private static Baselib_RegisteredNetwork_ProcessStatus Baselib_RegisteredNetwork_Socket_UDP_ProcessRecv_Injected(ref Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_ErrorState* errorState) { }

	[FreeFunction(IsThreadSafe = True)]
	public static Baselib_RegisteredNetwork_ProcessStatus Baselib_RegisteredNetwork_Socket_UDP_ProcessSend(Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_ErrorState* errorState) { }

	private static Baselib_RegisteredNetwork_ProcessStatus Baselib_RegisteredNetwork_Socket_UDP_ProcessSend_Injected(ref Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_ErrorState* errorState) { }

	[FreeFunction(IsThreadSafe = True)]
	public static uint Baselib_RegisteredNetwork_Socket_UDP_ScheduleRecv(Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_RegisteredNetwork_Request* requests, uint requestsCount, Baselib_ErrorState* errorState) { }

	private static uint Baselib_RegisteredNetwork_Socket_UDP_ScheduleRecv_Injected(ref Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_RegisteredNetwork_Request* requests, uint requestsCount, Baselib_ErrorState* errorState) { }

	[FreeFunction(IsThreadSafe = True)]
	public static uint Baselib_RegisteredNetwork_Socket_UDP_ScheduleSend(Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_RegisteredNetwork_Request* requests, uint requestsCount, Baselib_ErrorState* errorState) { }

	private static uint Baselib_RegisteredNetwork_Socket_UDP_ScheduleSend_Injected(ref Baselib_RegisteredNetwork_Socket_UDP socket, Baselib_RegisteredNetwork_Request* requests, uint requestsCount, Baselib_ErrorState* errorState) { }

	[FreeFunction(IsThreadSafe = True)]
	public static void Baselib_Socket_Close(Baselib_Socket_Handle socket) { }

	private static void Baselib_Socket_Close_Injected(ref Baselib_Socket_Handle socket) { }

	[FreeFunction(IsThreadSafe = True)]
	public static Baselib_Socket_Handle Baselib_Socket_Create(Baselib_NetworkAddress_Family family, Baselib_Socket_Protocol protocol, Baselib_ErrorState* errorState) { }

	private static void Baselib_Socket_Create_Injected(Baselib_NetworkAddress_Family family, Baselib_Socket_Protocol protocol, Baselib_ErrorState* errorState, out Baselib_Socket_Handle ret) { }

	[FreeFunction(IsThreadSafe = True)]
	public static uint Baselib_Socket_UDP_Recv(Baselib_Socket_Handle socket, Baselib_Socket_Message* messages, uint messagesCount, Baselib_ErrorState* errorState) { }

	private static uint Baselib_Socket_UDP_Recv_Injected(ref Baselib_Socket_Handle socket, Baselib_Socket_Message* messages, uint messagesCount, Baselib_ErrorState* errorState) { }

	[FreeFunction(IsThreadSafe = True)]
	public static uint Baselib_Socket_UDP_Send(Baselib_Socket_Handle socket, Baselib_Socket_Message* messages, uint messagesCount, Baselib_ErrorState* errorState) { }

	private static uint Baselib_Socket_UDP_Send_Injected(ref Baselib_Socket_Handle socket, Baselib_Socket_Message* messages, uint messagesCount, Baselib_ErrorState* errorState) { }

}

