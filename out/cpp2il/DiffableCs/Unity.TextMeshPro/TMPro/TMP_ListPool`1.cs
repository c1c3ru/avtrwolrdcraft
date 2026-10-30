namespace TMPro;

internal static class TMP_ListPool
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<T> <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <.cctor>b__3_0(List<T> l) { }

	}

	private static readonly TMP_ObjectPool<List`1<T>> s_ListPool; //Field offset: 0x0

	private static TMP_ListPool`1() { }

	public static List<T> Get() { }

	public static void Release(List<T> toRelease) { }

}

