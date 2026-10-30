namespace System.Xml;

public class XmlSignificantWhitespace : XmlCharacterData
{

	internal virtual bool IsText
	{
		internal get { } //Length: 8
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

	public virtual XmlNode ParentNode
	{
		 get { } //Length: 136
	}

	public virtual string Value
	{
		 get { } //Length: 16
		 set { } //Length: 140
	}

	protected private XmlSignificantWhitespace(string strData, XmlDocument doc) { }

	public virtual XmlNode CloneNode(bool deep) { }

	internal virtual bool get_IsText() { }

	public virtual string get_LocalName() { }

	public virtual string get_Name() { }

	public virtual XmlNodeType get_NodeType() { }

	public virtual XmlNode get_ParentNode() { }

	public virtual string get_Value() { }

	public virtual void set_Value(string value) { }

	public virtual void WriteContentTo(XmlWriter w) { }

	public virtual void WriteTo(XmlWriter w) { }

}

