namespace System.Xml;

public class XmlProcessingInstruction : XmlLinkedNode
{
	private string target; //Field offset: 0x20
	private string data; //Field offset: 0x28

	public string Data
	{
		 set { } //Length: 196
	}

	public virtual string InnerText
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	public virtual string LocalName
	{
		 get { } //Length: 12
	}

	public virtual string Name
	{
		 get { } //Length: 84
	}

	public virtual XmlNodeType NodeType
	{
		 get { } //Length: 8
	}

	public virtual string Value
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	protected private XmlProcessingInstruction(string target, string data, XmlDocument doc) { }

	public virtual XmlNode CloneNode(bool deep) { }

	public virtual string get_InnerText() { }

	public virtual string get_LocalName() { }

	public virtual string get_Name() { }

	public virtual XmlNodeType get_NodeType() { }

	public virtual string get_Value() { }

	public void set_Data(string value) { }

	public virtual void set_InnerText(string value) { }

	public virtual void set_Value(string value) { }

	public virtual void WriteContentTo(XmlWriter w) { }

	public virtual void WriteTo(XmlWriter w) { }

}

