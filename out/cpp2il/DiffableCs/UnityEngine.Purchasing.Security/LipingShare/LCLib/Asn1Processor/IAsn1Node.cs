namespace LipingShare.LCLib.Asn1Processor;

internal interface IAsn1Node
{

	public long ChildNodeCount
	{
		 get { } //Length: 0
	}

	public Byte[] Data
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public long DataLength
	{
		 get { } //Length: 0
	}

	public long DataOffset
	{
		 get { } //Length: 0
	}

	public long Deepness
	{
		 get { } //Length: 0
	}

	public long LengthFieldBytes
	{
		 get { } //Length: 0
	}

	public byte MaskedTag
	{
		 get { } //Length: 0
	}

	public Asn1Node ParentNode
	{
		 get { } //Length: 0
	}

	public bool ParseEncapsulatedData
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public string Path
	{
		 get { } //Length: 0
	}

	public byte Tag
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public string TagName
	{
		 get { } //Length: 0
	}

	public byte UnusedBits
	{
		 get { } //Length: 0
	}

	public void AddChild(Asn1Node xdata) { }

	public void ClearAll() { }

	public Asn1Node Clone() { }

	public long get_ChildNodeCount() { }

	public Byte[] get_Data() { }

	public long get_DataLength() { }

	public long get_DataOffset() { }

	public long get_Deepness() { }

	public long get_LengthFieldBytes() { }

	public byte get_MaskedTag() { }

	public Asn1Node get_ParentNode() { }

	public bool get_ParseEncapsulatedData() { }

	public string get_Path() { }

	public byte get_Tag() { }

	public string get_TagName() { }

	public byte get_UnusedBits() { }

	public Asn1Node GetChildNode(int index) { }

	public string GetDataStr(bool pureHexMode) { }

	public Asn1Node GetDescendantNodeByPath(string nodePath) { }

	public string GetLabel(uint mask) { }

	public string GetText(Asn1Node startNode, int lineLen) { }

	public int InsertChild(Asn1Node xdata, Asn1Node indexNode) { }

	public int InsertChild(Asn1Node xdata, int index) { }

	public int InsertChildAfter(Asn1Node xdata, Asn1Node indexNode) { }

	public int InsertChildAfter(Asn1Node xdata, int index) { }

	public bool LoadData(Stream xdata) { }

	public Asn1Node RemoveChild(Asn1Node node) { }

	public Asn1Node RemoveChild(int index) { }

	public bool SaveData(Stream xdata) { }

	public void set_Data(Byte[] value) { }

	public void set_ParseEncapsulatedData(bool value) { }

	public void set_Tag(byte value) { }

}

