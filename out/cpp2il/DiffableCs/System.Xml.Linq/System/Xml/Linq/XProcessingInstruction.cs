namespace System.Xml.Linq;

public class XProcessingInstruction : XNode
{
	internal string target; //Field offset: 0x28
	internal string data; //Field offset: 0x30

	public string Data
	{
		 get { } //Length: 8
		 set { } //Length: 268
	}

	public virtual XmlNodeType NodeType
	{
		 get { } //Length: 8
	}

	public string Target
	{
		 get { } //Length: 8
	}

	public XProcessingInstruction(string target, string data) { }

	public XProcessingInstruction(XProcessingInstruction other) { }

	internal virtual XNode CloneNode() { }

	public string get_Data() { }

	public virtual XmlNodeType get_NodeType() { }

	public string get_Target() { }

	public void set_Data(string value) { }

	private static void ValidateName(string name) { }

	public virtual void WriteTo(XmlWriter writer) { }

}

