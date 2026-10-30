namespace Unity.Burst;

internal static class SharedStatic
{
	public class PreserveAttribute : Attribute
	{

		public PreserveAttribute() { }

	}


	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckResult(Void* result) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckSizeOf(uint sizeOf) { }

	[Preserve]
	public static Void* GetOrCreateSharedStaticInternal(long getHashCode64, long getSubHashCode64, uint sizeOf, uint alignment) { }

}

