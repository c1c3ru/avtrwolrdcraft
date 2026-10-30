namespace LipingShare.LCLib.Asn1Processor;

internal class Asn1Parser
{
	private Byte[] rawData; //Field offset: 0x10
	private Asn1Node rootNode; //Field offset: 0x18

	private bool ParseEncapsulatedData
	{
		private get { } //Length: 28
		private set { } //Length: 28
	}

	public Byte[] RawData
	{
		 get { } //Length: 8
	}

	public Asn1Node RootNode
	{
		 get { } //Length: 8
	}

	public Asn1Parser() { }

	private bool get_ParseEncapsulatedData() { }

	public Byte[] get_RawData() { }

	public Asn1Node get_RootNode() { }

	public Asn1Node GetNodeByOid(string oid) { }

	public Asn1Node GetNodeByPath(string nodePath) { }

	public static string GetNodeText(Asn1Node node, int lineLen) { }

	public static string GetNodeTextHeader(int lineLen) { }

	public void LoadData(string fileName) { }

	public void LoadData(Stream stream) { }

	public void LoadPemData(string fileName) { }

	public void SaveData(string fileName) { }

	private void set_ParseEncapsulatedData(bool value) { }

	public virtual string ToString() { }

}

