namespace WebSocketSharp;

[Extension]
public static class Ext
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public int end; //Field offset: 0x10
		public String[] values; //Field offset: 0x18
		public int len; //Field offset: 0x20
		public Func<Int32, Boolean> seek; //Field offset: 0x28

		public <>c__DisplayClass19_0() { }

		internal bool <ContainsTwice>b__0(int idx) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public Stream source; //Field offset: 0x10
		public Action completed; //Field offset: 0x18
		public Stream destination; //Field offset: 0x20
		public Byte[] buff; //Field offset: 0x28
		public int bufferLength; //Field offset: 0x30
		public AsyncCallback callback; //Field offset: 0x38
		public Action<Exception> error; //Field offset: 0x40

		public <>c__DisplayClass23_0() { }

		internal void <CopyToAsync>b__0(IAsyncResult ar) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass57_0
	{
		public Stream stream; //Field offset: 0x10
		public int retry; //Field offset: 0x18
		public Byte[] buff; //Field offset: 0x20
		public int offset; //Field offset: 0x28
		public int length; //Field offset: 0x2C
		public AsyncCallback callback; //Field offset: 0x30
		public Action<Byte[]> completed; //Field offset: 0x38
		public Action<Exception> error; //Field offset: 0x40

		public <>c__DisplayClass57_0() { }

		internal void <ReadBytesAsync>b__0(IAsyncResult ar) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass58_0
	{
		public int bufferLength; //Field offset: 0x10
		public Stream stream; //Field offset: 0x18
		public Byte[] buff; //Field offset: 0x20
		public int retry; //Field offset: 0x28
		public Action<Int64> read; //Field offset: 0x30
		public Action<Byte[]> completed; //Field offset: 0x38
		public MemoryStream dest; //Field offset: 0x40
		public Action<Exception> error; //Field offset: 0x48

		public <>c__DisplayClass58_0() { }

		internal void <ReadBytesAsync>b__0(long len) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass58_1
	{
		public long len; //Field offset: 0x10
		public <>c__DisplayClass58_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass58_1() { }

		internal void <ReadBytesAsync>b__1(IAsyncResult ar) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass82_0
	{
		public Action completed; //Field offset: 0x10
		public MemoryStream src; //Field offset: 0x18
		public Action<Exception> error; //Field offset: 0x20

		public <>c__DisplayClass82_0() { }

		internal void <WriteBytesAsync>b__0() { }

		internal void <WriteBytesAsync>b__1(Exception ex) { }

	}

	[CompilerGenerated]
	private sealed class <SplitHeaderValue>d__60 : IEnumerable<String>, IEnumerable, IEnumerator<String>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x10
		private string <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private string value; //Field offset: 0x28
		public string <>3__value; //Field offset: 0x30
		private Char[] separators; //Field offset: 0x38
		public Char[] <>3__separators; //Field offset: 0x40
		private int <len>5__1; //Field offset: 0x48
		private int <end>5__2; //Field offset: 0x4C
		private StringBuilder <buff>5__3; //Field offset: 0x50
		private bool <escaped>5__4; //Field offset: 0x58
		private bool <quoted>5__5; //Field offset: 0x59
		private int <i>5__6; //Field offset: 0x5C
		private char <c>5__7; //Field offset: 0x60

		private override string System.Collections.Generic.IEnumerator<System.String>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <SplitHeaderValue>d__60(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<String> System.Collections.Generic.IEnumerable<System.String>.GetEnumerator() { }

		[DebuggerHidden]
		private override string System.Collections.Generic.IEnumerator<System.String>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <TrimEach>d__69 : IEnumerable<String>, IEnumerable, IEnumerator<String>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x10
		private string <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private IEnumerable<String> source; //Field offset: 0x28
		public IEnumerable<String> <>3__source; //Field offset: 0x30
		private IEnumerator<String> <>s__1; //Field offset: 0x38
		private string <elm>5__2; //Field offset: 0x40

		private override string System.Collections.Generic.IEnumerator<System.String>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <TrimEach>d__69(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<String> System.Collections.Generic.IEnumerable<System.String>.GetEnumerator() { }

		[DebuggerHidden]
		private override string System.Collections.Generic.IEnumerator<System.String>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private static readonly Byte[] _last; //Field offset: 0x0
	private const string _tspecials = "()<>@,;:\"/[]?={} 	"; //Field offset: 0x0
	private static readonly int _retry; //Field offset: 0x8

	private static Ext() { }

	[Extension]
	internal static Byte[] Append(ushort code, string reason) { }

	[Extension]
	private static Byte[] compress(Byte[] data) { }

	[Extension]
	private static MemoryStream compress(Stream stream) { }

	[Extension]
	internal static Byte[] Compress(Byte[] data, CompressionMethod method) { }

	[Extension]
	internal static Stream Compress(Stream stream, CompressionMethod method) { }

	[Extension]
	private static Byte[] compressToArray(Stream stream) { }

	[Extension]
	internal static Byte[] CompressToArray(Stream stream, CompressionMethod method) { }

	[Extension]
	internal static bool Contains(IEnumerable<T> source, Func<T, Boolean> condition) { }

	[Extension]
	internal static bool Contains(string value, Char[] anyOf) { }

	[Extension]
	internal static bool Contains(NameValueCollection collection, string name) { }

	[Extension]
	internal static bool Contains(NameValueCollection collection, string name, string value, StringComparison comparisonTypeForValue) { }

	[Extension]
	internal static bool ContainsTwice(String[] values) { }

	[Extension]
	internal static T[] Copy(T[] source, long length) { }

	[Extension]
	internal static T[] Copy(T[] source, int length) { }

	[Extension]
	internal static void CopyTo(Stream source, Stream destination, int bufferLength) { }

	[Extension]
	internal static void CopyToAsync(Stream source, Stream destination, int bufferLength, Action completed, Action<Exception> error) { }

	[Extension]
	private static Byte[] decompress(Byte[] data) { }

	[Extension]
	private static MemoryStream decompress(Stream stream) { }

	[Extension]
	internal static Byte[] Decompress(Byte[] data, CompressionMethod method) { }

	[Extension]
	internal static Stream Decompress(Stream stream, CompressionMethod method) { }

	[Extension]
	private static Byte[] decompressToArray(Stream stream) { }

	[Extension]
	internal static Byte[] DecompressToArray(Stream stream, CompressionMethod method) { }

	[Extension]
	internal static void Emit(EventHandler eventHandler, object sender, EventArgs e) { }

	[Extension]
	internal static void Emit(EventHandler<TEventArgs> eventHandler, object sender, TEventArgs e) { }

	[Extension]
	internal static bool EqualsWith(int value, char c, Action<Int32> action) { }

	[Extension]
	internal static string GetAbsolutePath(Uri uri) { }

	[Extension]
	internal static CookieCollection GetCookies(NameValueCollection headers, bool response) { }

	[Extension]
	public static string GetDescription(HttpStatusCode code) { }

	[Extension]
	internal static string GetDnsSafeHost(Uri uri, bool bracketIPv6) { }

	[Extension]
	internal static string GetMessage(CloseStatusCode code) { }

	[Extension]
	internal static string GetName(string nameAndValue, char separator) { }

	[Extension]
	public static string GetStatusDescription(int code) { }

	[Extension]
	internal static string GetUTF8DecodedString(Byte[] bytes) { }

	[Extension]
	internal static Byte[] GetUTF8EncodedBytes(string s) { }

	[Extension]
	internal static string GetValue(string nameAndValue, char separator) { }

	[Extension]
	internal static string GetValue(string nameAndValue, char separator, bool unquote) { }

	[Extension]
	internal static Byte[] InternalToByteArray(ushort value, ByteOrder order) { }

	[Extension]
	internal static Byte[] InternalToByteArray(ulong value, ByteOrder order) { }

	[Extension]
	public static bool IsCloseStatusCode(ushort value) { }

	[Extension]
	internal static bool IsCompressionExtension(string value, CompressionMethod method) { }

	[Extension]
	internal static bool IsControl(byte opcode) { }

	[Extension]
	internal static bool IsControl(Opcode opcode) { }

	[Extension]
	internal static bool IsData(byte opcode) { }

	[Extension]
	internal static bool IsData(Opcode opcode) { }

	[Extension]
	public static bool IsEnclosedIn(string value, char c) { }

	[Extension]
	public static bool IsHostOrder(ByteOrder order) { }

	[Extension]
	private static bool isHttpMethod(string value) { }

	[Extension]
	internal static bool IsHttpMethod(string value, Version version) { }

	[Extension]
	private static bool isHttpMethod10(string value) { }

	[Extension]
	public static bool IsLocal(IPAddress address) { }

	[Extension]
	public static bool IsNullOrEmpty(string value) { }

	[Extension]
	internal static bool IsPortNumber(int value) { }

	[Extension]
	public static bool IsPredefinedScheme(string value) { }

	[Extension]
	internal static bool IsReserved(ushort code) { }

	[Extension]
	internal static bool IsReserved(CloseStatusCode code) { }

	[Extension]
	internal static bool IsSupported(byte opcode) { }

	[Extension]
	internal static bool IsText(string value) { }

	[Extension]
	internal static bool IsToken(string value) { }

	[Extension]
	internal static bool KeepsAlive(NameValueCollection headers, Version version) { }

	[Extension]
	public static bool MaybeUri(string value) { }

	[Extension]
	internal static string Quote(string value) { }

	[Extension]
	internal static Byte[] ReadBytes(Stream stream, int length) { }

	[Extension]
	internal static Byte[] ReadBytes(Stream stream, long length, int bufferLength) { }

	[Extension]
	internal static void ReadBytesAsync(Stream stream, int length, Action<Byte[]> completed, Action<Exception> error) { }

	[Extension]
	internal static void ReadBytesAsync(Stream stream, long length, int bufferLength, Action<Byte[]> completed, Action<Exception> error) { }

	[Extension]
	internal static T[] Reverse(T[] array) { }

	[Extension]
	[IteratorStateMachine(typeof(<SplitHeaderValue>d__60))]
	internal static IEnumerable<String> SplitHeaderValue(string value, Char[] separators) { }

	[Extension]
	public static T[] SubArray(T[] array, int startIndex, int length) { }

	[Extension]
	public static T[] SubArray(T[] array, long startIndex, long length) { }

	[Extension]
	public static void Times(int n, Action action) { }

	[Extension]
	public static void Times(long n, Action action) { }

	[Extension]
	public static void Times(ulong n, Action action) { }

	[Extension]
	public static void Times(int n, Action<Int32> action) { }

	[Extension]
	public static void Times(long n, Action<Int64> action) { }

	[Extension]
	public static void Times(uint n, Action action) { }

	[Extension]
	public static void Times(ulong n, Action<UInt64> action) { }

	[Extension]
	public static void Times(uint n, Action<UInt32> action) { }

	[Extension]
	[Obsolete("This method will be removed.")]
	public static T To(Byte[] source, ByteOrder sourceOrder) { }

	[Extension]
	[Obsolete("This method will be removed.")]
	public static Byte[] ToByteArray(T value, ByteOrder order) { }

	[Extension]
	internal static Byte[] ToByteArray(Stream stream) { }

	[Extension]
	internal static CompressionMethod ToCompressionMethod(string value) { }

	[Extension]
	internal static string ToExtensionString(CompressionMethod method, String[] parameters) { }

	[Extension]
	public static Byte[] ToHostOrder(Byte[] source, ByteOrder sourceOrder) { }

	[Extension]
	internal static IPAddress ToIPAddress(string value) { }

	[Extension]
	internal static List<TSource> ToList(IEnumerable<TSource> source) { }

	[Extension]
	public static string ToString(T[] array, string separator) { }

	[Extension]
	internal static string ToString(IPAddress address, bool bracketIPv6) { }

	[Extension]
	internal static ushort ToUInt16(Byte[] source, ByteOrder sourceOrder) { }

	[Extension]
	internal static ulong ToUInt64(Byte[] source, ByteOrder sourceOrder) { }

	[Extension]
	public static Uri ToUri(string value) { }

	[Extension]
	[IteratorStateMachine(typeof(<TrimEach>d__69))]
	internal static IEnumerable<String> TrimEach(IEnumerable<String> source) { }

	[Extension]
	internal static string TrimSlashFromEnd(string value) { }

	[Extension]
	internal static string TrimSlashOrBackslashFromEnd(string value) { }

	[Extension]
	internal static bool TryCreateVersion(string versionString, out Version result) { }

	[Extension]
	internal static bool TryCreateWebSocketUri(string uriString, out Uri result, out string message) { }

	[Extension]
	internal static bool TryGetUTF8DecodedString(Byte[] bytes, out string s) { }

	[Extension]
	internal static bool TryGetUTF8EncodedBytes(string s, out Byte[] bytes) { }

	[Extension]
	internal static bool TryOpenRead(FileInfo fileInfo, out FileStream fileStream) { }

	[Extension]
	internal static string Unquote(string value) { }

	[Extension]
	internal static bool Upgrades(NameValueCollection headers, string protocol) { }

	[Extension]
	internal static string UrlDecode(string value, Encoding encoding) { }

	[Extension]
	internal static string UrlEncode(string value, Encoding encoding) { }

	[Extension]
	internal static void WriteBytes(Stream stream, Byte[] bytes, int bufferLength) { }

	[Extension]
	internal static void WriteBytesAsync(Stream stream, Byte[] bytes, int bufferLength, Action completed, Action<Exception> error) { }

	[Extension]
	[Obsolete("This method will be removed.")]
	public static void WriteContent(HttpListenerResponse response, Byte[] content) { }

}

