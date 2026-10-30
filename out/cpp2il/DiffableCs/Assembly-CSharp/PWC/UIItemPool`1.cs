namespace PWC;

public class UIItemPool
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<T> <>9; //Field offset: 0x0
		public static Action<T> <>9__1_2; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <.ctor>b__1_2(T item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public T prefab; //Field offset: 0x0
		public Transform parent; //Field offset: 0x0

		public <>c__DisplayClass1_0() { }

		internal T <.ctor>b__0() { }

		internal void <.ctor>b__1(T item) { }

	}

	private readonly ObjectPool<T> _pool; //Field offset: 0x0

	public UIItemPool`1(T prefab, Transform parent) { }

	public T Get() { }

	public void Release(T item) { }

	public void Release(ref List<T>& items) { }

}

