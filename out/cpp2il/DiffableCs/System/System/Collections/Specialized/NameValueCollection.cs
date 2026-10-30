namespace System.Collections.Specialized;

[DefaultMember("Item")]
public class NameValueCollection : NameObjectCollectionBase
{
	private String[] _all; //Field offset: 0x58
	private String[] _allKeys; //Field offset: 0x60

	public override String[] AllKeys
	{
		 get { } //Length: 64
	}

	public string Item
	{
		 get { } //Length: 16
		 set { } //Length: 16
	}

	public NameValueCollection() { }

	protected NameValueCollection(SerializationInfo info, StreamingContext context) { }

	public NameValueCollection(int capacity, IEqualityComparer equalityComparer) { }

	internal NameValueCollection(DBNull dummy) { }

	public NameValueCollection(NameValueCollection col) { }

	public NameValueCollection(int capacity) { }

	public void Add(NameValueCollection c) { }

	public override void Add(string name, string value) { }

	public override void Clear() { }

	public override string Get(string name) { }

	public override string Get(int index) { }

	public override String[] get_AllKeys() { }

	public string get_Item(string name) { }

	private static string GetAsOneString(ArrayList list) { }

	private static String[] GetAsStringArray(ArrayList list) { }

	public override string GetKey(int index) { }

	public override String[] GetValues(int index) { }

	public override String[] GetValues(string name) { }

	protected void InvalidateCachedArrays() { }

	public override void Remove(string name) { }

	public override void Set(string name, string value) { }

	public void set_Item(string name, string value) { }

}

