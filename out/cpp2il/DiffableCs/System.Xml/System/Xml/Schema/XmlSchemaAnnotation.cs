namespace System.Xml.Schema;

public class XmlSchemaAnnotation : XmlSchemaObject
{
	private string id; //Field offset: 0x38
	private XmlSchemaObjectCollection items; //Field offset: 0x40
	private XmlAttribute[] moreAttributes; //Field offset: 0x48

	[XmlAttribute("id", DataType = "ID")]
	public string Id
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	[XmlIgnore]
	internal virtual string IdAttribute
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	[XmlElement("documentation", typeof(XmlSchemaDocumentation))]
	[XmlElement("appinfo", typeof(XmlSchemaAppInfo))]
	public XmlSchemaObjectCollection Items
	{
		 get { } //Length: 8
	}

	public XmlSchemaAnnotation() { }

	public string get_Id() { }

	internal virtual string get_IdAttribute() { }

	public XmlSchemaObjectCollection get_Items() { }

	public void set_Id(string value) { }

	internal virtual void set_IdAttribute(string value) { }

	internal virtual void SetUnhandledAttributes(XmlAttribute[] moreAttributes) { }

}

