namespace System.Xml.Schema;

public sealed class XmlSchemaCollectionEnumerator : IEnumerator
{
	private IDictionaryEnumerator enumerator; //Field offset: 0x10

	public XmlSchema Current
	{
		 get { } //Length: 216
	}

	internal XmlSchemaCollectionNode CurrentNode
	{
		internal get { } //Length: 212
	}

	private override object System.Collections.IEnumerator.Current
	{
		private get { } //Length: 4
	}

	internal XmlSchemaCollectionEnumerator(Hashtable collection) { }

	public XmlSchema get_Current() { }

	internal XmlSchemaCollectionNode get_CurrentNode() { }

	public bool MoveNext() { }

	private override object System.Collections.IEnumerator.get_Current() { }

	private override bool System.Collections.IEnumerator.MoveNext() { }

	private override void System.Collections.IEnumerator.Reset() { }

}

