namespace System.Xml;

public class XmlDocumentType : XmlLinkedNode
{
	private string name; //Field offset: 0x20
	private string publicId; //Field offset: 0x28
	private string systemId; //Field offset: 0x30
	private string internalSubset; //Field offset: 0x38
	private bool namespaces; //Field offset: 0x40
	private XmlNamedNodeMap entities; //Field offset: 0x48
	private XmlNamedNodeMap notations; //Field offset: 0x50
	private SchemaInfo schemaInfo; //Field offset: 0x58

	internal SchemaInfo DtdSchemaInfo
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	public XmlNamedNodeMap Entities
	{
		 get { } //Length: 120
	}

	public string InternalSubset
	{
		 get { } //Length: 8
	}

	public virtual bool IsReadOnly
	{
		 get { } //Length: 8
	}

	public virtual string LocalName
	{
		 get { } //Length: 8
	}

	public virtual string Name
	{
		 get { } //Length: 8
	}

	public virtual XmlNodeType NodeType
	{
		 get { } //Length: 8
	}

	public XmlNamedNodeMap Notations
	{
		 get { } //Length: 120
	}

	internal bool ParseWithNamespaces
	{
		internal get { } //Length: 8
	}

	public string PublicId
	{
		 get { } //Length: 8
	}

	public string SystemId
	{
		 get { } //Length: 8
	}

	protected private XmlDocumentType(string name, string publicId, string systemId, string internalSubset, XmlDocument doc) { }

	public virtual XmlNode CloneNode(bool deep) { }

	internal SchemaInfo get_DtdSchemaInfo() { }

	public XmlNamedNodeMap get_Entities() { }

	public string get_InternalSubset() { }

	public virtual bool get_IsReadOnly() { }

	public virtual string get_LocalName() { }

	public virtual string get_Name() { }

	public virtual XmlNodeType get_NodeType() { }

	public XmlNamedNodeMap get_Notations() { }

	internal bool get_ParseWithNamespaces() { }

	public string get_PublicId() { }

	public string get_SystemId() { }

	internal void set_DtdSchemaInfo(SchemaInfo value) { }

	public virtual void WriteContentTo(XmlWriter w) { }

	public virtual void WriteTo(XmlWriter w) { }

}

