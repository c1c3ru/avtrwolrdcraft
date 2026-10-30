namespace System.Xml.Serialization;

[AttributeUsage(9244)]
public class XmlRootAttribute : Attribute
{
	private string dataType; //Field offset: 0x10
	private string elementName; //Field offset: 0x18
	private bool isNullable; //Field offset: 0x20
	private string ns; //Field offset: 0x28

	public string DataType
	{
		 get { } //Length: 84
		 set { } //Length: 8
	}

	public string ElementName
	{
		 get { } //Length: 84
		 set { } //Length: 8
	}

	public bool IsNullable
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public string Namespace
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public XmlRootAttribute() { }

	public XmlRootAttribute(string elementName) { }

	internal void AddKeyHash(StringBuilder sb) { }

	public string get_DataType() { }

	public string get_ElementName() { }

	public bool get_IsNullable() { }

	public string get_Namespace() { }

	public void set_DataType(string value) { }

	public void set_ElementName(string value) { }

	public void set_IsNullable(bool value) { }

	public void set_Namespace(string value) { }

}

