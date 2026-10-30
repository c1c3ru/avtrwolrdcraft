namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
[DefaultMember("Item")]
public struct UnsafeText : INativeDisposable, IDisposable, IUTF8Bytes, INativeList<Byte>, IIndexable<Byte>
{
	internal UntypedUnsafeList m_UntypedListData; //Field offset: 0x0

	public override int Capacity
	{
		 get { } //Length: 84
		 set { } //Length: 92
	}

	public bool IsCreated
	{
		 get { } //Length: 76
	}

	public override bool IsEmpty
	{
		 get { } //Length: 48
	}

	public override byte Item
	{
		 get { } //Length: 68
		 set { } //Length: 80
	}

	public override int Length
	{
		 get { } //Length: 84
		 set { } //Length: 140
	}

	public UnsafeText(int capacity, AllocatorHandle allocator) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckCapacityInRange(int value, int length) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckIndexInRange(int index) { }

	public override void Clear() { }

	public override void Dispose() { }

	[NotBurstCompatible]
	public override JobHandle Dispose(JobHandle inputDeps) { }

	public override byte ElementAt(int index) { }

	public override int get_Capacity() { }

	public bool get_IsCreated() { }

	public override bool get_IsEmpty() { }

	public override byte get_Item(int index) { }

	public override int get_Length() { }

	public override Byte* GetUnsafePtr() { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, byte value) { }

	public override void set_Length(int value) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void ThrowCopyError(CopyError error, string source) { }

	[NotBurstCompatible]
	public virtual string ToString() { }

	public override bool TryResize(int newLength, NativeArrayOptions clearOptions = 1) { }

}

