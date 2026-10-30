namespace System.Collections;

[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(StackDebugView))]
public class Stack : ICollection, IEnumerable, ICloneable
{
	public class StackDebugView
	{

	}

	private class StackEnumerator : IEnumerator, ICloneable
	{
		private Stack _stack; //Field offset: 0x10
		private int _index; //Field offset: 0x18
		private int _version; //Field offset: 0x1C
		private object _currentElement; //Field offset: 0x20

		public override object Current
		{
			 get { } //Length: 140
		}

		internal StackEnumerator(Stack stack) { }

		public override object Clone() { }

		public override object get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

	}

	private const int _defaultCapacity = 10; //Field offset: 0x0
	private Object[] _array; //Field offset: 0x10
	private int _size; //Field offset: 0x18
	private int _version; //Field offset: 0x1C
	private object _syncRoot; //Field offset: 0x20

	public override int Count
	{
		 get { } //Length: 8
	}

	public override bool IsSynchronized
	{
		 get { } //Length: 8
	}

	public override object SyncRoot
	{
		 get { } //Length: 112
	}

	public Stack() { }

	public Stack(int initialCapacity) { }

	public override void Clear() { }

	public override object Clone() { }

	public override void CopyTo(Array array, int index) { }

	public override int get_Count() { }

	public override bool get_IsSynchronized() { }

	public override object get_SyncRoot() { }

	public override IEnumerator GetEnumerator() { }

	public override object Peek() { }

	public override object Pop() { }

	public override void Push(object obj) { }

}

