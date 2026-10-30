namespace Unity.Collections.LowLevel.Unsafe;

[NativeHeader("Runtime/Export/Unsafe/UnsafeUtility.bindings.h")]
[StaticAccessor("UnsafeUtility", StaticAccessorType::DoubleColon (2))]
public static class UnsafeUtility
{
	private struct AlignOfHelper
	{
		public byte dummy; //Field offset: 0x0
		public T data; //Field offset: 0x0

	}

	public struct TypeFlagsCache
	{
		internal static readonly int flags; //Field offset: 0x0

		private static TypeFlagsCache`1() { }

		[BurstDiscard]
		private static void Init(ref int flags) { }

	}


	public static Void* AddressOf(ref T output) { }

	public static int AlignOf() { }

	public static T ArrayElementAsRef(Void* ptr, int index) { }

	public static T As(ref U from) { }

	public static T AsRef(Void* ptr) { }

	public static void CopyPtrToStructure(Void* ptr, out T output) { }

	public static void CopyStructureToPtr(ref T input, Void* ptr) { }

	public static bool EnumEquals(T lhs, T rhs) { }

	public static int EnumToInt(T enumValue) { }

	[ThreadSafe(ThrowsException = True)]
	public static void Free(Void* memory, Allocator allocator) { }

	[ThreadSafe(ThrowsException = True)]
	public static void FreeTracked(Void* memory, Allocator allocator) { }

	[ThreadSafe]
	internal static int GetScriptingTypeFlags(Type type) { }

	private static void InternalCopyPtrToStructure(Void* ptr, out T output) { }

	private static void InternalCopyStructureToPtr(ref T input, Void* ptr) { }

	private static void InternalEnumToInt(ref T enumValue, ref int intValue) { }

	public static bool IsUnmanaged() { }

	public static bool IsValidNativeContainerElementType() { }

	[ThreadSafe(ThrowsException = True)]
	public static Void* Malloc(long size, int alignment, Allocator allocator) { }

	[ThreadSafe(ThrowsException = True)]
	public static Void* MallocTracked(long size, int alignment, Allocator allocator, int callstacksToSkip) { }

	public static void MemClear(Void* destination, long size) { }

	[ThreadSafe(ThrowsException = True)]
	public static int MemCmp(Void* ptr1, Void* ptr2, long size) { }

	[ThreadSafe(ThrowsException = True)]
	public static void MemCpy(Void* destination, Void* source, long size) { }

	[ThreadSafe(ThrowsException = True)]
	public static void MemCpyStride(Void* destination, int destinationStride, Void* source, int sourceStride, int elementSize, int count) { }

	[ThreadSafe(ThrowsException = True)]
	public static void MemMove(Void* destination, Void* source, long size) { }

	[ThreadSafe(ThrowsException = True)]
	public static void MemSet(Void* destination, byte value, long size) { }

	public static T ReadArrayElement(Void* source, int index) { }

	public static T ReadArrayElementWithStride(Void* source, int index, int stride) { }

	public static int SizeOf() { }

	public static void WriteArrayElement(Void* destination, int index, T value) { }

	public static void WriteArrayElementWithStride(Void* destination, int index, int stride, T value) { }

}

