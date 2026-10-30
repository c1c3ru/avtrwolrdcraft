namespace System.Xml;

public class XmlElement : XmlLinkedNode
{
	private XmlName name; //Field offset: 0x20
	private XmlAttributeCollection attributes; //Field offset: 0x28
	private XmlLinkedNode lastChild; //Field offset: 0x30

	public virtual XmlAttributeCollection Attributes
	{
		 get { } //Length: 316
	}

	public override bool HasAttributes
	{
		 get { } //Length: 40
	}

	public virtual string InnerText
	{
		 get { } //Length: 8
		 set { } //Length: 188
	}

	public virtual string InnerXml
	{
		 set { } //Length: 128
	}

	internal virtual bool IsContainer
	{
		internal get { } //Length: 8
	}

	public bool IsEmpty
	{
		 get { } //Length: 16
		 set { } //Length: 104
	}

	internal virtual XmlLinkedNode LastNode
	{
		internal get { } //Length: 16
		internal set { } //Length: 8
	}

	public virtual string LocalName
	{
		 get { } //Length: 28
	}

	public virtual string Name
	{
		 get { } //Length: 28
	}

	public virtual string NamespaceURI
	{
		 get { } //Length: 28
	}

	public virtual XmlNode NextSibling
	{
		 get { } //Length: 60
	}

	public virtual XmlNodeType NodeType
	{
		 get { } //Length: 8
	}

	public virtual XmlDocument OwnerDocument
	{
		 get { } //Length: 28
	}

	public virtual XmlNode ParentNode
	{
		 get { } //Length: 8
	}

	public virtual string Prefix
	{
		 get { } //Length: 28
		 set { } //Length: 172
	}

	public virtual IXmlSchemaInfo SchemaInfo
	{
		 get { } //Length: 8
	}

	internal XmlName XmlName
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	internal XmlElement(XmlName name, bool empty, XmlDocument doc) { }

	protected private XmlElement(string prefix, string localName, string namespaceURI, XmlDocument doc) { }

	internal virtual XmlNode AppendChildForLoad(XmlNode newChild, XmlDocument doc) { }

	public virtual XmlNode CloneNode(bool deep) { }

	public virtual XmlAttributeCollection get_Attributes() { }

	public override bool get_HasAttributes() { }

	public virtual string get_InnerText() { }

	internal virtual bool get_IsContainer() { }

	public bool get_IsEmpty() { }

	internal virtual XmlLinkedNode get_LastNode() { }

	public virtual string get_LocalName() { }

	public virtual string get_Name() { }

	public virtual string get_NamespaceURI() { }

	public virtual XmlNode get_NextSibling() { }

	public virtual XmlNodeType get_NodeType() { }

	public virtual XmlDocument get_OwnerDocument() { }

	public virtual XmlNode get_ParentNode() { }

	public virtual string get_Prefix() { }

	public virtual IXmlSchemaInfo get_SchemaInfo() { }

	internal XmlName get_XmlName() { }

	public override string GetAttribute(string localName, string namespaceURI) { }

	public override string GetAttribute(string name) { }

	public override XmlAttribute GetAttributeNode(string localName, string namespaceURI) { }

	public override XmlAttribute GetAttributeNode(string name) { }

	public override bool HasAttribute(string name) { }

	internal virtual bool IsValidChildType(XmlNodeType type) { }

	public virtual void RemoveAll() { }

	public override void RemoveAllAttributes() { }

	internal void RemoveAllChildren() { }

	public virtual void set_InnerText(string value) { }

	public virtual void set_InnerXml(string value) { }

	public void set_IsEmpty(bool value) { }

	internal virtual void set_LastNode(XmlLinkedNode value) { }

	public virtual void set_Prefix(string value) { }

	internal void set_XmlName(XmlName value) { }

	public override string SetAttribute(string localName, string namespaceURI, string value) { }

	public override void SetAttribute(string name, string value) { }

	public override XmlAttribute SetAttributeNode(XmlAttribute newAttr) { }

	public override XmlAttribute SetAttributeNode(string localName, string namespaceURI) { }

	internal virtual void SetParent(XmlNode node) { }

	public virtual void WriteContentTo(XmlWriter w) { }

	private static void WriteElementTo(XmlWriter writer, XmlElement e) { }

	private void WriteStartElement(XmlWriter w) { }

	public virtual void WriteTo(XmlWriter w) { }

}

