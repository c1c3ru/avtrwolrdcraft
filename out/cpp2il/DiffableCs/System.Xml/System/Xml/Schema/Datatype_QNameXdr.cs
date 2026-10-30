namespace System.Xml.Schema;

internal class Datatype_QNameXdr : Datatype_anySimpleType
{
	private static readonly Type atomicValueType; //Field offset: 0x0
	private static readonly Type listValueType; //Field offset: 0x8

	internal virtual Type ListValueType
	{
		internal get { } //Length: 88
	}

	public virtual XmlTokenizedType TokenizedType
	{
		 get { } //Length: 8
	}

	public virtual Type ValueType
	{
		 get { } //Length: 88
	}

	private static Datatype_QNameXdr() { }

	public Datatype_QNameXdr() { }

	internal virtual Type get_ListValueType() { }

	public virtual XmlTokenizedType get_TokenizedType() { }

	public virtual Type get_ValueType() { }

	public virtual object ParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr) { }

}

