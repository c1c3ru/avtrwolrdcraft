namespace TMPro;

[DebuggerDisplay("Item count = {m_Count}")]
public struct TMP_TextProcessingStack
{
	private const int k_DefaultCapacity = 4; //Field offset: 0x0
	public T[] itemStack; //Field offset: 0x0
	public int index; //Field offset: 0x0
	private T m_DefaultItem; //Field offset: 0x0
	private int m_Capacity; //Field offset: 0x0
	private int m_RolloverSize; //Field offset: 0x0
	private int m_Count; //Field offset: 0x0

	public int Count
	{
		 get { } //Length: 8
	}

	public T current
	{
		 get { } //Length: 76
	}

	public int rolloverSize
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public TMP_TextProcessingStack`1(T[] stack) { }

	public TMP_TextProcessingStack`1(int capacity) { }

	public TMP_TextProcessingStack`1(int capacity, int rolloverSize) { }

	public void Add(T item) { }

	public void Clear() { }

	public T CurrentItem() { }

	public int get_Count() { }

	public T get_current() { }

	public int get_rolloverSize() { }

	public T Peek() { }

	public T Pop() { }

	public T PreviousItem() { }

	public void Push(T item) { }

	public T Remove() { }

	public void set_rolloverSize(int value) { }

	internal static void SetDefault(TMP_TextProcessingStack<T>[] stack, T item) { }

	public void SetDefault(T item) { }

}

