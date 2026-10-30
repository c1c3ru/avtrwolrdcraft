namespace System.Collections.Specialized;

[DefaultMember("Item")]
public class StringDictionary : IEnumerable
{
	internal Hashtable contents; //Field offset: 0x10

	public override string Item
	{
		 get { } //Length: 216
	}

	public StringDictionary() { }

	public override string get_Item(string key) { }

	public override IEnumerator GetEnumerator() { }

}

