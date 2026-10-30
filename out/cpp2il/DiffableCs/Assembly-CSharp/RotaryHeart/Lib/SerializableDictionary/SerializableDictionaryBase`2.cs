namespace RotaryHeart.Lib.SerializableDictionary;

[DefaultMember("Item")]
public class SerializableDictionaryBase : DrawableDictionary, IDictionary<TKey, TValue>, ICollection<KeyValuePair`2<TKey, TValue>>, IEnumerable<KeyValuePair`2<TKey, TValue>>, IEnumerable, ISerializationCallbackReceiver
{
	private static readonly Dictionary<TKey, TValue> _staticEmptyDict; //Field offset: 0x0
	private Dictionary<TKey, TValue> _dict; //Field offset: 0x0
	[SerializeField]
	private List<TKey> _keyValues; //Field offset: 0x0
	[SerializeField]
	private TKey[] _keys; //Field offset: 0x0
	[SerializeField]
	private TValue[] _values; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 28
	}

	public override TValue Item
	{
		 get { } //Length: 84
		 set { } //Length: 148
	}

	public override ICollection<TKey> Keys
	{
		 get { } //Length: 124
	}

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.IsReadOnly
	{
		private get { } //Length: 8
	}

	public override ICollection<TValue> Values
	{
		 get { } //Length: 124
	}

	private static SerializableDictionaryBase`2() { }

	public SerializableDictionaryBase`2() { }

	public override void Add(TKey key, TValue value) { }

	public override void Clear() { }

	public override bool ContainsKey(TKey key) { }

	public void CopyFrom(IDictionary<TKey, TValue> src) { }

	public override int get_Count() { }

	public override TValue get_Item(TKey key) { }

	public override ICollection<TKey> get_Keys() { }

	public override ICollection<TValue> get_Values() { }

	public Enumerator<TKey, TValue> GetEnumerator() { }

	public override bool Remove(TKey key) { }

	public override void set_Item(TKey key, TValue value) { }

	private override void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Add(KeyValuePair<TKey, TValue> item) { }

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Contains(KeyValuePair<TKey, TValue> item) { }

	private override void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) { }

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.get_IsReadOnly() { }

	private override bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Remove(KeyValuePair<TKey, TValue> item) { }

	private override IEnumerator<KeyValuePair`2<TKey, TValue>> System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public override bool TryGetValue(TKey key, out TValue value) { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize() { }

}

