namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
[Extension]
internal static class UnsafePtrListTExtensions
{

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static UnsafeList<IntPtr>& ListData(ref UnsafePtrList<T>& from) { }

}

