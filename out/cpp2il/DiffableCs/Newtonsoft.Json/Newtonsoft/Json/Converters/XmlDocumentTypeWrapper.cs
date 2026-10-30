namespace Newtonsoft.Json.Converters;

[Nullable(0)]
[NullableContext(2)]
internal class XmlDocumentTypeWrapper : XmlNodeWrapper, IXmlDocumentType, IXmlNode
{
	[Nullable(1)]
	private readonly XmlDocumentType _documentType; //Field offset: 0x28

	public override string InternalSubset
	{
		 get { } //Length: 28
	}

	public virtual string LocalName
	{
		 get { } //Length: 64
	}

	[Nullable(1)]
	public override string Name
	{
		[NullableContext(1)]
		 get { } //Length: 32
	}

	public override string Public
	{
		 get { } //Length: 28
	}

	public override string System
	{
		 get { } //Length: 28
	}

	[NullableContext(1)]
	public XmlDocumentTypeWrapper(XmlDocumentType documentType) { }

	public override string get_InternalSubset() { }

	public virtual string get_LocalName() { }

	[NullableContext(1)]
	public override string get_Name() { }

	public override string get_Public() { }

	public override string get_System() { }

}

