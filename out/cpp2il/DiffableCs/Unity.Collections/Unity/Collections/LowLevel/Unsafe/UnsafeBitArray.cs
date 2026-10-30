namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
[DebuggerDisplay("Length = {Length}, IsCreated = {IsCreated}")]
[DebuggerTypeProxy(typeof(UnsafeBitArrayDebugView))]
public struct UnsafeBitArray : INativeDisposable, IDisposable
{
	[NativeDisableUnsafePtrRestriction]
	public UInt64* Ptr; //Field offset: 0x0
	public int Length; //Field offset: 0x8
	public AllocatorHandle Allocator; //Field offset: 0xC

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public UnsafeBitArray(Void* ptr, int sizeInBytes, AllocatorHandle allocator = null) { }

	public UnsafeBitArray(int numBits, AllocatorHandle allocator, NativeArrayOptions options = 1) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckArgs(int pos, int numBits) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckArgsCopy(ref UnsafeBitArray dstBitArray, int dstPos, ref UnsafeBitArray srcBitArray, int srcPos, int numBits) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckArgsPosCount(int begin, int count, int numBits) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckArgsUlong(int pos, int numBits) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckSizeMultipleOf8(int sizeInBytes) { }

	public void Clear() { }

	public void Copy(int dstPos, int srcPos, int numBits) { }

	public void Copy(int dstPos, ref UnsafeBitArray srcBitArray, int srcPos, int numBits) { }

	internal void CopyUlong(int dstPos, ref UnsafeBitArray srcBitArray, int srcPos, int numBits) { }

	public int CountBits(int pos, int numBits = 1) { }

	public override void Dispose() { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public int Find(int pos, int count, int numBits) { }

	public int Find(int pos, int numBits) { }

	public bool get_IsCreated() { }

	public ulong GetBits(int pos, int numBits = 1) { }

	public bool IsSet(int pos) { }

	public void Set(int pos, bool value) { }

	public void SetBits(int pos, ulong value, int numBits = 1) { }

	public void SetBits(int pos, bool value, int numBits) { }

	public bool TestAll(int pos, int numBits = 1) { }

	public bool TestAny(int pos, int numBits = 1) { }

	public bool TestNone(int pos, int numBits = 1) { }

}

