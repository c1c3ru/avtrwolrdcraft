namespace MS.Internal.Xml.Cache;

internal struct XPathNode
{
	private XPathNodeInfoAtom _info; //Field offset: 0x0
	private ushort _idxSibling; //Field offset: 0x8
	private ushort _idxParent; //Field offset: 0xA
	private ushort _idxSimilar; //Field offset: 0xC
	private ushort _posOffset; //Field offset: 0xE
	private uint _props; //Field offset: 0x10
	private string _value; //Field offset: 0x18

	public int CollapsedLinePosition
	{
		 get { } //Length: 44
	}

	public XPathDocument Document
	{
		 get { } //Length: 28
	}

	public bool HasCollapsedText
	{
		 get { } //Length: 12
	}

	public bool HasNamespaceDecls
	{
		 get { } //Length: 12
	}

	public bool HasSibling
	{
		 get { } //Length: 16
	}

	public bool IsText
	{
		 get { } //Length: 92
	}

	public bool IsXmlNamespaceNode
	{
		 get { } //Length: 136
	}

	public int LineNumber
	{
		 get { } //Length: 40
	}

	public int LinePosition
	{
		 get { } //Length: 36
	}

	public string LocalName
	{
		 get { } //Length: 28
	}

	public string NamespaceUri
	{
		 get { } //Length: 28
	}

	public XPathNodeType NodeType
	{
		 get { } //Length: 12
	}

	public XPathNodePageInfo PageInfo
	{
		 get { } //Length: 28
	}

	public string Prefix
	{
		 get { } //Length: 28
	}

	public string Value
	{
		 get { } //Length: 8
	}

	public int get_CollapsedLinePosition() { }

	public XPathDocument get_Document() { }

	public bool get_HasCollapsedText() { }

	public bool get_HasNamespaceDecls() { }

	public bool get_HasSibling() { }

	public bool get_IsText() { }

	public bool get_IsXmlNamespaceNode() { }

	public int get_LineNumber() { }

	public int get_LinePosition() { }

	public string get_LocalName() { }

	public string get_NamespaceUri() { }

	public XPathNodeType get_NodeType() { }

	public XPathNodePageInfo get_PageInfo() { }

	public string get_Prefix() { }

	public string get_Value() { }

	public int GetParent(out XPathNode[] pageNode) { }

	public int GetSibling(out XPathNode[] pageNode) { }

}

