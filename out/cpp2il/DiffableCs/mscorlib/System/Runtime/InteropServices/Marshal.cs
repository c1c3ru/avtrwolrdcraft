namespace System.Runtime.InteropServices;

public static class Marshal
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Dictionary`2<ValueTuple`2<Type, String>, ICustomMarshaler>> <>9__201_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal Dictionary<ValueTuple`2<Type, String>, ICustomMarshaler> <GetCustomMarshalerInstance>b__201_0() { }

	}

	public class MarshalerInstanceKeyComparer : IEqualityComparer<ValueTuple`2<Type, String>>
	{

		public MarshalerInstanceKeyComparer() { }

		public override bool Equals(ValueTuple<Type, String> lhs, ValueTuple<Type, String> rhs) { }

		public override int GetHashCode(ValueTuple<Type, String> key) { }

	}

	public sealed class SecureStringAllocator : MulticastDelegate
	{

		public SecureStringAllocator(object object, IntPtr method) { }

		public override IntPtr Invoke(int len) { }

	}

	public static readonly int SystemMaxDBCSCharSize; //Field offset: 0x0
	public static readonly int SystemDefaultCharSize; //Field offset: 0x4
	internal static Dictionary<ValueTuple`2<Type, String>, ICustomMarshaler> MarshalerInstanceCache; //Field offset: 0x8
	internal static readonly object MarshalerInstanceCacheLock; //Field offset: 0x10

	private static Marshal() { }

	[ReliabilityContract(Consistency::WillNotCorruptState (3), Cer::MayFail (1))]
	public static IntPtr AllocHGlobal(IntPtr cb) { }

	[ReliabilityContract(Consistency::WillNotCorruptState (3), Cer::MayFail (1))]
	public static IntPtr AllocHGlobal(int cb) { }

	private static void ClearAnsi(IntPtr ptr) { }

	private static void ClearUnicode(IntPtr ptr) { }

	public static void Copy(Byte[] source, int startIndex, IntPtr destination, int length) { }

	public static void Copy(IntPtr source, Byte[] destination, int startIndex, int length) { }

	public static void Copy(IntPtr source, Char[] destination, int startIndex, int length) { }

	internal static void copy_from_unmanaged(IntPtr source, int startIndex, Array destination, int length) { }

	private static void copy_from_unmanaged_fixed(IntPtr source, int startIndex, Array destination, int length, Void* fixed_destination_element) { }

	internal static void copy_to_unmanaged(Byte[] source, int startIndex, IntPtr destination, int length) { }

	private static void copy_to_unmanaged_fixed(Array source, int startIndex, IntPtr destination, int length, Void* fixed_source_element) { }

	public static void FreeBSTR(IntPtr ptr) { }

	[ReliabilityContract(Consistency::WillNotCorruptState (3), Cer::Success (2))]
	public static void FreeHGlobal(IntPtr hglobal) { }

	internal static ICustomMarshaler GetCustomMarshalerInstance(Type type, string cookie) { }

	public static Delegate GetDelegateForFunctionPointer(IntPtr ptr, Type t) { }

	public static TDelegate GetDelegateForFunctionPointer(IntPtr ptr) { }

	private static Delegate GetDelegateForFunctionPointerInternal(IntPtr ptr, Type t) { }

	public static IntPtr GetFunctionPointerForDelegate(TDelegate d) { }

	public static IntPtr GetFunctionPointerForDelegate(Delegate d) { }

	private static IntPtr GetFunctionPointerForDelegateInternal(Delegate d) { }

	public static int GetHRForException(Exception e) { }

	[ReliabilityContract(Consistency::WillNotCorruptState (3), Cer::Success (2))]
	public static int GetLastWin32Error() { }

	public static bool IsComObject(object o) { }

	public static IntPtr OffsetOf(Type t, string fieldName) { }

	public static string PtrToStringAnsi(IntPtr ptr) { }

	public static string PtrToStringUni(IntPtr ptr) { }

	public static T PtrToStructure(IntPtr ptr) { }

	[ComVisible(True)]
	public static object PtrToStructure(IntPtr ptr, Type structureType) { }

	public static byte ReadByte(IntPtr ptr) { }

	public static byte ReadByte(IntPtr ptr, int ofs) { }

	public static short ReadInt16(IntPtr ptr, int ofs) { }

	internal static IntPtr SecureStringGlobalAllocator(int len) { }

	public static IntPtr SecureStringToGlobalAllocUnicode(SecureString s) { }

	internal static IntPtr SecureStringToUnicode(SecureString s, SecureStringAllocator allocator) { }

	public static int SizeOf(Type t) { }

	private static bool skip_fixed(Array array, int startIndex) { }

	private static IntPtr StringToHGlobalAnsi(Char* s, int length) { }

	public static IntPtr StringToHGlobalAnsi(string s) { }

	public static void StructureToPtr(T structure, IntPtr ptr, bool fDeleteOld) { }

	[ComVisible(True)]
	[ReliabilityContract(Consistency::WillNotCorruptState (3), Cer::MayFail (1))]
	public static void StructureToPtr(object structure, IntPtr ptr, bool fDeleteOld) { }

	public static IntPtr UnsafeAddrOfPinnedArrayElement(Array arr, int index) { }

	public static IntPtr UnsafeAddrOfPinnedArrayElement(T[] arr, int index) { }

	public static void WriteByte(IntPtr ptr, int ofs, byte val) { }

	public static void WriteInt16(IntPtr ptr, int ofs, short val) { }

	public static void ZeroFreeGlobalAllocAnsi(IntPtr s) { }

	public static void ZeroFreeGlobalAllocUnicode(IntPtr s) { }

}

