//Type is in global namespace

internal class DelegateList
{
	private Func<Action`1<T>, LinkedListNode`1<Action`1<T>>> m_acquireFunc; //Field offset: 0x0
	private Action<LinkedListNode`1<Action`1<T>>> m_releaseFunc; //Field offset: 0x0
	private LinkedList<Action`1<T>> m_callbacks; //Field offset: 0x0
	private bool m_invoking; //Field offset: 0x0

	public int Count
	{
		 get { } //Length: 24
	}

	public DelegateList`1(Func<Action`1<T>, LinkedListNode`1<Action`1<T>>> acquireFunc, Action<LinkedListNode`1<Action`1<T>>> releaseFunc) { }

	public void Add(Action<T> action) { }

	public void Clear() { }

	public static DelegateList<T> CreateWithGlobalCache() { }

	public int get_Count() { }

	public void Invoke(T res) { }

	public void Remove(Action<T> action) { }

}

