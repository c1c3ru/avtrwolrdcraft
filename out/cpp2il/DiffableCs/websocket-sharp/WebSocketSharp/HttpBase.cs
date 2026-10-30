namespace WebSocketSharp;

internal abstract class HttpBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public List<Byte> buff; //Field offset: 0x10
		public int cnt; //Field offset: 0x18

		public <>c__DisplayClass13_0() { }

		internal void <readHeaders>b__0(int i) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public bool timeout; //Field offset: 0x0
		public Stream stream; //Field offset: 0x0

		public <>c__DisplayClass14_0`1() { }

		internal void <Read>b__0(object state) { }

	}

	private const int _headersMaxLength = 8192; //Field offset: 0x0
	protected const string CrLf = "
"; //Field offset: 0x0
	private NameValueCollection _headers; //Field offset: 0x10
	private Version _version; //Field offset: 0x18
	internal Byte[] EntityBodyData; //Field offset: 0x20

	public string EntityBody
	{
		 get { } //Length: 248
	}

	public NameValueCollection Headers
	{
		 get { } //Length: 8
	}

	public Version ProtocolVersion
	{
		 get { } //Length: 8
	}

	protected HttpBase(Version version, NameValueCollection headers) { }

	public string get_EntityBody() { }

	public NameValueCollection get_Headers() { }

	public Version get_ProtocolVersion() { }

	protected static T Read(Stream stream, Func<String[], T> parser, int millisecondsTimeout) { }

	private static Byte[] readEntityBody(Stream stream, string length) { }

	private static String[] readHeaders(Stream stream, int maxLength) { }

	public Byte[] ToByteArray() { }

}

