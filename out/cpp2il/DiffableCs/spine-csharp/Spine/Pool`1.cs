namespace Spine;

internal class Pool
{
	internal interface IPoolable
	{

		public void Reset() { }

	}

	public readonly int max; //Field offset: 0x0
	private readonly Stack<T> freeObjects; //Field offset: 0x0
	[CompilerGenerated]
	private int <Peak>k__BackingField; //Field offset: 0x0

	public int Count
	{
		 get { } //Length: 28
	}

	public private int Peak
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public Pool`1(int initialCapacity = 16, int max = 2147483647) { }

	public void Clear() { }

	public void Free(T obj) { }

	public int get_Count() { }

	[CompilerGenerated]
	public int get_Peak() { }

	public T Obtain() { }

	protected void Reset(T obj) { }

	[CompilerGenerated]
	private void set_Peak(int value) { }

}

