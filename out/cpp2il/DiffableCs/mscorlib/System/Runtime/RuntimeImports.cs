namespace System.Runtime;

internal static class RuntimeImports
{

	internal static void Memmove(Byte* dest, Byte* src, uint len) { }

	internal static void Memmove_wbarrier(Byte* dest, Byte* src, uint len, IntPtr type_handle) { }

	internal static void RhZeroMemory(ref byte b, ulong byteLength) { }

	private static void ZeroMemory(Void* p, uint byteLength) { }

}

