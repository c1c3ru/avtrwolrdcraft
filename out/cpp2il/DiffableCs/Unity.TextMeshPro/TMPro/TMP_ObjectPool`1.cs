namespace TMPro;

internal class TMP_ObjectPool
{
	private readonly Stack<T> m_Stack; //Field offset: 0x0
	private readonly UnityAction<T> m_ActionOnGet; //Field offset: 0x0
	private readonly UnityAction<T> m_ActionOnRelease; //Field offset: 0x0
	[CompilerGenerated]
	private int <countAll>k__BackingField; //Field offset: 0x0

	public int countActive
	{
		 get { } //Length: 36
	}

	public private int countAll
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public int countInactive
	{
		 get { } //Length: 28
	}

	public TMP_ObjectPool`1(UnityAction<T> actionOnGet, UnityAction<T> actionOnRelease) { }

	public T Get() { }

	public int get_countActive() { }

	[CompilerGenerated]
	public int get_countAll() { }

	public int get_countInactive() { }

	public void Release(T element) { }

	[CompilerGenerated]
	private void set_countAll(int value) { }

}

