namespace System.Xml.Schema;

public class XmlSchemaGroup : XmlSchemaAnnotated
{
	private string name; //Field offset: 0x50
	private XmlSchemaGroupBase particle; //Field offset: 0x58
	private XmlSchemaParticle canonicalParticle; //Field offset: 0x60
	private XmlQualifiedName qname; //Field offset: 0x68
	private XmlSchemaGroup redefined; //Field offset: 0x70
	private int selfReferenceCount; //Field offset: 0x78

	[XmlIgnore]
	internal XmlSchemaParticle CanonicalParticle
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

	[XmlElement("sequence", typeof(XmlSchemaSequence))]
	[XmlElement("choice", typeof(XmlSchemaChoice))]
	[XmlElement("all", typeof(XmlSchemaAll))]
	public XmlSchemaGroupBase Particle
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	[XmlIgnore]
	public XmlQualifiedName QualifiedName
	{
		 get { } //Length: 8
	}

	[XmlIgnore]
	internal XmlSchemaGroup Redefined
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	[XmlIgnore]
	internal int SelfReferenceCount
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	public XmlSchemaGroup() { }

	internal virtual XmlSchemaObject Clone() { }

	internal XmlSchemaObject Clone(XmlSchema parentSchema) { }

	internal XmlSchemaParticle get_CanonicalParticle() { }

	public string get_Name() { }

	internal virtual string get_NameAttribute() { }

	public XmlSchemaGroupBase get_Particle() { }

	public XmlQualifiedName get_QualifiedName() { }

	internal XmlSchemaGroup get_Redefined() { }

	internal int get_SelfReferenceCount() { }

	internal void set_CanonicalParticle(XmlSchemaParticle value) { }

	public void set_Name(string value) { }

	internal virtual void set_NameAttribute(string value) { }

	public void set_Particle(XmlSchemaGroupBase value) { }

	internal void set_Redefined(XmlSchemaGroup value) { }

	internal void set_SelfReferenceCount(int value) { }

	internal void SetQualifiedName(XmlQualifiedName value) { }

}

