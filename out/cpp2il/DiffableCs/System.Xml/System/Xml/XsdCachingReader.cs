namespace System.Xml;

[DefaultMember("Item")]
internal class XsdCachingReader : XmlReader, IXmlLineInfo
{
	private enum CachingReaderState
	{
		None = 0,
		Init = 1,
		Record = 2,
		Replay = 3,
		ReaderClosed = 4,
		Error = 5,
	}

	private XmlReader coreReader; //Field offset: 0x10
	private XmlNameTable coreReaderNameTable; //Field offset: 0x18
	private ValidatingReaderNodeData[] contentEvents; //Field offset: 0x20
	private ValidatingReaderNodeData[] attributeEvents; //Field offset: 0x28
	private ValidatingReaderNodeData cachedNode; //Field offset: 0x30
	private CachingReaderState cacheState; //Field offset: 0x38
	private int contentIndex; //Field offset: 0x3C
	private int attributeCount; //Field offset: 0x40
	private bool returnOriginalStringValues; //Field offset: 0x44
	private CachingEventHandler cacheHandler; //Field offset: 0x48
	private int currentAttrIndex; //Field offset: 0x50
	private int currentContentIndex; //Field offset: 0x54
	private bool readAhead; //Field offset: 0x58
	private IXmlLineInfo lineInfo; //Field offset: 0x60
	private ValidatingReaderNodeData textNode; //Field offset: 0x68

	public virtual int AttributeCount
	{
		 get { } //Length: 8
	}

	public virtual string BaseURI
	{
		 get { } //Length: 36
	}

	public virtual int Depth
	{
		 get { } //Length: 28
	}

	public virtual bool EOF
	{
		 get { } //Length: 60
	}

	public virtual bool IsDefault
	{
		 get { } //Length: 8
	}

	public virtual bool IsEmptyElement
	{
		 get { } //Length: 8
	}

	public virtual string LocalName
	{
		 get { } //Length: 28
	}

	public virtual string Name
	{
		 get { } //Length: 36
	}

	public virtual string NamespaceURI
	{
		 get { } //Length: 28
	}

	public virtual XmlNameTable NameTable
	{
		 get { } //Length: 8
	}

	public virtual XmlNodeType NodeType
	{
		 get { } //Length: 28
	}

	public virtual string Prefix
	{
		 get { } //Length: 28
	}

	public virtual char QuoteChar
	{
		 get { } //Length: 36
	}

	public virtual ReadState ReadState
	{
		 get { } //Length: 36
	}

	public virtual XmlReaderSettings Settings
	{
		 get { } //Length: 32
	}

	private override int System.Xml.IXmlLineInfo.LineNumber
	{
		private get { } //Length: 28
	}

	private override int System.Xml.IXmlLineInfo.LinePosition
	{
		private get { } //Length: 28
	}

	public virtual string Value
	{
		 get { } //Length: 48
	}

	public virtual string XmlLang
	{
		 get { } //Length: 36
	}

	public virtual XmlSpace XmlSpace
	{
		 get { } //Length: 36
	}

	internal XsdCachingReader(XmlReader reader, IXmlLineInfo lineInfo, CachingEventHandler handlerMethod) { }

	private ValidatingReaderNodeData AddAttribute(int attIndex) { }

	private ValidatingReaderNodeData AddContent(XmlNodeType nodeType) { }

	private void ClearAttributesInfo() { }

	public virtual void Close() { }

	private ValidatingReaderNodeData CreateDummyTextNode(string attributeValue, int depth) { }

	public virtual int get_AttributeCount() { }

	public virtual string get_BaseURI() { }

	public virtual int get_Depth() { }

	public virtual bool get_EOF() { }

	public virtual bool get_IsDefault() { }

	public virtual bool get_IsEmptyElement() { }

	public virtual string get_LocalName() { }

	public virtual string get_Name() { }

	public virtual string get_NamespaceURI() { }

	public virtual XmlNameTable get_NameTable() { }

	public virtual XmlNodeType get_NodeType() { }

	public virtual string get_Prefix() { }

	public virtual char get_QuoteChar() { }

	public virtual ReadState get_ReadState() { }

	public virtual XmlReaderSettings get_Settings() { }

	public virtual string get_Value() { }

	public virtual string get_XmlLang() { }

	public virtual XmlSpace get_XmlSpace() { }

	public virtual string GetAttribute(int i) { }

	public virtual string GetAttribute(string name, string namespaceURI) { }

	public virtual string GetAttribute(string name) { }

	private int GetAttributeIndexWithoutPrefix(string name) { }

	private int GetAttributeIndexWithPrefix(string name) { }

	internal XmlReader GetCoreReader() { }

	internal IXmlLineInfo GetLineInfo() { }

	private void Init() { }

	public virtual string LookupNamespace(string prefix) { }

	public virtual void MoveToAttribute(int i) { }

	public virtual bool MoveToAttribute(string name) { }

	public virtual bool MoveToElement() { }

	public virtual bool MoveToFirstAttribute() { }

	public virtual bool MoveToNextAttribute() { }

	public virtual bool Read() { }

	public virtual bool ReadAttributeValue() { }

	private void RecordAttributes() { }

	internal void RecordEndElementNode() { }

	internal ValidatingReaderNodeData RecordTextNode(string textValue, string originalStringValue, int depth, int lineNo, int linePos) { }

	internal void Reset(XmlReader reader) { }

	public virtual void ResolveEntity() { }

	internal void SetToReplayMode() { }

	public virtual void Skip() { }

	internal void SwitchTextNodeAndEndElement(string textValue, string originalStringValue) { }

	private override int System.Xml.IXmlLineInfo.get_LineNumber() { }

	private override int System.Xml.IXmlLineInfo.get_LinePosition() { }

	private override bool System.Xml.IXmlLineInfo.HasLineInfo() { }

}

