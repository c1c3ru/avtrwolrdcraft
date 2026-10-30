namespace System.Xml.Schema;

public abstract class XmlSchemaObject
{
	private int lineNum; //Field offset: 0x10
	private int linePos; //Field offset: 0x14
	private string sourceUri; //Field offset: 0x18
	private XmlSerializerNamespaces namespaces; //Field offset: 0x20
	private XmlSchemaObject parent; //Field offset: 0x28
	private bool isProcessing; //Field offset: 0x30

	[XmlIgnore]
	internal override string IdAttribute
	{
		internal get { } //Length: 8
		internal set { } //Length: 4
	}

	[XmlIgnore]
	internal bool IsProcessing
	{
		internal get { } //Length: 8
		internal set { } //Length: 12
	}

	[XmlIgnore]
	public int LineNumber
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	[XmlIgnore]
	public int LinePosition
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	[XmlIgnore]
	internal override string NameAttribute
	{
		internal get { } //Length: 8
		internal set { } //Length: 4
	}

	[XmlNamespaceDeclarations]
	public XmlSerializerNamespaces Namespaces
	{
		 get { } //Length: 112
		 set { } //Length: 8
	}

	[XmlIgnore]
	public XmlSchemaObject Parent
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	[XmlIgnore]
	public string SourceUri
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	protected XmlSchemaObject() { }

	internal override void AddAnnotation(XmlSchemaAnnotation annotation) { }

	internal override XmlSchemaObject Clone() { }

	internal override string get_IdAttribute() { }

	internal bool get_IsProcessing() { }

	public int get_LineNumber() { }

	public int get_LinePosition() { }

	internal override string get_NameAttribute() { }

	public XmlSerializerNamespaces get_Namespaces() { }

	public XmlSchemaObject get_Parent() { }

	public string get_SourceUri() { }

	internal override void OnAdd(XmlSchemaObjectCollection container, object item) { }

	internal override void OnClear(XmlSchemaObjectCollection container) { }

	internal override void OnRemove(XmlSchemaObjectCollection container, object item) { }

	internal override void set_IdAttribute(string value) { }

	internal void set_IsProcessing(bool value) { }

	public void set_LineNumber(int value) { }

	public void set_LinePosition(int value) { }

	internal override void set_NameAttribute(string value) { }

	public void set_Namespaces(XmlSerializerNamespaces value) { }

	public void set_Parent(XmlSchemaObject value) { }

	public void set_SourceUri(string value) { }

	internal override void SetUnhandledAttributes(XmlAttribute[] moreAttributes) { }

}

