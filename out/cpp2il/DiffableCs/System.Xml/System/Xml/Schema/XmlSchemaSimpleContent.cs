namespace System.Xml.Schema;

public class XmlSchemaSimpleContent : XmlSchemaContentModel
{
	private XmlSchemaContent content; //Field offset: 0x50

	[XmlElement("restriction", typeof(XmlSchemaSimpleContentRestriction))]
	[XmlElement("extension", typeof(XmlSchemaSimpleContentExtension))]
	public virtual XmlSchemaContent Content
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public XmlSchemaSimpleContent() { }

	public virtual XmlSchemaContent get_Content() { }

	public virtual void set_Content(XmlSchemaContent value) { }

}

