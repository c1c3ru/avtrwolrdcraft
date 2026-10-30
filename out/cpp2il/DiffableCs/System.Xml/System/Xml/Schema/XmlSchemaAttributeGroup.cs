namespace System.Xml.Schema;

public class XmlSchemaAttributeGroup : XmlSchemaAnnotated
{
	private string name; //Field offset: 0x50
	private XmlSchemaObjectCollection attributes; //Field offset: 0x58
	private XmlSchemaAnyAttribute anyAttribute; //Field offset: 0x60
	private XmlQualifiedName qname; //Field offset: 0x68
	private XmlSchemaAttributeGroup redefined; //Field offset: 0x70
	private XmlSchemaObjectTable attributeUses; //Field offset: 0x78
	private XmlSchemaAnyAttribute attributeWildcard; //Field offset: 0x80
	private int selfReferenceCount; //Field offset: 0x88

	[XmlElement("anyAttribute")]
	public XmlSchemaAnyAttribute AnyAttribute
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	[XmlElement("attribute", typeof(XmlSchemaAttribute))]
	[XmlElement("attributeGroup", typeof(XmlSchemaAttributeGroupRef))]
	public XmlSchemaObjectCollection Attributes
	{
		 get { } //Length: 8
	}

	[XmlIgnore]
	internal XmlSchemaObjectTable AttributeUses
	{
		internal get { } //Length: 112
	}

	[XmlIgnore]
	internal XmlSchemaAnyAttribute AttributeWildcard
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	[XmlAttribute("name")]
	public string Name
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	[XmlIgnore]
	internal virtual string NameAttribute
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	[XmlIgnore]
	public XmlQualifiedName QualifiedName
	{
		 get { } //Length: 8
	}

	[XmlIgnore]
	internal XmlSchemaAttributeGroup Redefined
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	[XmlIgnore]
	public XmlSchemaAttributeGroup RedefinedAttributeGroup
	{
		 get { } //Length: 8
	}

	[XmlIgnore]
	internal int SelfReferenceCount
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	public XmlSchemaAttributeGroup() { }

	internal virtual XmlSchemaObject Clone() { }

	public XmlSchemaAnyAttribute get_AnyAttribute() { }

	public XmlSchemaObjectCollection get_Attributes() { }

	internal XmlSchemaObjectTable get_AttributeUses() { }

	internal XmlSchemaAnyAttribute get_AttributeWildcard() { }

	public string get_Name() { }

	internal virtual string get_NameAttribute() { }

	public XmlQualifiedName get_QualifiedName() { }

	internal XmlSchemaAttributeGroup get_Redefined() { }

	public XmlSchemaAttributeGroup get_RedefinedAttributeGroup() { }

	internal int get_SelfReferenceCount() { }

	public void set_AnyAttribute(XmlSchemaAnyAttribute value) { }

	internal void set_AttributeWildcard(XmlSchemaAnyAttribute value) { }

	public void set_Name(string value) { }

	internal virtual void set_NameAttribute(string value) { }

	internal void set_Redefined(XmlSchemaAttributeGroup value) { }

	internal void set_SelfReferenceCount(int value) { }

	internal void SetQualifiedName(XmlQualifiedName value) { }

}

