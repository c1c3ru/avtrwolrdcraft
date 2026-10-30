namespace UnityWebSocketSharp;

internal abstract class HttpBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public List<Byte> buff; //Field offset: 0x10
		public int cnt; //Field offset: 0x18

		public <>c__DisplayClass26_0() { }

		internal void <readMessageHeaderFrom>b__0(int i) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public bool timeout; //Field offset: 0x0
		public Stream stream; //Field offset: 0x0

		public <>c__DisplayClass28_0`1() { }

		internal void <Read>b__0(object state) { }

	}

	private static readonly int _maxMessageHeaderLength; //Field offset: 0x0
	protected static readonly string CrLf; //Field offset: 0x8
	protected static readonly string CrLfHt; //Field offset: 0x10
	protected static readonly string CrLfSp; //Field offset: 0x18
	private NameValueCollection _headers; //Field offset: 0x10
	private string _messageBody; //Field offset: 0x18
	private Byte[] _messageBodyData; //Field offset: 0x20
	private Version _version; //Field offset: 0x28

	public bool HasMessageBody
	{
		 get { } //Length: 16
	}

	public NameValueCollection Headers
	{
		 get { } //Length: 8
	}

	protected string HeaderSection
	{
		 get { } //Length: 384
	}

	public string MessageBody
	{
		 get { } //Length: 64
	}

	internal Byte[] MessageBodyData
	{
		internal get { } //Length: 8
	}

	public abstract string MessageHeader
	{
		 get { } //Length: 0
	}

	public Version ProtocolVersion
	{
		 get { } //Length: 8
	}

	private static HttpBase() { }

	protected HttpBase(Version version, NameValueCollection headers) { }

	public bool get_HasMessageBody() { }

	public NameValueCollection get_Headers() { }

	protected string get_HeaderSection() { }

	public string get_MessageBody() { }

	internal Byte[] get_MessageBodyData() { }

	public abstract string get_MessageHeader() { }

	public Version get_ProtocolVersion() { }

	private string getMessageBody() { }

	protected static T Read(Stream stream, Func<String[], T> parser, int millisecondsTimeout) { }

	private static Byte[] readMessageBodyFrom(Stream stream, string length) { }

	private static String[] readMessageHeaderFrom(Stream stream) { }

	public Byte[] ToByteArray() { }

	public virtual string ToString() { }

	internal void WriteTo(Stream stream) { }

}

