namespace System.Collections.Generic;

[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(ICollectionDebugView`1))]
public class LinkedList : ICollection<T>, IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>, ISerializable, IDeserializationCallback
{
	internal struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator, ISerializable, IDeserializationCallback
	{
		private LinkedList<T> _list; //Field offset: 0x0
		private LinkedListNode<T> _node; //Field offset: 0x0
		private int _version; //Field offset: 0x0
		private T _current; //Field offset: 0x0
		private int _index; //Field offset: 0x0

		public override T Current
		{
			 get { } //Length: 12
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 196
		}

		internal Enumerator(LinkedList<T> list) { }

		private Enumerator(SerializationInfo info, StreamingContext context) { }

		public override void Dispose() { }

		public override T get_Current() { }

		public override bool MoveNext() { }

		private override object System.Collections.IEnumerator.get_Current() { }

		private override void System.Collections.IEnumerator.Reset() { }

		private override void System.Runtime.Serialization.IDeserializationCallback.OnDeserialization(object sender) { }

		private override void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

	}

	private const string VersionName = "Version"; //Field offset: 0x0
	private const string CountName = "Count"; //Field offset: 0x0
	private const string ValuesName = "Data"; //Field offset: 0x0
	internal LinkedListNode<T> head; //Field offset: 0x0
	internal int count; //Field offset: 0x0
	internal int version; //Field offset: 0x0
	private object _syncRoot; //Field offset: 0x0
	private SerializationInfo _siInfo; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 8
	}

	public LinkedListNode<T> First
	{
		 get { } //Length: 8
	}

	public LinkedListNode<T> Last
	{
		 get { } //Length: 24
	}

	private override bool System.Collections.Generic.ICollection<T>.IsReadOnly
	{
		private get { } //Length: 8
	}

	private override bool System.Collections.ICollection.IsSynchronized
	{
		private get { } //Length: 8
	}

	private override object System.Collections.ICollection.SyncRoot
	{
		private get { } //Length: 112
	}

	public LinkedList`1() { }

	protected LinkedList`1(SerializationInfo info, StreamingContext context) { }

	public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode) { }

	public LinkedListNode<T> AddFirst(T value) { }

	public void AddFirst(LinkedListNode<T> node) { }

	public LinkedListNode<T> AddLast(T value) { }

	public void AddLast(LinkedListNode<T> node) { }

	public override void Clear() { }

	public override bool Contains(T value) { }

	public override void CopyTo(T[] array, int index) { }

	public LinkedListNode<T> Find(T value) { }

	public override int get_Count() { }

	public LinkedListNode<T> get_First() { }

	public LinkedListNode<T> get_Last() { }

	public Enumerator<T> GetEnumerator() { }

	public override void GetObjectData(SerializationInfo info, StreamingContext context) { }

	private void InternalInsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode) { }

	private void InternalInsertNodeToEmptyList(LinkedListNode<T> newNode) { }

	internal void InternalRemoveNode(LinkedListNode<T> node) { }

	public override void OnDeserialization(object sender) { }

	public override bool Remove(T value) { }

	public void Remove(LinkedListNode<T> node) { }

	public void RemoveFirst() { }

	public void RemoveLast() { }

	private override void System.Collections.Generic.ICollection<T>.Add(T value) { }

	private override bool System.Collections.Generic.ICollection<T>.get_IsReadOnly() { }

	private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

	private override void System.Collections.ICollection.CopyTo(Array array, int index) { }

	private override bool System.Collections.ICollection.get_IsSynchronized() { }

	private override object System.Collections.ICollection.get_SyncRoot() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	internal void ValidateNewNode(LinkedListNode<T> node) { }

	internal void ValidateNode(LinkedListNode<T> node) { }

}

