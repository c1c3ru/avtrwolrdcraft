namespace System.Xml.Schema;

public class ValidationEventArgs : EventArgs
{
	private XmlSchemaException ex; //Field offset: 0x10
	private XmlSeverityType severity; //Field offset: 0x18

	public XmlSchemaException Exception
	{
		 get { } //Length: 8
	}

	public XmlSeverityType Severity
	{
		 get { } //Length: 8
	}

	internal ValidationEventArgs(XmlSchemaException ex) { }

	internal ValidationEventArgs(XmlSchemaException ex, XmlSeverityType severity) { }

	public XmlSchemaException get_Exception() { }

	public XmlSeverityType get_Severity() { }

}

