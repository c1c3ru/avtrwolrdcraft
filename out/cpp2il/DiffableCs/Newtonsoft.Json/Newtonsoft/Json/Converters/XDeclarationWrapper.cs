namespace Newtonsoft.Json.Converters;

[Nullable(0)]
[NullableContext(2)]
internal class XDeclarationWrapper : XObjectWrapper, IXmlDeclaration, IXmlNode
{
	[CompilerGenerated]
	[Nullable(1)]
	private readonly XDeclaration <Declaration>k__BackingField; //Field offset: 0x18

	[Nullable(1)]
	internal XDeclaration Declaration
	{
		[CompilerGenerated]
		[NullableContext(1)]
		internal get { } //Length: 8
	}

	public override string Encoding
	{
		 get { } //Length: 28
		 set { } //Length: 28
	}

	public virtual XmlNodeType NodeType
	{
		 get { } //Length: 8
	}

	public override string Standalone
	{
		 get { } //Length: 28
		 set { } //Length: 28
	}

	public override string Version
	{
		 get { } //Length: 28
	}

	[NullableContext(1)]
	public XDeclarationWrapper(XDeclaration declaration) { }

	[CompilerGenerated]
	[NullableContext(1)]
	internal XDeclaration get_Declaration() { }

	public override string get_Encoding() { }

	public virtual XmlNodeType get_NodeType() { }

	public override string get_Standalone() { }

	public override string get_Version() { }

	public override void set_Encoding(string value) { }

	public override void set_Standalone(string value) { }

}

