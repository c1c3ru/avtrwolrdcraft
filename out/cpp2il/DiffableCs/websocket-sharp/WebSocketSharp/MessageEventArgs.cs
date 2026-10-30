namespace WebSocketSharp;

public class MessageEventArgs : EventArgs
{
	private string _data; //Field offset: 0x10
	private bool _dataSet; //Field offset: 0x18
	private Opcode _opcode; //Field offset: 0x19
	private Byte[] _rawData; //Field offset: 0x20

	public string Data
	{
		 get { } //Length: 24
	}

	public bool IsBinary
	{
		 get { } //Length: 16
	}

	public bool IsPing
	{
		 get { } //Length: 16
	}

	public bool IsText
	{
		 get { } //Length: 16
	}

	internal Opcode Opcode
	{
		internal get { } //Length: 8
	}

	public Byte[] RawData
	{
		 get { } //Length: 24
	}

	internal MessageEventArgs(WebSocketFrame frame) { }

	internal MessageEventArgs(Opcode opcode, Byte[] rawData) { }

	public string get_Data() { }

	public bool get_IsBinary() { }

	public bool get_IsPing() { }

	public bool get_IsText() { }

	internal Opcode get_Opcode() { }

	public Byte[] get_RawData() { }

	private void setData() { }

}

