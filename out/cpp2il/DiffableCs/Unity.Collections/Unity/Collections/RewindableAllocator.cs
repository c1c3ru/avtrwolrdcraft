namespace Unity.Collections;

[BurstCompile]
public struct RewindableAllocator : IAllocator, IDisposable
{
	[BurstCompatible]
	public struct MemoryBlock : IDisposable
	{
		public const int kMaximumAlignment = 16384; //Field offset: 0x0
		public Byte* m_pointer; //Field offset: 0x0
		public long m_bytes; //Field offset: 0x8
		public long m_current; //Field offset: 0x10
		public long m_allocations; //Field offset: 0x18

		public MemoryBlock(long bytes) { }

		public bool Contains(IntPtr ptr) { }

		public override void Dispose() { }

		public void Rewind() { }

		public int TryAllocate(ref Block block) { }

	}

	public static class Try_000006E8$BurstDirectCall
	{
		private static IntPtr Pointer; //Field offset: 0x0
		private static IntPtr DeferredCompilation; //Field offset: 0x8

		private static Try_000006E8$BurstDirectCall() { }

		public static void Constructor() { }

		private static IntPtr GetFunctionPointer() { }

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

		public static void Initialize() { }

		public static int Invoke(IntPtr state, ref Block block) { }

	}

	public sealed class Try_000006E8$PostfixBurstDelegate : MulticastDelegate
	{

		public Try_000006E8$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

		public override IAsyncResult BeginInvoke(IntPtr state, ref Block block, AsyncCallback unnamed_param_2, object unnamed_param_3) { }

		public override int EndInvoke(IAsyncResult unnamed_param_0) { }

		public override int Invoke(IntPtr state, ref Block block) { }

	}

	private Spinner m_spinner; //Field offset: 0x0
	private AllocatorHandle m_handle; //Field offset: 0x4
	private UnmanagedArray<MemoryBlock> m_block; //Field offset: 0x8
	private int m_best; //Field offset: 0x18
	private int m_last; //Field offset: 0x1C
	private int m_used; //Field offset: 0x20
	private bool m_enableBlockFree; //Field offset: 0x24

	public int BlocksAllocated
	{
		 get { } //Length: 12
	}

	public bool EnableBlockFree
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	[NotBurstCompatible]
	public override TryFunction Function
	{
		 get { } //Length: 112
	}

	public override AllocatorHandle Handle
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int InitialSizeInBytes
	{
		 get { } //Length: 84
	}

	public override bool IsCustomAllocator
	{
		 get { } //Length: 12
	}

	public override Allocator ToAllocator
	{
		 get { } //Length: 12
	}

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public NativeArray<T> AllocateNativeArray(int length) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public NativeList<T> AllocateNativeList(int capacity) { }

	public override void Dispose() { }

	public int get_BlocksAllocated() { }

	public bool get_EnableBlockFree() { }

	public override TryFunction get_Function() { }

	public override AllocatorHandle get_Handle() { }

	public int get_InitialSizeInBytes() { }

	public override bool get_IsCustomAllocator() { }

	public override Allocator get_ToAllocator() { }

	public void Initialize(int initialSizeInBytes, bool enableBlockFree = false) { }

	public void Rewind() { }

	public void set_EnableBlockFree(bool value) { }

	public override void set_Handle(AllocatorHandle value) { }

	public override int Try(ref Block block) { }

	[BurstCompile]
	[MonoPInvokeCallback(typeof(TryFunction))]
	internal static int Try(IntPtr state, ref Block block) { }

	[BurstCompile]
	[MonoPInvokeCallback(typeof(TryFunction))]
	internal static int Try$BurstManaged(IntPtr state, ref Block block) { }

}

