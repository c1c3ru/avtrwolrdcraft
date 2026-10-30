namespace Unity.Collections;

[BurstCompatible]
[DebuggerDisplay("Length = {Length}, IsCreated = {IsCreated}")]
[NativeContainer]
public struct NativeBitArray : INativeDisposable, IDisposable
{
	[NativeDisableUnsafePtrRestriction]
	internal UnsafeBitArray m_BitArray; //Field offset: 0x0

	public bool IsCreated
	{
		 get { } //Length: 16
	}

	public int Length
	{
		 get { } //Length: 12
	}

	public NativeBitArray(int numBits, AllocatorHandle allocator, NativeArrayOptions options = 1) { }

	private NativeBitArray(int numBits, AllocatorHandle allocator, NativeArrayOptions options, int disposeSentinelStackDepth) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public NativeArray<T> AsNativeArray() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckRead() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckReadBounds() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckWrite() { }

	public void Clear() { }

	public void Copy(int dstPos, int srcPos, int numBits) { }

	public void Copy(int dstPos, ref NativeBitArray srcBitArray, int srcPos, int numBits) { }

	public int CountBits(int pos, int numBits = 1) { }

	public override void Dispose() { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public int Find(int pos, int numBits) { }

	public int Find(int pos, int count, int numBits) { }

	public bool get_IsCreated() { }

	public int get_Length() { }

	public ulong GetBits(int pos, int numBits = 1) { }

	public bool IsSet(int pos) { }

	public void Set(int pos, bool value) { }

	public void SetBits(int pos, bool value, int numBits) { }

	public void SetBits(int pos, ulong value, int numBits = 1) { }

	public bool TestAll(int pos, int numBits = 1) { }

	public bool TestAny(int pos, int numBits = 1) { }

	public bool TestNone(int pos, int numBits = 1) { }

}

