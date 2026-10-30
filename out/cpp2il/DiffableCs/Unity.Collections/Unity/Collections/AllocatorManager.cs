namespace Unity.Collections;

[Extension]
public static class AllocatorManager
{
	internal struct AllocatorHandle : IAllocator, IDisposable
	{
		public ushort Index; //Field offset: 0x0
		public ushort Version; //Field offset: 0x2

		public override TryFunction Function
		{
			 get { } //Length: 8
		}

		public override AllocatorHandle Handle
		{
			 get { } //Length: 8
			 set { } //Length: 8
		}

		public override bool IsCustomAllocator
		{
			 get { } //Length: 16
		}

		internal bool IsInstalled
		{
			internal get { } //Length: 192
		}

		internal TableEntry TableEntry
		{
			internal get { } //Length: 152
		}

		public override Allocator ToAllocator
		{
			 get { } //Length: 8
		}

		public int Value
		{
			 get { } //Length: 8
		}

		public Block AllocateBlock(int items) { }

		[Conditional("ENABLE_UNITY_ALLOCATION_CHECKS")]
		private static void CheckAllocatedSuccessfully(int error) { }

		public override void Dispose() { }

		public override TryFunction get_Function() { }

		public override AllocatorHandle get_Handle() { }

		public override bool get_IsCustomAllocator() { }

		internal bool get_IsInstalled() { }

		internal TableEntry get_TableEntry() { }

		public override Allocator get_ToAllocator() { }

		public int get_Value() { }

		internal void IncrementVersion() { }

		internal void Install(TableEntry tableEntry) { }

		public static AllocatorHandle op_Implicit(Allocator a) { }

		internal void Rewind() { }

		public override void set_Handle(AllocatorHandle value) { }

		public override int Try(ref Block block) { }

		public int TryAllocateBlock(out Block block, int items) { }

	}

	public struct Array16
	{
		internal T f0; //Field offset: 0x0
		internal T f1; //Field offset: 0x0
		internal T f2; //Field offset: 0x0
		internal T f3; //Field offset: 0x0
		internal T f4; //Field offset: 0x0
		internal T f5; //Field offset: 0x0
		internal T f6; //Field offset: 0x0
		internal T f7; //Field offset: 0x0
		internal T f8; //Field offset: 0x0
		internal T f9; //Field offset: 0x0
		internal T f10; //Field offset: 0x0
		internal T f11; //Field offset: 0x0
		internal T f12; //Field offset: 0x0
		internal T f13; //Field offset: 0x0
		internal T f14; //Field offset: 0x0
		internal T f15; //Field offset: 0x0

	}

	public struct Array256
	{
		internal Array16<T> f0; //Field offset: 0x0
		internal Array16<T> f1; //Field offset: 0x0
		internal Array16<T> f2; //Field offset: 0x0
		internal Array16<T> f3; //Field offset: 0x0
		internal Array16<T> f4; //Field offset: 0x0
		internal Array16<T> f5; //Field offset: 0x0
		internal Array16<T> f6; //Field offset: 0x0
		internal Array16<T> f7; //Field offset: 0x0
		internal Array16<T> f8; //Field offset: 0x0
		internal Array16<T> f9; //Field offset: 0x0
		internal Array16<T> f10; //Field offset: 0x0
		internal Array16<T> f11; //Field offset: 0x0
		internal Array16<T> f12; //Field offset: 0x0
		internal Array16<T> f13; //Field offset: 0x0
		internal Array16<T> f14; //Field offset: 0x0
		internal Array16<T> f15; //Field offset: 0x0

	}

	public struct Array32768 : IIndexable<T>
	{
		internal Array4096<T> f0; //Field offset: 0x0
		internal Array4096<T> f1; //Field offset: 0x0
		internal Array4096<T> f2; //Field offset: 0x0
		internal Array4096<T> f3; //Field offset: 0x0
		internal Array4096<T> f4; //Field offset: 0x0
		internal Array4096<T> f5; //Field offset: 0x0
		internal Array4096<T> f6; //Field offset: 0x0
		internal Array4096<T> f7; //Field offset: 0x0

		public override int Length
		{
			 get { } //Length: 8
			 set { } //Length: 4
		}

		public override T ElementAt(int index) { }

		public override int get_Length() { }

		public override void set_Length(int value) { }

	}

	public struct Array4096
	{
		internal Array256<T> f0; //Field offset: 0x0
		internal Array256<T> f1; //Field offset: 0x0
		internal Array256<T> f2; //Field offset: 0x0
		internal Array256<T> f3; //Field offset: 0x0
		internal Array256<T> f4; //Field offset: 0x0
		internal Array256<T> f5; //Field offset: 0x0
		internal Array256<T> f6; //Field offset: 0x0
		internal Array256<T> f7; //Field offset: 0x0
		internal Array256<T> f8; //Field offset: 0x0
		internal Array256<T> f9; //Field offset: 0x0
		internal Array256<T> f10; //Field offset: 0x0
		internal Array256<T> f11; //Field offset: 0x0
		internal Array256<T> f12; //Field offset: 0x0
		internal Array256<T> f13; //Field offset: 0x0
		internal Array256<T> f14; //Field offset: 0x0
		internal Array256<T> f15; //Field offset: 0x0

	}

	internal struct Block : IDisposable
	{
		public Range Range; //Field offset: 0x0
		public int BytesPerItem; //Field offset: 0x10
		public int AllocatedItems; //Field offset: 0x14
		public byte Log2Alignment; //Field offset: 0x18
		public byte Padding0; //Field offset: 0x19
		public ushort Padding1; //Field offset: 0x1A
		public uint Padding2; //Field offset: 0x1C

		public int Alignment
		{
			 get { } //Length: 16
			 set { } //Length: 64
		}

		public long AllocatedBytes
		{
			 get { } //Length: 16
		}

		public long Bytes
		{
			 get { } //Length: 20
		}

		public void Allocate() { }

		[Conditional("ENABLE_UNITY_ALLOCATION_CHECKS")]
		private void CheckFailedToAllocate(int error) { }

		[Conditional("ENABLE_UNITY_ALLOCATION_CHECKS")]
		private void CheckFailedToFree(int error) { }

		public override void Dispose() { }

		public void Free() { }

		public int get_Alignment() { }

		public long get_AllocatedBytes() { }

		public long get_Bytes() { }

		public void set_Alignment(int value) { }

		public int TryAllocate() { }

		public int TryFree() { }

	}

	internal struct BlockHandle
	{
		public ushort Value; //Field offset: 0x0

	}

	internal interface IAllocator : IDisposable
	{

		public TryFunction Function
		{
			 get { } //Length: 0
		}

		public AllocatorHandle Handle
		{
			 get { } //Length: 0
			 set { } //Length: 0
		}

		public bool IsCustomAllocator
		{
			 get { } //Length: 0
		}

		public Allocator ToAllocator
		{
			 get { } //Length: 0
		}

		public TryFunction get_Function() { }

		public AllocatorHandle get_Handle() { }

		public bool get_IsCustomAllocator() { }

		public Allocator get_ToAllocator() { }

		public void set_Handle(AllocatorHandle value) { }

		public int Try(ref Block block) { }

	}

	public static class Managed
	{
		internal const int kMaxNumCustomAllocator = 32768; //Field offset: 0x0
		internal static TryFunction[] TryFunctionDelegates; //Field offset: 0x0

		private static Managed() { }

		[NotBurstCompatible]
		public static void RegisterDelegate(int index, TryFunction function) { }

		[NotBurstCompatible]
		public static void UnregisterDelegate(int index) { }

	}

	internal struct Range : IDisposable
	{
		public IntPtr Pointer; //Field offset: 0x0
		public int Items; //Field offset: 0x8
		public AllocatorHandle Allocator; //Field offset: 0xC

		public override void Dispose() { }

	}

	public sealed class SharedStatics
	{
		public sealed class IsInstalled
		{
			internal static readonly SharedStatic<Long1024> Ref; //Field offset: 0x0

			private static IsInstalled() { }

			public IsInstalled() { }

		}

		public sealed class TableEntry
		{
			internal static readonly SharedStatic<Array32768`1<TableEntry>> Ref; //Field offset: 0x0

			private static TableEntry() { }

			public TableEntry() { }

		}


		public SharedStatics() { }

	}

	[BurstCompile(CompileSynchronously = True)]
	public struct SlabAllocator : IAllocator, IDisposable
	{
		public static class Try_0000098E$BurstDirectCall
		{
			private static IntPtr Pointer; //Field offset: 0x0
			private static IntPtr DeferredCompilation; //Field offset: 0x8

			private static Try_0000098E$BurstDirectCall() { }

			public static void Constructor() { }

			private static IntPtr GetFunctionPointer() { }

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

			public static void Initialize() { }

			public static int Invoke(IntPtr allocatorState, ref Block block) { }

		}

		public sealed class Try_0000098E$PostfixBurstDelegate : MulticastDelegate
		{

			public Try_0000098E$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

			public override IAsyncResult BeginInvoke(IntPtr allocatorState, ref Block block, AsyncCallback unnamed_param_2, object unnamed_param_3) { }

			public override int EndInvoke(IAsyncResult unnamed_param_0) { }

			public override int Invoke(IntPtr allocatorState, ref Block block) { }

		}

		internal AllocatorHandle m_handle; //Field offset: 0x0
		internal Block Storage; //Field offset: 0x8
		internal int Log2SlabSizeInBytes; //Field offset: 0x28
		internal FixedList4096Bytes<Int32> Occupied; //Field offset: 0x2C
		internal long budgetInBytes; //Field offset: 0x1030
		internal long allocatedBytes; //Field offset: 0x1038

		public long AllocatedBytes
		{
			 get { } //Length: 8
		}

		public long BudgetInBytes
		{
			 get { } //Length: 8
		}

		public override TryFunction Function
		{
			 get { } //Length: 108
		}

		public override AllocatorHandle Handle
		{
			 get { } //Length: 8
			 set { } //Length: 8
		}

		public override bool IsCustomAllocator
		{
			 get { } //Length: 16
		}

		internal int Slabs
		{
			internal get { } //Length: 28
		}

		internal int SlabSizeInBytes
		{
			internal get { } //Length: 16
			internal set { } //Length: 68
		}

		public override Allocator ToAllocator
		{
			 get { } //Length: 8
		}

		public override void Dispose() { }

		public long get_AllocatedBytes() { }

		public long get_BudgetInBytes() { }

		public override TryFunction get_Function() { }

		public override AllocatorHandle get_Handle() { }

		public override bool get_IsCustomAllocator() { }

		internal int get_Slabs() { }

		internal int get_SlabSizeInBytes() { }

		public override Allocator get_ToAllocator() { }

		internal void Initialize(Block storage, int slabSizeInBytes, long budget) { }

		public override void set_Handle(AllocatorHandle value) { }

		internal void set_SlabSizeInBytes(int value) { }

		public override int Try(ref Block block) { }

		[BurstCompile(CompileSynchronously = True)]
		[MonoPInvokeCallback(typeof(TryFunction))]
		public static int Try(IntPtr allocatorState, ref Block block) { }

		[BurstCompile(CompileSynchronously = True)]
		[MonoPInvokeCallback(typeof(TryFunction))]
		internal static int Try$BurstManaged(IntPtr allocatorState, ref Block block) { }

	}

	[BurstCompile(CompileSynchronously = True)]
	public struct StackAllocator : IAllocator, IDisposable
	{
		public static class Try_00000980$BurstDirectCall
		{
			private static IntPtr Pointer; //Field offset: 0x0
			private static IntPtr DeferredCompilation; //Field offset: 0x8

			private static Try_00000980$BurstDirectCall() { }

			public static void Constructor() { }

			private static IntPtr GetFunctionPointer() { }

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

			public static void Initialize() { }

			public static int Invoke(IntPtr allocatorState, ref Block block) { }

		}

		public sealed class Try_00000980$PostfixBurstDelegate : MulticastDelegate
		{

			public Try_00000980$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

			public override IAsyncResult BeginInvoke(IntPtr allocatorState, ref Block block, AsyncCallback unnamed_param_2, object unnamed_param_3) { }

			public override int EndInvoke(IAsyncResult unnamed_param_0) { }

			public override int Invoke(IntPtr allocatorState, ref Block block) { }

		}

		internal AllocatorHandle m_handle; //Field offset: 0x0
		internal Block m_storage; //Field offset: 0x8
		internal long m_top; //Field offset: 0x28

		public override TryFunction Function
		{
			 get { } //Length: 108
		}

		public override AllocatorHandle Handle
		{
			 get { } //Length: 8
			 set { } //Length: 8
		}

		public override bool IsCustomAllocator
		{
			 get { } //Length: 16
		}

		public override Allocator ToAllocator
		{
			 get { } //Length: 8
		}

		public override void Dispose() { }

		public override TryFunction get_Function() { }

		public override AllocatorHandle get_Handle() { }

		public override bool get_IsCustomAllocator() { }

		public override Allocator get_ToAllocator() { }

		public void Initialize(Block storage) { }

		public override void set_Handle(AllocatorHandle value) { }

		public override int Try(ref Block block) { }

		[BurstCompile(CompileSynchronously = True)]
		[MonoPInvokeCallback(typeof(TryFunction))]
		public static int Try(IntPtr allocatorState, ref Block block) { }

		[BurstCompile(CompileSynchronously = True)]
		[MonoPInvokeCallback(typeof(TryFunction))]
		internal static int Try$BurstManaged(IntPtr allocatorState, ref Block block) { }

	}

	public struct TableEntry
	{
		internal IntPtr function; //Field offset: 0x0
		internal IntPtr state; //Field offset: 0x8

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class TryFunction : MulticastDelegate
	{

		public TryFunction(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(IntPtr allocatorState, ref Block block, AsyncCallback callback, object object) { }

		public override int EndInvoke(ref Block block, IAsyncResult result) { }

		public override int Invoke(IntPtr allocatorState, ref Block block) { }

	}

	public static readonly AllocatorHandle Invalid; //Field offset: 0x0
	public const int kErrorNone = 0; //Field offset: 0x0
	public const int kErrorBufferOverflow = -1; //Field offset: 0x0
	public const ushort FirstUserIndex = 64; //Field offset: 0x0
	public static readonly AllocatorHandle None; //Field offset: 0x4
	public static readonly AllocatorHandle Temp; //Field offset: 0x8
	public static readonly AllocatorHandle TempJob; //Field offset: 0xC
	public static readonly AllocatorHandle Persistent; //Field offset: 0x10
	public static readonly AllocatorHandle AudioKernel; //Field offset: 0x14

	private static AllocatorManager() { }

	[Extension]
	internal static Void* Allocate(ref T t, int sizeOf, int alignOf, int items) { }

	[Extension]
	internal static U* Allocate(ref T t, U u, int items) { }

	public static Void* Allocate(AllocatorHandle handle, int itemSizeInBytes, int alignmentInBytes, int items = 1) { }

	public static T* Allocate(AllocatorHandle handle, int items = 1) { }

	private static int allocate_block(ref Block block) { }

	[Extension]
	internal static Block AllocateBlock(ref T t, int sizeOf, int alignOf, int items) { }

	[Extension]
	internal static Block AllocateBlock(ref T t, U u, int items) { }

	[Extension]
	internal static Void* AllocateStruct(ref T t, U u, int items) { }

	[BurstDiscard]
	private static void CheckDelegate(ref bool useDelegate) { }

	[Conditional("ENABLE_UNITY_ALLOCATION_CHECKS")]
	internal static void CheckFailedToAllocate(int error) { }

	[Conditional("ENABLE_UNITY_ALLOCATION_CHECKS")]
	internal static void CheckFailedToFree(int error) { }

	[Conditional("ENABLE_UNITY_ALLOCATION_CHECKS")]
	internal static void CheckValid(AllocatorHandle handle) { }

	[NotBurstCompatible]
	internal static T CreateAllocator(AllocatorHandle backingAllocator) { }

	[Extension]
	[NotBurstCompatible]
	internal static void DestroyAllocator(ref T t, AllocatorHandle backingAllocator) { }

	[BurstDiscard]
	private static void forward_mono_allocate_block(ref Block block, ref int error) { }

	public static void Free(AllocatorHandle handle, Void* pointer, int itemSizeInBytes, int alignmentInBytes, int items = 1) { }

	[Extension]
	internal static void Free(ref T t, U* pointer, int items) { }

	[Extension]
	internal static void Free(ref T t, Void* pointer, int sizeOf, int alignOf, int items) { }

	public static void Free(AllocatorHandle handle, T* pointer, int items = 1) { }

	public static void Free(AllocatorHandle handle, Void* pointer) { }

	[Extension]
	internal static void FreeBlock(ref T t, ref Block block) { }

	public static void Initialize() { }

	public static void Initialize$SlabAllocator_Try_0000098E$BurstDirectCall() { }

	public static void Initialize$StackAllocator_Try_00000980$BurstDirectCall() { }

	internal static void Install(AllocatorHandle handle, IntPtr allocatorState, TryFunction function) { }

	internal static void Install(AllocatorHandle handle, IntPtr allocatorState, FunctionPointer<TryFunction> functionPointer, TryFunction function) { }

	internal static bool IsCustomAllocator(AllocatorHandle allocator) { }

	internal static Allocator LegacyOf(AllocatorHandle handle) { }

	[Extension]
	[NotBurstCompatible]
	public static void Register(ref T t) { }

	internal static AllocatorHandle Register(IntPtr allocatorState, FunctionPointer<TryFunction> functionPointer) { }

	public static void Shutdown() { }

	public static int Try(ref Block block) { }

	private static int TryLegacy(ref Block block) { }

	[Extension]
	public static void UnmanagedUnregister(ref T t) { }

	[Extension]
	[NotBurstCompatible]
	public static void Unregister(ref T t) { }

	private static bool UseDelegate() { }

}

