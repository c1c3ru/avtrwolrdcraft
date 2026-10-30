namespace Unity.Networking.Transport;

public struct NetworkSettings : IDisposable
{
	private struct ParameterSlice
	{
		public int Offset; //Field offset: 0x0
		public int Size; //Field offset: 0x4

	}

	private const int k_MapInitialCapacity = 8; //Field offset: 0x0
	private NativeHashMap<Int64, ParameterSlice> m_ParameterOffsets; //Field offset: 0x0
	private NativeList<Byte> m_Parameters; //Field offset: 0x10
	private byte m_Initialized; //Field offset: 0x20

	public bool IsCreated
	{
		 get { } //Length: 96
	}

	public NetworkSettings(Allocator allocator) { }

	public void AddRawParameterStruct(ref T parameter) { }

	public override void Dispose() { }

	private bool EnsureInitializedOrError() { }

	internal static NetworkSettings FromArray(INetworkParameter[] parameters) { }

	public bool get_IsCreated() { }

	public bool TryGet(out T parameter) { }

	internal bool TryGet(Type parameterType, out INetworkParameter parameter) { }

	internal static void ValidateParameterOrError(ref T parameter) { }

}

