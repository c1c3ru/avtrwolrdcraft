namespace System.Xml;

public class XmlDocumentFragment : XmlNode
{
	private XmlLinkedNode lastChild; //Field offset: 0x18

	public virtual string InnerXml
	{
		 set { } //Length: 140
	}

	internal virtual bool IsContainer
	{
		internal get { } //Length: 8
	}

	internal virtual XmlLinkedNode LastNode
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	public virtual string LocalName
	{
		 get { } //Length: 40
	}

	public virtual string Name
	{
		 get { } //Length: 40
	}

	public virtual XmlNodeType NodeType
	{
		 get { } //Length: 8
	}

	public virtual XmlDocument OwnerDocument
	{
		 get { } //Length: 120
	}

	public virtual XmlNode ParentNode
	{
		 get { } //Length: 8
	}

	protected private XmlDocumentFragment(XmlDocument ownerDocument) { }

	internal virtual bool CanInsertAfter(XmlNode newChild, XmlNode refChild) { }

	internal virtual bool CanInsertBefore(XmlNode newChild, XmlNode refChild) { }

	public virtual XmlNode CloneNode(bool deep) { }

	internal virtual bool get_IsContainer() { }

	internal virtual XmlLinkedNode get_LastNode() { }

	public virtual string get_LocalName() { }

	public virtual string get_Name() { }

	public virtual XmlNodeType get_NodeType() { }

	public virtual XmlDocument get_OwnerDocument() { }

	public virtual XmlNode get_ParentNode() { }

	internal virtual bool IsValidChildType(XmlNodeType type) { }

	public virtual void set_InnerXml(string value) { }

	internal virtual void set_LastNode(XmlLinkedNode value) { }

	public virtual void WriteContentTo(XmlWriter w) { }

	public virtual void WriteTo(XmlWriter w) { }

}

