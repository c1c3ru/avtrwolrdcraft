namespace LipingShare.LCLib.Asn1Processor;

internal class Asn1Node : IAsn1Node
{
	internal class TagTextMask
	{
		public const uint SHOW_OFFSET = 1; //Field offset: 0x0
		public const uint SHOW_DATA = 2; //Field offset: 0x0
		public const uint USE_HEX_OFFSET = 4; //Field offset: 0x0
		public const uint SHOW_TAG_NUMBER = 8; //Field offset: 0x0
		public const uint SHOW_PATH = 16; //Field offset: 0x0

		public TagTextMask() { }

	}

	public const int BitStringUnusedFiledLength = 1; //Field offset: 0x0
	private const int k_IndefiniteLengthFooterSize = 2; //Field offset: 0x0
	private const int k_InvalidIndeterminateContentLength = -1; //Field offset: 0x0
	private const int k_EndOfStream = -1; //Field offset: 0x0
	public const int minLineLen = 60; //Field offset: 0x0
	public const int defaultLineLen = 80; //Field offset: 0x0
	public const int TagLength = 1; //Field offset: 0x0
	private const int indentStep = 3; //Field offset: 0x0
	private byte tag; //Field offset: 0x10
	private long dataOffset; //Field offset: 0x18
	private long dataLength; //Field offset: 0x20
	private long lengthFieldBytes; //Field offset: 0x28
	private Byte[] data; //Field offset: 0x30
	private ArrayList childNodeList; //Field offset: 0x38
	private byte unusedBits; //Field offset: 0x40
	private long deepness; //Field offset: 0x48
	private string path; //Field offset: 0x50
	private Asn1Node parentNode; //Field offset: 0x58
	private bool requireRecalculatePar; //Field offset: 0x60
	private bool isIndefiniteLength; //Field offset: 0x61
	private bool parseEncapsulatedData; //Field offset: 0x62

	public override long ChildNodeCount
	{
		 get { } //Length: 44
	}

	public override Byte[] Data
	{
		 get { } //Length: 392
		 set { } //Length: 4
	}

	public override long DataLength
	{
		 get { } //Length: 8
	}

	public override long DataOffset
	{
		 get { } //Length: 8
	}

	public override long Deepness
	{
		 get { } //Length: 8
	}

	public bool IsEmptyData
	{
		 get { } //Length: 32
	}

	public bool IsIndefiniteLength
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public override long LengthFieldBytes
	{
		 get { } //Length: 8
	}

	public override byte MaskedTag
	{
		 get { } //Length: 12
	}

	public override Asn1Node ParentNode
	{
		 get { } //Length: 8
	}

	public override bool ParseEncapsulatedData
	{
		 get { } //Length: 8
		 set { } //Length: 384
	}

	public override string Path
	{
		 get { } //Length: 8
	}

	protected bool RequireRecalculatePar
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public override byte Tag
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override string TagName
	{
		 get { } //Length: 88
	}

	public override byte UnusedBits
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private Asn1Node(Asn1Node parentNode, long dataOffset) { }

	public Asn1Node() { }

	public override void AddChild(Asn1Node xdata) { }

	private bool AreTagsOk() { }

	private long CalculateListEncodeFieldBytesAndOffset(Stream xdata, long start) { }

	public override void ClearAll() { }

	public override Asn1Node Clone() { }

	private bool CreateAndAddChildNode(Stream secData, ref long offset) { }

	private Stream CreateAndPrepareListDecodeMemoryStreamKnownLength(Stream xdata) { }

	private Asn1EndOfIndefiniteLengthNodeType DetectEndOfIndefiniteListContents(Stream xdata) { }

	private string FormatLineHexString(string lStr, int indent, int lineLen, string msg) { }

	private string FormatLineString(string lStr, int indent, int lineLen, string msg) { }

	protected bool GeneralDecode(Stream xdata) { }

	private bool GeneralDecodeIndefiniteLength(Stream xdata, long nodeMaxLen) { }

	private bool GeneralDecodeKnownLength(Stream xdata) { }

	private bool GeneralDecodeKnownLengthWithChecks(Stream xdata, long start, long nodeMaxLen) { }

	public override long get_ChildNodeCount() { }

	public override Byte[] get_Data() { }

	public override long get_DataLength() { }

	public override long get_DataOffset() { }

	public override long get_Deepness() { }

	public bool get_IsEmptyData() { }

	public bool get_IsIndefiniteLength() { }

	public override long get_LengthFieldBytes() { }

	public override byte get_MaskedTag() { }

	public override Asn1Node get_ParentNode() { }

	public override bool get_ParseEncapsulatedData() { }

	public override string get_Path() { }

	protected bool get_RequireRecalculatePar() { }

	public override byte get_Tag() { }

	public override string get_TagName() { }

	public override byte get_UnusedBits() { }

	public override Asn1Node GetChildNode(int index) { }

	public override string GetDataStr(bool pureHexMode) { }

	public static Asn1Node GetDecendantNodeByOid(string oid, Asn1Node startNode) { }

	public override Asn1Node GetDescendantNodeByPath(string nodePath) { }

	public static long GetDescendantNodeCount(Asn1Node node) { }

	private string GetHexPrintingStr(Asn1Node startNode, string baseLine, string lStr, int lineLen) { }

	protected string GetIndentStr(Asn1Node startNode) { }

	public override string GetLabel(uint mask) { }

	private Asn1Node GetLastChild() { }

	protected string GetListStr(Asn1Node startNode, int lineLen) { }

	public Byte[] GetRawData() { }

	public override string GetText(Asn1Node startNode, int lineLen) { }

	private bool HandleBitStringTag(Stream xdata, ref long offset) { }

	private void Init() { }

	public override int InsertChild(Asn1Node xdata, int index) { }

	public override int InsertChild(Asn1Node xdata, Asn1Node indexNode) { }

	public override int InsertChildAfter(Asn1Node xdata, int index) { }

	public override int InsertChildAfter(Asn1Node xdata, Asn1Node indexNode) { }

	protected bool InternalLoadData(Stream xdata) { }

	private bool IsGeneralStreamLengthOk(Stream xdata, long start, long nodeMaxLen) { }

	private bool IsListStreamLengthOk(Stream xdata, long childNodeMaxLen) { }

	protected bool ListDecode(Stream xdata) { }

	private bool ListDecodeChildNodesWithKnownLength(Stream secData, long offset) { }

	private bool ListDecodeIndefiniteLength(Stream xdata, long start, long childNodeMaxLen) { }

	private bool ListDecodeIndefiniteLengthInternal(Stream xdata, long offset, long childNodeMaxLen) { }

	private bool ListDecodeKnownLength(Stream xdata, long start) { }

	private bool ListDecodeKnownLengthInternal(Stream xdata, long offset) { }

	private bool ListDecodeKnownLengthWithChecks(Stream xdata, long start, long childNodeMaxLen) { }

	public override bool LoadData(Stream xdata) { }

	public bool LoadData(Byte[] byteData) { }

	private long MeasureContentLength(Stream xdata) { }

	private void ReadMeasuredLengthDataFromStart(Stream xdata, long startPosition, long length) { }

	private bool ReadNextChildNodeOfIndefiniteListClearIfInvalid(Stream xdata, ref long offset, long childNodeMaxLen) { }

	private bool ReadNextChildNodeOrEndFooterOfIndefiniteListClearIfInvalid(Stream xdata, ref long offset, long childNodeMaxLen) { }

	private void ReadStreamDataDefiniteLength(Stream xdata, int length) { }

	private bool ReadStreamDataIndefiniteLength(Stream xdata, long nodeMaxLen) { }

	protected void RecalculateTreePar() { }

	public override Asn1Node RemoveChild(Asn1Node node) { }

	public override Asn1Node RemoveChild(int index) { }

	protected static long ResetBranchDataLength(Asn1Node node) { }

	protected void ResetChildNodePar(Asn1Node xNode, long subOffset) { }

	protected static void ResetDataLengthFieldWidth(Asn1Node node) { }

	public override bool SaveData(Stream xdata) { }

	public override void set_Data(Byte[] value) { }

	public void set_IsIndefiniteLength(bool value) { }

	public override void set_ParseEncapsulatedData(bool value) { }

	protected void set_RequireRecalculatePar(bool value) { }

	public override void set_Tag(byte value) { }

	public void set_UnusedBits(byte value) { }

	protected void SetData(Byte[] xdata) { }

}

