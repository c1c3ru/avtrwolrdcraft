namespace System.Collections.Specialized;

public abstract class NameObjectCollectionBase : ICollection, IEnumerable, ISerializable, IDeserializationCallback
{
	[DefaultMember("Item")]
	internal class KeysCollection : ICollection, IEnumerable
	{
		private NameObjectCollectionBase _coll; //Field offset: 0x10

		public override int Count
		{
			 get { } //Length: 36
		}

		private override bool System.Collections.ICollection.IsSynchronized
		{
			private get { } //Length: 8
		}

		private override object System.Collections.ICollection.SyncRoot
		{
			private get { } //Length: 164
		}

		internal KeysCollection(NameObjectCollectionBase coll) { }

		internal KeysCollection() { }

		public override int get_Count() { }

		public override IEnumerator GetEnumerator() { }

		private override void System.Collections.ICollection.CopyTo(Array array, int index) { }

		private override bool System.Collections.ICollection.get_IsSynchronized() { }

		private override object System.Collections.ICollection.get_SyncRoot() { }

	}

	public class NameObjectEntry
	{
		internal string Key; //Field offset: 0x10
		internal object Value; //Field offset: 0x18

		internal NameObjectEntry(string name, object value) { }

	}

	public class NameObjectKeysEnumerator : IEnumerator
	{
		private int _pos; //Field offset: 0x10
		private NameObjectCollectionBase _coll; //Field offset: 0x18
		private int _version; //Field offset: 0x20

		public override object Current
		{
			 get { } //Length: 160
		}

		internal NameObjectKeysEnumerator(NameObjectCollectionBase coll) { }

		public override object get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

	}

	private static StringComparer defaultComparer; //Field offset: 0x0
	private bool _readOnly; //Field offset: 0x10
	private ArrayList _entriesArray; //Field offset: 0x18
	private IEqualityComparer _keyComparer; //Field offset: 0x20
	private Hashtable _entriesTable; //Field offset: 0x28
	private NameObjectEntry _nullKeyEntry; //Field offset: 0x30
	private KeysCollection _keys; //Field offset: 0x38
	private SerializationInfo _serializationInfo; //Field offset: 0x40
	private int _version; //Field offset: 0x48
	private object _syncRoot; //Field offset: 0x50

	internal IEqualityComparer Comparer
	{
		internal get { } //Length: 8
	}

	public override int Count
	{
		 get { } //Length: 36
	}

	protected bool IsReadOnly
	{
		 get { } //Length: 8
	}

	public override KeysCollection Keys
	{
		 get { } //Length: 120
	}

	private override bool System.Collections.ICollection.IsSynchronized
	{
		private get { } //Length: 8
	}

	private override object System.Collections.ICollection.SyncRoot
	{
		private get { } //Length: 116
	}

	private static NameObjectCollectionBase() { }

	protected NameObjectCollectionBase(SerializationInfo info, StreamingContext context) { }

	internal NameObjectCollectionBase(DBNull dummy) { }

	protected NameObjectCollectionBase() { }

	protected NameObjectCollectionBase(int capacity, IEqualityComparer equalityComparer) { }

	protected NameObjectCollectionBase(IEqualityComparer equalityComparer) { }

	protected NameObjectCollectionBase(int capacity) { }

	protected void BaseAdd(string name, object value) { }

	protected void BaseClear() { }

	protected object BaseGet(int index) { }

	protected object BaseGet(string name) { }

	protected String[] BaseGetAllKeys() { }

	protected string BaseGetKey(int index) { }

	protected void BaseRemove(string name) { }

	protected void BaseSet(string name, object value) { }

	private NameObjectEntry FindEntry(string key) { }

	internal IEqualityComparer get_Comparer() { }

	public override int get_Count() { }

	protected bool get_IsReadOnly() { }

	public override KeysCollection get_Keys() { }

	public override IEnumerator GetEnumerator() { }

	public override void GetObjectData(SerializationInfo info, StreamingContext context) { }

	public override void OnDeserialization(object sender) { }

	private void Reset(int capacity) { }

	private void Reset() { }

	private override void System.Collections.ICollection.CopyTo(Array array, int index) { }

	private override bool System.Collections.ICollection.get_IsSynchronized() { }

	private override object System.Collections.ICollection.get_SyncRoot() { }

}

