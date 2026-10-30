namespace UnityEngine.ResourceManagement.Util;

internal struct LRUCache
{
	internal struct Entry : IEquatable<Entry<TKey, TValue>>
	{
		public LinkedListNode<Key<TKey, TValue>> lruNode; //Field offset: 0x0
		public TValue Value; //Field offset: 0x0

		public override bool Equals(Entry<TKey, TValue> other) { }

		public virtual int GetHashCode() { }

	}

	internal struct Key : IEquatable<Key<TKey, TValue>>
	{
		private static Type typeType; //Field offset: 0x0
		public TKey key; //Field offset: 0x0
		public Type type; //Field offset: 0x0

		private static Key() { }

		public Key(TKey k, Type t) { }

		public virtual int GetHashCode() { }

		private override bool System.IEquatable<UnityEngine.ResourceManagement.Util.LRUCache<TKey,TValue>.Key>.Equals(Key<TKey, TValue> other) { }

	}

	public int requestHits; //Field offset: 0x0
	public int requestCount; //Field offset: 0x0
	private int entryLimit; //Field offset: 0x0
	private Dictionary<Key<TKey, TValue>, Entry<TKey, TValue>> cache; //Field offset: 0x0
	private LinkedList<Key<TKey, TValue>> lru; //Field offset: 0x0

	public LRUCache`2(int limit) { }

	public bool TryAdd(TKey id, TValue obj) { }

	public bool TryGet(Type type, TKey id, out TValue val) { }

}

