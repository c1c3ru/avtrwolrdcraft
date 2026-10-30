namespace System.Xml.Serialization;

[AttributeUsage(1036)]
public sealed class XmlSchemaProviderAttribute : Attribute
{
	private string _methodName; //Field offset: 0x10
	private bool _isAny; //Field offset: 0x18

	public bool IsAny
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public string MethodName
	{
		 get { } //Length: 8
	}

	public XmlSchemaProviderAttribute(string methodName) { }

	public bool get_IsAny() { }

	public string get_MethodName() { }

	public void set_IsAny(bool value) { }

}

