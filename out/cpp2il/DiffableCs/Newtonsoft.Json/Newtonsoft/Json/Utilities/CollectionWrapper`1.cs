namespace Newtonsoft.Json.Utilities;

[Nullable(0)]
[NullableContext(1)]
internal class CollectionWrapper : ICollection<T>, IEnumerable<T>, IEnumerable, IWrappedCollection, IList, ICollection
{
	[Nullable(2)]
	private readonly IList _list; //Field offset: 0x0
	[Nullable(new IL2CPP_TYPE_U1[] {2, 1})]
	private readonly ICollection<T> _genericCollection; //Field offset: 0x0
	[Nullable(2)]
	private object _syncRoot; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 276
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 272
	}

	private override bool System.Collections.ICollection.IsSynchronized
	{
		private get { } //Length: 8
	}

	private override object System.Collections.ICollection.SyncRoot
	{
		private get { } //Length: 116
	}

	private override bool System.Collections.IList.IsFixedSize
	{
		private get { } //Length: 272
	}

	[Nullable(2)]
	private override object System.Collections.IList.Item
	{
		[NullableContext(2)]
		private get { } //Length: 248
		[NullableContext(2)]
		private set { } //Length: 440
	}

	public override object UnderlyingCollection
	{
		 get { } //Length: 24
	}

	public CollectionWrapper`1(IList list) { }

	public CollectionWrapper`1(ICollection<T> list) { }

	public override void Add(T item) { }

	public override void Clear() { }

	public override bool Contains(T item) { }

	public override void CopyTo(T[] array, int arrayIndex) { }

	public override int get_Count() { }

	public override bool get_IsReadOnly() { }

	public override object get_UnderlyingCollection() { }

	public override IEnumerator<T> GetEnumerator() { }

	[NullableContext(2)]
	private static bool IsCompatibleObject(object value) { }

	public override bool Remove(T item) { }

	private override void System.Collections.ICollection.CopyTo(Array array, int arrayIndex) { }

	private override bool System.Collections.ICollection.get_IsSynchronized() { }

	private override object System.Collections.ICollection.get_SyncRoot() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	[NullableContext(2)]
	private override int System.Collections.IList.Add(object value) { }

	[NullableContext(2)]
	private override bool System.Collections.IList.Contains(object value) { }

	private override bool System.Collections.IList.get_IsFixedSize() { }

	[NullableContext(2)]
	private override object System.Collections.IList.get_Item(int index) { }

	[NullableContext(2)]
	private override int System.Collections.IList.IndexOf(object value) { }

	[NullableContext(2)]
	private override void System.Collections.IList.Insert(int index, object value) { }

	[NullableContext(2)]
	private override void System.Collections.IList.Remove(object value) { }

	private override void System.Collections.IList.RemoveAt(int index) { }

	[NullableContext(2)]
	private override void System.Collections.IList.set_Item(int index, object value) { }

	[NullableContext(2)]
	private static void VerifyValueType(object value) { }

}

