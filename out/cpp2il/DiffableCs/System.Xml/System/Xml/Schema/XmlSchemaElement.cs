namespace System.Xml.Schema;

public class XmlSchemaElement : XmlSchemaParticle
{
	private bool isAbstract; //Field offset: 0x74
	private bool hasAbstractAttribute; //Field offset: 0x75
	private bool isNillable; //Field offset: 0x76
	private bool hasNillableAttribute; //Field offset: 0x77
	private bool isLocalTypeDerivationChecked; //Field offset: 0x78
	private XmlSchemaDerivationMethod block; //Field offset: 0x7C
	private XmlSchemaDerivationMethod final; //Field offset: 0x80
	private XmlSchemaForm form; //Field offset: 0x84
	private string defaultValue; //Field offset: 0x88
	private string fixedValue; //Field offset: 0x90
	private string name; //Field offset: 0x98
	private XmlQualifiedName refName; //Field offset: 0xA0
	private XmlQualifiedName substitutionGroup; //Field offset: 0xA8
	private XmlQualifiedName typeName; //Field offset: 0xB0
	private XmlSchemaType type; //Field offset: 0xB8
	private XmlQualifiedName qualifiedName; //Field offset: 0xC0
	private XmlSchemaType elementType; //Field offset: 0xC8
	private XmlSchemaDerivationMethod blockResolved; //Field offset: 0xD0
	private XmlSchemaDerivationMethod finalResolved; //Field offset: 0xD4
	private XmlSchemaObjectCollection constraints; //Field offset: 0xD8
	private SchemaElementDecl elementDecl; //Field offset: 0xE0

	[DefaultValue(XmlSchemaDerivationMethod::None (256))]
	[XmlAttribute("block")]
	public XmlSchemaDerivationMethod Block
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	[XmlIgnore]
	public XmlSchemaDerivationMethod BlockResolved
	{
		 get { } //Length: 8
	}

	[XmlElement("keyref", typeof(XmlSchemaKeyref))]
	[XmlElement("unique", typeof(XmlSchemaUnique))]
	[XmlElement("key", typeof(XmlSchemaKey))]
	public XmlSchemaObjectCollection Constraints
	{
		 get { } //Length: 112
	}

	[DefaultValue(null)]
	[XmlAttribute("default")]
	public string DefaultValue
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	internal SchemaElementDecl ElementDecl
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	[XmlIgnore]
	public XmlSchemaType ElementSchemaType
	{
		 get { } //Length: 8
	}

	[DefaultValue(XmlSchemaDerivationMethod::None (256))]
	[XmlAttribute("final")]
	public XmlSchemaDerivationMethod Final
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	[XmlIgnore]
	public XmlSchemaDerivationMethod FinalResolved
	{
		 get { } //Length: 8
	}

	[DefaultValue(null)]
	[XmlAttribute("fixed")]
	public string FixedValue
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	[DefaultValue(XmlSchemaForm::None (0))]
	[XmlAttribute("form")]
	public XmlSchemaForm Form
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	[XmlIgnore]
	internal bool HasAbstractAttribute
	{
		internal get { } //Length: 8
	}

	internal bool HasConstraints
	{
		internal get { } //Length: 36
	}

	[XmlIgnore]
	internal bool HasNillableAttribute
	{
		internal get { } //Length: 8
	}

	[DefaultValue(False)]
	[XmlAttribute("abstract")]
	public bool IsAbstract
	{
		 get { } //Length: 8
		 set { } //Length: 20
	}

	internal bool IsLocalTypeDerivationChecked
	{
		internal get { } //Length: 8
		internal set { } //Length: 12
	}

	[DefaultValue(False)]
	[XmlAttribute("nillable")]
	public bool IsNillable
	{
		 get { } //Length: 8
		 set { } //Length: 20
	}

	[DefaultValue(null)]
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
	internal virtual string NameString
	{
		internal get { } //Length: 32
	}

	[XmlIgnore]
	public XmlQualifiedName QualifiedName
	{
		 get { } //Length: 8
	}

	[XmlAttribute("ref")]
	public XmlQualifiedName RefName
	{
		 get { } //Length: 8
		 set { } //Length: 160
	}

	[XmlElement("simpleType", typeof(XmlSchemaSimpleType))]
	[XmlElement("complexType", typeof(XmlSchemaComplexType))]
	public XmlSchemaType SchemaType
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	[XmlAttribute("type")]
	public XmlQualifiedName SchemaTypeName
	{
		 get { } //Length: 8
		 set { } //Length: 160
	}

	[XmlAttribute("substitutionGroup")]
	public XmlQualifiedName SubstitutionGroup
	{
		 get { } //Length: 8
		 set { } //Length: 160
	}

	public XmlSchemaElement() { }

	internal virtual XmlSchemaObject Clone() { }

	internal XmlSchemaObject Clone(XmlSchema parentSchema) { }

	public XmlSchemaDerivationMethod get_Block() { }

	public XmlSchemaDerivationMethod get_BlockResolved() { }

	public XmlSchemaObjectCollection get_Constraints() { }

	public string get_DefaultValue() { }

	internal SchemaElementDecl get_ElementDecl() { }

	public XmlSchemaType get_ElementSchemaType() { }

	public XmlSchemaDerivationMethod get_Final() { }

	public XmlSchemaDerivationMethod get_FinalResolved() { }

	public string get_FixedValue() { }

	public XmlSchemaForm get_Form() { }

	internal bool get_HasAbstractAttribute() { }

	internal bool get_HasConstraints() { }

	internal bool get_HasNillableAttribute() { }

	public bool get_IsAbstract() { }

	internal bool get_IsLocalTypeDerivationChecked() { }

	public bool get_IsNillable() { }

	public string get_Name() { }

	internal virtual string get_NameAttribute() { }

	internal virtual string get_NameString() { }

	public XmlQualifiedName get_QualifiedName() { }

	public XmlQualifiedName get_RefName() { }

	public XmlSchemaType get_SchemaType() { }

	public XmlQualifiedName get_SchemaTypeName() { }

	public XmlQualifiedName get_SubstitutionGroup() { }

	public void set_Block(XmlSchemaDerivationMethod value) { }

	public void set_DefaultValue(string value) { }

	internal void set_ElementDecl(SchemaElementDecl value) { }

	public void set_Final(XmlSchemaDerivationMethod value) { }

	public void set_FixedValue(string value) { }

	public void set_Form(XmlSchemaForm value) { }

	public void set_IsAbstract(bool value) { }

	internal void set_IsLocalTypeDerivationChecked(bool value) { }

	public void set_IsNillable(bool value) { }

	public void set_Name(string value) { }

	internal virtual void set_NameAttribute(string value) { }

	public void set_RefName(XmlQualifiedName value) { }

	public void set_SchemaType(XmlSchemaType value) { }

	public void set_SchemaTypeName(XmlQualifiedName value) { }

	public void set_SubstitutionGroup(XmlQualifiedName value) { }

	internal void SetBlockResolved(XmlSchemaDerivationMethod value) { }

	internal void SetElementType(XmlSchemaType value) { }

	internal void SetFinalResolved(XmlSchemaDerivationMethod value) { }

	internal void SetQualifiedName(XmlQualifiedName value) { }

}

