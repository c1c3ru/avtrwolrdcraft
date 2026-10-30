namespace Unity.Burst;

[IsReadOnly]
public struct SharedStatic
{
	private const uint DefaultAlignment = 16; //Field offset: 0x0
	private readonly Void* _buffer; //Field offset: 0x0

	public T Data
	{
		 get { } //Length: 40
	}

	public Void* UnsafeDataPointer
	{
		 get { } //Length: 8
	}

	private SharedStatic`1(Void* buffer) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckIf_T_IsUnmanagedOrThrow() { }

	public T get_Data() { }

	public Void* get_UnsafeDataPointer() { }

	public static SharedStatic<T> GetOrCreate(uint alignment = 0) { }

	public static SharedStatic<T> GetOrCreate(uint alignment = 0) { }

	public static SharedStatic<T> GetOrCreate(Type contextType, uint alignment = 0) { }

	public static SharedStatic<T> GetOrCreate(Type contextType, Type subContextType, uint alignment = 0) { }

	public static SharedStatic<T> GetOrCreatePartiallyUnsafeWithHashCode(uint alignment, long hashCode) { }

	public static SharedStatic<T> GetOrCreatePartiallyUnsafeWithSubHashCode(uint alignment, long subHashCode) { }

	public static SharedStatic<T> GetOrCreateUnsafe(uint alignment, long hashCode, long subHashCode) { }

}

