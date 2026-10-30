namespace System.Collections.Generic;

[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(IDictionaryDebugView`2))]
[DefaultMember("Item")]
public class SortedList : IDictionary<TKey, TValue>, ICollection<KeyValuePair`2<TKey, TValue>>, IEnumerable<KeyValuePair`2<TKey, TValue>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair`2<TKey, TValue>>
{
	private struct Enumerator : IEnumerator<KeyValuePair`2<TKey, TValue>>, IDisposable, IEnumerator, IDictionaryEnumerator
	{
		private SortedList<TKey, TValue> _sortedList; //Field offset: 0x0
		private TKey _key; //Field offset: 0x0
		private TValue _value; //Field offset: 0x0
		private int _index; //Field offset: 0x0
		private int _version; //Field offset: 0x0
		private int _getEnumeratorRetType; //Field offset: 0x0

		public override KeyValuePair<TKey, TValue> Current
		{
			 get { } //Length: 84
		}

		private override DictionaryEntry System.Collections.IDictionaryEnumerator.Entry
		{
			private get { } //Length: 224
		}

		private override object System.Collections.IDictionaryEnumerator.Key
		{
			private get { } //Length: 188
		}

		private override object System.Collections.IDictionaryEnumerator.Value
		{
			private get { } //Length: 152
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 376
		}

		internal Enumerator(SortedList<TKey, TValue> sortedList, int getEnumeratorRetType) { }

		public override void Dispose() { }

		public override KeyValuePair<TKey, TValue> get_Current() { }

		public override bool MoveNext() { }

		private override DictionaryEntry System.Collections.IDictionaryEnumerator.get_Entry() { }

		private override object System.Collections.IDictionaryEnumerator.get_Key() { }

		private override object System.Collections.IDictionaryEnumerator.get_Value() { }

		private override object System.Collections.IEnumerator.get_Current() { }

		private override void System.Collections.IEnumerator.Reset() { }

	}

	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(DictionaryKeyCollectionDebugView`2))]
	[DefaultMember("Item")]
	private sealed class KeyList : IList<TKey>, ICollection<TKey>, IEnumerable<TKey>, IEnumerable, ICollection
	{
		private SortedList<TKey, TValue> _dict; //Field offset: 0x0

		public override int Count
		{
			 get { } //Length: 28
		}

		public override bool IsReadOnly
		{
			 get { } //Length: 8
		}

		public override TKey Item
		{
			 get { } //Length: 36
			 set { } //Length: 72
		}

		private override bool System.Collections.ICollection.IsSynchronized
		{
			private get { } //Length: 8
		}

		private override object System.Collections.ICollection.SyncRoot
		{
			private get { } //Length: 164
		}

		internal KeyList(SortedList<TKey, TValue> dictionary) { }

		public override void Add(TKey key) { }

		public override void Clear() { }

		public override bool Contains(TKey key) { }

		public override void CopyTo(TKey[] array, int arrayIndex) { }

		public override int get_Count() { }

		public override bool get_IsReadOnly() { }

		public override TKey get_Item(int index) { }

		public override IEnumerator<TKey> GetEnumerator() { }

		public override int IndexOf(TKey key) { }

		public override void Insert(int index, TKey value) { }

		public override bool Remove(TKey key) { }

		public override void RemoveAt(int index) { }

		public override void set_Item(int index, TKey value) { }

		private override void System.Collections.ICollection.CopyTo(Array array, int arrayIndex) { }

		private override bool System.Collections.ICollection.get_IsSynchronized() { }

		private override object System.Collections.ICollection.get_SyncRoot() { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	}

	private sealed class SortedListKeyEnumerator : IEnumerator<TKey>, IDisposable, IEnumerator
	{
		private SortedList<TKey, TValue> _sortedList; //Field offset: 0x0
		private int _index; //Field offset: 0x0
		private int _version; //Field offset: 0x0
		private TKey _currentKey; //Field offset: 0x0

		public override TKey Current
		{
			 get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 148
		}

		internal SortedListKeyEnumerator(SortedList<TKey, TValue> sortedList) { }

		public override void Dispose() { }

		public override TKey get_Current() { }

		public override bool MoveNext() { }

		private override object System.Collections.IEnumerator.get_Current() { }

		private override void System.Collections.IEnumerator.Reset() { }

	}

	private sealed class SortedListValueEnumerator : IEnumerator<TValue>, IDisposable, IEnumerator
	{
		private SortedList<TKey, TValue> _sortedList; //Field offset: 0x0
		private int _index; //Field offset: 0x0
		private int _version; //Field offset: 0x0
		private TValue _currentValue; //Field offset: 0x0

		public override TValue Current
		{
			 get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 124
		}

		internal SortedListValueEnumerator(SortedList<TKey, TValue> sortedList) { }

		public override void Dispose() { }

		public override TValue get_Current() { }

		public override bool MoveNext() { }

		private override object System.Collections.IEnumerator.get_Current() { }

		private override void System.Collections.IEnumerator.Reset() { }

	}

	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(DictionaryValueCollectionDebugView`2))]
	[DefaultMember("Item")]
	private sealed class ValueList : IList<TValue>, ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection
	{
		private SortedList<TKey, TValue> _dict; //Field offset: 0x0

		public override int Count
		{
			 get { } //Length: 28
		}

		public override bool IsReadOnly
		{
			 get { } //Length: 8
		}

		public override TValue Item
		{
			 get { } //Length: 36
			 set { } //Length: 72
		}

		private override bool System.Collections.ICollection.IsSynchronized
		{
			private get { } //Length: 8
		}

		private override object System.Collections.ICollection.SyncRoot
		{
			private get { } //Length: 164
		}

		internal ValueList(SortedList<TKey, TValue> dictionary) { }

		public override void Add(TValue key) { }

		public override void Clear() { }

		public override bool Contains(TValue value) { }

		public override void CopyTo(TValue[] array, int arrayIndex) { }

		public override int get_Count() { }

		public override bool get_IsReadOnly() { }

		public override TValue get_Item(int index) { }

		public override IEnumerator<TValue> GetEnumerator() { }

		public override int IndexOf(TValue value) { }

		public override void Insert(int index, TValue value) { }

		public override bool Remove(TValue value) { }

		public override void RemoveAt(int index) { }

		public override void set_Item(int index, TValue value) { }

		private override void System.Collections.ICollection.CopyTo(Array array, int index) { }

		private override bool System.Collections.ICollection.get_IsSynchronized() { }

		private override object System.Collections.ICollection.get_SyncRoot() { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	}

	private TKey[] keys; //Field offset: 0x0
	private TValue[] values; //Field offset: 0x0
	private int _size; //Field offset: 0x0
	private int version; //Field offset: 0x0
	private IComparer<TKey> comparer; //Field offset: 0x0
	private KeyList<TKey, TValue> keyList; //Field offset: 0x0
	private ValueList<TKey, TValue> valueList; //Field offset: 0x0
	private object _syncRoot; //Field offset: 0x0

	public int Capacity
	{
		 set { } //Length: 584
	}

	public override int Count
	{
		 get { } //Length: 8
	}

	public override TValue Item
	{
		 get { } //Length: 232
		 set { } //Length: 184
	}

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.IsReadOnly
	{
		private get { } //Length: 8
	}

	private override ICollection<TKey> System.Collections.Generic.IDictionary<TKey,TValue>.Keys
	{
		private get { } //Length: 16
	}

	private override ICollection<TValue> System.Collections.Generic.IDictionary<TKey,TValue>.Values
	{
		private get { } //Length: 16
	}

	private override IEnumerable<TKey> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Keys
	{
		private get { } //Length: 16
	}

	private override IEnumerable<TValue> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Values
	{
		private get { } //Length: 16
	}

	private override bool System.Collections.ICollection.IsSynchronized
	{
		private get { } //Length: 8
	}

	private override object System.Collections.ICollection.SyncRoot
	{
		private get { } //Length: 116
	}

	private override bool System.Collections.IDictionary.IsFixedSize
	{
		private get { } //Length: 8
	}

	private override bool System.Collections.IDictionary.IsReadOnly
	{
		private get { } //Length: 8
	}

	private override object System.Collections.IDictionary.Item
	{
		private get { } //Length: 228
		private set { } //Length: 544
	}

	private override ICollection System.Collections.IDictionary.Keys
	{
		private get { } //Length: 16
	}

	private override ICollection System.Collections.IDictionary.Values
	{
		private get { } //Length: 16
	}

	public IList<TValue> Values
	{
		 get { } //Length: 16
	}

	public SortedList`2() { }

	public override void Add(TKey key, TValue value) { }

	public override void Clear() { }

	public override bool ContainsKey(TKey key) { }

	public bool ContainsValue(TValue value) { }

	private void EnsureCapacity(int min) { }

	public override int get_Count() { }

	public override TValue get_Item(TKey key) { }

	public IList<TValue> get_Values() { }

	private TValue GetByIndex(int index) { }

	private TKey GetKey(int index) { }

	private KeyList<TKey, TValue> GetKeyListHelper() { }

	private ValueList<TKey, TValue> GetValueListHelper() { }

	public int IndexOfKey(TKey key) { }

	public int IndexOfValue(TValue value) { }

	private void Insert(int index, TKey key, TValue value) { }

	private static bool IsCompatibleKey(object key) { }

	public override bool Remove(TKey key) { }

	public void RemoveAt(int index) { }

	public void set_Capacity(int value) { }

	public override void set_Item(TKey key, TValue value) { }

	private override void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair) { }

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair) { }

	private override void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) { }

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.get_IsReadOnly() { }

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair) { }

	private override ICollection<TKey> System.Collections.Generic.IDictionary<TKey,TValue>.get_Keys() { }

	private override ICollection<TValue> System.Collections.Generic.IDictionary<TKey,TValue>.get_Values() { }

	private override IEnumerator<KeyValuePair`2<TKey, TValue>> System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>.GetEnumerator() { }

	private override IEnumerable<TKey> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.get_Keys() { }

	private override IEnumerable<TValue> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.get_Values() { }

	private override void System.Collections.ICollection.CopyTo(Array array, int index) { }

	private override bool System.Collections.ICollection.get_IsSynchronized() { }

	private override object System.Collections.ICollection.get_SyncRoot() { }

	private override void System.Collections.IDictionary.Add(object key, object value) { }

	private override bool System.Collections.IDictionary.Contains(object key) { }

	private override bool System.Collections.IDictionary.get_IsFixedSize() { }

	private override bool System.Collections.IDictionary.get_IsReadOnly() { }

	private override object System.Collections.IDictionary.get_Item(object key) { }

	private override ICollection System.Collections.IDictionary.get_Keys() { }

	private override ICollection System.Collections.IDictionary.get_Values() { }

	private override IDictionaryEnumerator System.Collections.IDictionary.GetEnumerator() { }

	private override void System.Collections.IDictionary.Remove(object key) { }

	private override void System.Collections.IDictionary.set_Item(object key, object value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public override bool TryGetValue(TKey key, out TValue value) { }

}

