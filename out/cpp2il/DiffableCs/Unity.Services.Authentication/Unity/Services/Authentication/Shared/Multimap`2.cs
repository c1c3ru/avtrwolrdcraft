namespace Unity.Services.Authentication.Shared;

[DefaultMember("Item")]
internal class Multimap : IDictionary<TKey, IList`1<TValue>>, ICollection<KeyValuePair`2<TKey, IList`1<TValue>>>, IEnumerable<KeyValuePair`2<TKey, IList`1<TValue>>>, IEnumerable
{
	private readonly Dictionary<TKey, IList`1<TValue>> _dictionary; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 36
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 8
	}

	public override IList<TValue> Item
	{
		 get { } //Length: 36
		 set { } //Length: 36
	}

	public override ICollection<TKey> Keys
	{
		 get { } //Length: 36
	}

	public override ICollection<IList`1<TValue>> Values
	{
		 get { } //Length: 36
	}

	public Multimap`2() { }

	public Multimap`2(IEqualityComparer<TKey> comparer) { }

	public void Add(Multimap<TKey, TValue> multimap) { }

	public void Add(TKey key, TValue value) { }

	public override void Add(TKey key, IList<TValue> value) { }

	public override void Add(KeyValuePair<TKey, IList`1<TValue>> item) { }

	public override void Clear() { }

	public override bool Contains(KeyValuePair<TKey, IList`1<TValue>> item) { }

	public override bool ContainsKey(TKey key) { }

	public void CopyTo(Array array, int index) { }

	public override void CopyTo(KeyValuePair<TKey, IList`1<TValue>>[] array, int arrayIndex) { }

	public override int get_Count() { }

	public override bool get_IsReadOnly() { }

	public override IList<TValue> get_Item(TKey key) { }

	public override ICollection<TKey> get_Keys() { }

	public override ICollection<IList`1<TValue>> get_Values() { }

	public override IEnumerator<KeyValuePair`2<TKey, IList`1<TValue>>> GetEnumerator() { }

	public override bool Remove(KeyValuePair<TKey, IList`1<TValue>> item) { }

	public override bool Remove(TKey key) { }

	public override void set_Item(TKey key, IList<TValue> value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	private bool TryAdd(TKey key, IList<TValue> value) { }

	public override bool TryGetValue(TKey key, out IList<TValue>& value) { }

	private bool TryRemove(TKey key, out IList<TValue>& value) { }

}

