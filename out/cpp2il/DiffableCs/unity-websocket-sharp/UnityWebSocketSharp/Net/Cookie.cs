namespace UnityWebSocketSharp.Net;

internal sealed class Cookie
{
	private static readonly Int32[] _emptyPorts; //Field offset: 0x0
	private static readonly Char[] _reservedCharsForValue; //Field offset: 0x8
	private string _comment; //Field offset: 0x10
	private Uri _commentUri; //Field offset: 0x18
	private bool _discard; //Field offset: 0x20
	private string _domain; //Field offset: 0x28
	private DateTime _expires; //Field offset: 0x30
	private bool _httpOnly; //Field offset: 0x38
	private string _name; //Field offset: 0x40
	private string _path; //Field offset: 0x48
	private string _port; //Field offset: 0x50
	private Int32[] _ports; //Field offset: 0x58
	private string _sameSite; //Field offset: 0x60
	private bool _secure; //Field offset: 0x68
	private DateTime _timeStamp; //Field offset: 0x70
	private string _value; //Field offset: 0x78
	private int _version; //Field offset: 0x80

	public internal string Comment
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	public internal Uri CommentUri
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	public internal bool Discard
	{
		 get { } //Length: 8
		internal set { } //Length: 12
	}

	public string Domain
	{
		 get { } //Length: 8
		 set { } //Length: 112
	}

	internal bool ExactDomain
	{
		internal get { } //Length: 64
	}

	public bool Expired
	{
		 get { } //Length: 168
		 set { } //Length: 136
	}

	public DateTime Expires
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool HttpOnly
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	internal int MaxAge
	{
		internal get { } //Length: 376
		internal set { } //Length: 144
	}

	public string Name
	{
		 get { } //Length: 8
		 set { } //Length: 360
	}

	public string Path
	{
		 get { } //Length: 8
		 set { } //Length: 112
	}

	public internal string Port
	{
		 get { } //Length: 8
		internal set { } //Length: 144
	}

	internal Int32[] Ports
	{
		internal get { } //Length: 100
	}

	internal string SameSite
	{
		internal get { } //Length: 8
		internal set { } //Length: 8
	}

	public bool Secure
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public DateTime TimeStamp
	{
		 get { } //Length: 8
	}

	public string Value
	{
		 get { } //Length: 8
		 set { } //Length: 340
	}

	public internal int Version
	{
		 get { } //Length: 8
		internal set { } //Length: 16
	}

	private static Cookie() { }

	internal Cookie() { }

	public Cookie(string name, string value) { }

	public Cookie(string name, string value, string path) { }

	public Cookie(string name, string value, string path, string domain) { }

	public virtual bool Equals(object comparand) { }

	internal bool EqualsWithoutValue(Cookie cookie) { }

	internal bool EqualsWithoutValueAndVersion(Cookie cookie) { }

	public string get_Comment() { }

	public Uri get_CommentUri() { }

	public bool get_Discard() { }

	public string get_Domain() { }

	internal bool get_ExactDomain() { }

	public bool get_Expired() { }

	public DateTime get_Expires() { }

	public bool get_HttpOnly() { }

	internal int get_MaxAge() { }

	public string get_Name() { }

	public string get_Path() { }

	public string get_Port() { }

	internal Int32[] get_Ports() { }

	internal string get_SameSite() { }

	public bool get_Secure() { }

	public DateTime get_TimeStamp() { }

	public string get_Value() { }

	public int get_Version() { }

	public virtual int GetHashCode() { }

	private static int hash(int i, int j, int k, int l, int m) { }

	private void init(string name, string value, string path, string domain) { }

	internal void set_Comment(string value) { }

	internal void set_CommentUri(Uri value) { }

	internal void set_Discard(bool value) { }

	public void set_Domain(string value) { }

	public void set_Expired(bool value) { }

	public void set_Expires(DateTime value) { }

	public void set_HttpOnly(bool value) { }

	internal void set_MaxAge(int value) { }

	public void set_Name(string value) { }

	public void set_Path(string value) { }

	internal void set_Port(string value) { }

	internal void set_SameSite(string value) { }

	public void set_Secure(bool value) { }

	public void set_Value(string value) { }

	internal void set_Version(int value) { }

	internal string ToRequestString(Uri uri) { }

	internal string ToResponseString() { }

	private string toResponseStringVersion0() { }

	private string toResponseStringVersion1() { }

	public virtual string ToString() { }

	internal static bool TryCreate(string name, string value, out Cookie result) { }

	private static bool tryCreatePorts(string value, out Int32[] result) { }

}

