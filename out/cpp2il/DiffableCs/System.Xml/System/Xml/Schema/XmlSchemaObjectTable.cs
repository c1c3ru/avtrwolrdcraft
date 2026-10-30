namespace System.Xml.Schema;

[DefaultMember("Item")]
public class XmlSchemaObjectTable
{
	public enum EnumeratorType
	{
		Keys = 0,
		Values = 1,
		DictionaryEntry = 2,
	}

	public class ValuesCollection : ICollection, IEnumerable
	{
		private List<XmlSchemaObjectEntry> entries; //Field offset: 0x10
		private int size; //Field offset: 0x18

		public override int Count
		{
			 get { } //Length: 8
		}

		public override bool IsSynchronized
		{
			 get { } //Length: 164
		}

		public override object SyncRoot
		{
			 get { } //Length: 164
		}

		internal ValuesCollection(List<XmlSchemaObjectEntry> entries, int size) { }

		public override void CopyTo(Array array, int arrayIndex) { }

		public override int get_Count() { }

		public override bool get_IsSynchronized() { }

		public override object get_SyncRoot() { }

		public override IEnumerator GetEnumerator() { }

	}

	public struct XmlSchemaObjectEntry
	{
		internal XmlQualifiedName qname; //Field offset: 0x0
		internal XmlSchemaObject xso; //Field offset: 0x8

		public XmlSchemaObjectEntry(XmlQualifiedName name, XmlSchemaObject value) { }

	}

	public class XSODictionaryEnumerator : XSOEnumerator, IDictionaryEnumerator, IEnumerator
	{

		public override DictionaryEntry Entry
		{
			 get { } //Length: 332
		}

		public override object Key
		{
			 get { } //Length: 304
		}

		public override object Value
		{
			 get { } //Length: 304
		}

		internal XSODictionaryEnumerator(List<XmlSchemaObjectEntry> entries, int size, EnumeratorType enumType) { }

		public override DictionaryEntry get_Entry() { }

		public override object get_Key() { }

		public override object get_Value() { }

	}

	public class XSOEnumerator : IEnumerator
	{
		private List<XmlSchemaObjectEntry> entries; //Field offset: 0x10
		private EnumeratorType enumType; //Field offset: 0x18
		protected int currentIndex; //Field offset: 0x1C
		protected int size; //Field offset: 0x20
		protected XmlQualifiedName currentKey; //Field offset: 0x28
		protected XmlSchemaObject currentValue; //Field offset: 0x30

		public override object Current
		{
			 get { } //Length: 440
		}

		internal XSOEnumerator(List<XmlSchemaObjectEntry> entries, int size, EnumeratorType enumType) { }

		public override object get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

	}

	private Dictionary<XmlQualifiedName, XmlSchemaObject> table; //Field offset: 0x10
	private List<XmlSchemaObjectEntry> entries; //Field offset: 0x18

	public int Count
	{
		 get { } //Length: 80
	}

	public XmlSchemaObject Item
	{
		 get { } //Length: 120
	}

	public ICollection Values
	{
		 get { } //Length: 160
	}

	internal XmlSchemaObjectTable() { }

	internal void Add(XmlQualifiedName name, XmlSchemaObject value) { }

	internal void Clear() { }

	public bool Contains(XmlQualifiedName name) { }

	private int FindIndexByValue(XmlSchemaObject xso) { }

	public int get_Count() { }

	public XmlSchemaObject get_Item(XmlQualifiedName name) { }

	public ICollection get_Values() { }

	public IDictionaryEnumerator GetEnumerator() { }

	internal void Insert(XmlQualifiedName name, XmlSchemaObject value) { }

	internal void Remove(XmlQualifiedName name) { }

	internal void Replace(XmlQualifiedName name, XmlSchemaObject value) { }

}

