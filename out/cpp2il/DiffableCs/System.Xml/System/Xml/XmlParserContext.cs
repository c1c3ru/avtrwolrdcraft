namespace System.Xml;

public class XmlParserContext
{
	private XmlNameTable _nt; //Field offset: 0x10
	private XmlNamespaceManager _nsMgr; //Field offset: 0x18
	private string _docTypeName; //Field offset: 0x20
	private string _pubId; //Field offset: 0x28
	private string _sysId; //Field offset: 0x30
	private string _internalSubset; //Field offset: 0x38
	private string _xmlLang; //Field offset: 0x40
	private XmlSpace _xmlSpace; //Field offset: 0x48
	private string _baseURI; //Field offset: 0x50
	private Encoding _encoding; //Field offset: 0x58

	public string BaseURI
	{
		 get { } //Length: 8
	}

	public string DocTypeName
	{
		 get { } //Length: 8
	}

	public Encoding Encoding
	{
		 get { } //Length: 8
	}

	internal bool HasDtdInfo
	{
		internal get { } //Length: 156
	}

	public string InternalSubset
	{
		 get { } //Length: 8
	}

	public XmlNamespaceManager NamespaceManager
	{
		 get { } //Length: 8
	}

	public XmlNameTable NameTable
	{
		 get { } //Length: 8
	}

	public string PublicId
	{
		 get { } //Length: 8
	}

	public string SystemId
	{
		 get { } //Length: 8
	}

	public string XmlLang
	{
		 get { } //Length: 8
	}

	public XmlSpace XmlSpace
	{
		 get { } //Length: 8
	}

	public XmlParserContext(XmlNameTable nt, XmlNamespaceManager nsMgr, string xmlLang, XmlSpace xmlSpace) { }

	public XmlParserContext(XmlNameTable nt, XmlNamespaceManager nsMgr, string docTypeName, string pubId, string sysId, string internalSubset, string baseURI, string xmlLang, XmlSpace xmlSpace) { }

	public XmlParserContext(XmlNameTable nt, XmlNamespaceManager nsMgr, string docTypeName, string pubId, string sysId, string internalSubset, string baseURI, string xmlLang, XmlSpace xmlSpace, Encoding enc) { }

	public string get_BaseURI() { }

	public string get_DocTypeName() { }

	public Encoding get_Encoding() { }

	internal bool get_HasDtdInfo() { }

	public string get_InternalSubset() { }

	public XmlNamespaceManager get_NamespaceManager() { }

	public XmlNameTable get_NameTable() { }

	public string get_PublicId() { }

	public string get_SystemId() { }

	public string get_XmlLang() { }

	public XmlSpace get_XmlSpace() { }

}

