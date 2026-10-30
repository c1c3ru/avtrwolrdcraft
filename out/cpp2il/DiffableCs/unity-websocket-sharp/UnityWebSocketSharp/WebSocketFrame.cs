namespace UnityWebSocketSharp;

internal class WebSocketFrame : IEnumerable<Byte>, IEnumerable
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass69_0
	{
		public int len; //Field offset: 0x10
		public WebSocketFrame frame; //Field offset: 0x18
		public Action<WebSocketFrame> completed; //Field offset: 0x20

		public <>c__DisplayClass69_0() { }

		internal void <readExtendedPayloadLengthAsync>b__0(Byte[] bytes) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass71_0
	{
		public Action<WebSocketFrame> completed; //Field offset: 0x10

		public <>c__DisplayClass71_0() { }

		internal void <readHeaderAsync>b__0(Byte[] bytes) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass73_0
	{
		public WebSocketFrame frame; //Field offset: 0x10
		public Action<WebSocketFrame> completed; //Field offset: 0x18

		public <>c__DisplayClass73_0() { }

		internal void <readMaskingKeyAsync>b__0(Byte[] bytes) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass75_0
	{
		public long len; //Field offset: 0x10
		public WebSocketFrame frame; //Field offset: 0x18
		public Action<WebSocketFrame> completed; //Field offset: 0x20

		public <>c__DisplayClass75_0() { }

		internal void <readPayloadDataAsync>b__0(Byte[] bytes) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass76_0
	{
		public StringBuilder buff; //Field offset: 0x10
		public string lineFmt; //Field offset: 0x18

		public <>c__DisplayClass76_0() { }

		internal Action<String, String, String, String> <toDumpString>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass76_1
	{
		public long lineCnt; //Field offset: 0x10
		public <>c__DisplayClass76_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass76_1() { }

		internal void <toDumpString>b__1(string arg1, string arg2, string arg3, string arg4) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass83_0
	{
		public Stream stream; //Field offset: 0x10
		public bool unmask; //Field offset: 0x18
		public Action<WebSocketFrame> completed; //Field offset: 0x20
		public Action<Exception> error; //Field offset: 0x28
		public Action<WebSocketFrame> <>9__3; //Field offset: 0x30
		public Action<WebSocketFrame> <>9__2; //Field offset: 0x38
		public Action<WebSocketFrame> <>9__1; //Field offset: 0x40

		public <>c__DisplayClass83_0() { }

		internal void <ReadFrameAsync>b__0(WebSocketFrame frame) { }

		internal void <ReadFrameAsync>b__1(WebSocketFrame frame1) { }

		internal void <ReadFrameAsync>b__2(WebSocketFrame frame2) { }

		internal void <ReadFrameAsync>b__3(WebSocketFrame frame3) { }

	}

	[CompilerGenerated]
	private sealed class <GetEnumerator>d__86 : IEnumerator<Byte>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private byte <>2__current; //Field offset: 0x14
		public WebSocketFrame <>4__this; //Field offset: 0x18
		private Byte[] <>7__wrap1; //Field offset: 0x20
		private int <>7__wrap2; //Field offset: 0x28

		private override byte System.Collections.Generic.IEnumerator<System.Byte>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 92
		}

		[DebuggerHidden]
		public <GetEnumerator>d__86(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override byte System.Collections.Generic.IEnumerator<System.Byte>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private static readonly int _defaultHeaderLength; //Field offset: 0x0
	private static readonly int _defaultMaskingKeyLength; //Field offset: 0x4
	private Byte[] _extPayloadLength; //Field offset: 0x10
	private Fin _fin; //Field offset: 0x18
	private Mask _mask; //Field offset: 0x19
	private Byte[] _maskingKey; //Field offset: 0x20
	private Opcode _opcode; //Field offset: 0x28
	private PayloadData _payloadData; //Field offset: 0x30
	private byte _payloadLength; //Field offset: 0x38
	private Rsv _rsv1; //Field offset: 0x39
	private Rsv _rsv2; //Field offset: 0x3A
	private Rsv _rsv3; //Field offset: 0x3B

	internal ulong ExactPayloadLength
	{
		internal get { } //Length: 136
	}

	public Byte[] ExtendedPayloadLength
	{
		 get { } //Length: 8
	}

	internal int ExtendedPayloadLengthWidth
	{
		internal get { } //Length: 36
	}

	public Fin Fin
	{
		 get { } //Length: 8
	}

	public bool IsBinary
	{
		 get { } //Length: 16
	}

	public bool IsClose
	{
		 get { } //Length: 16
	}

	public bool IsCompressed
	{
		 get { } //Length: 16
	}

	public bool IsContinuation
	{
		 get { } //Length: 16
	}

	public bool IsControl
	{
		 get { } //Length: 16
	}

	public bool IsData
	{
		 get { } //Length: 20
	}

	public bool IsFinal
	{
		 get { } //Length: 16
	}

	public bool IsFragment
	{
		 get { } //Length: 32
	}

	public bool IsMasked
	{
		 get { } //Length: 16
	}

	public bool IsPing
	{
		 get { } //Length: 16
	}

	public bool IsPong
	{
		 get { } //Length: 16
	}

	public bool IsText
	{
		 get { } //Length: 16
	}

	public ulong Length
	{
		 get { } //Length: 144
	}

	public Mask Mask
	{
		 get { } //Length: 8
	}

	public Byte[] MaskingKey
	{
		 get { } //Length: 8
	}

	public Opcode Opcode
	{
		 get { } //Length: 8
	}

	public PayloadData PayloadData
	{
		 get { } //Length: 8
	}

	public byte PayloadLength
	{
		 get { } //Length: 8
	}

	public Rsv Rsv1
	{
		 get { } //Length: 8
	}

	public Rsv Rsv2
	{
		 get { } //Length: 8
	}

	public Rsv Rsv3
	{
		 get { } //Length: 8
	}

	private static WebSocketFrame() { }

	private WebSocketFrame() { }

	internal WebSocketFrame(Fin fin, Opcode opcode, Byte[] data, bool compressed, bool mask) { }

	internal WebSocketFrame(Fin fin, Opcode opcode, PayloadData payloadData, bool compressed, bool mask) { }

	internal static WebSocketFrame CreateCloseFrame(PayloadData payloadData, bool mask) { }

	private static Byte[] createMaskingKey() { }

	internal static WebSocketFrame CreatePingFrame(bool mask) { }

	internal static WebSocketFrame CreatePingFrame(Byte[] data, bool mask) { }

	internal static WebSocketFrame CreatePongFrame(PayloadData payloadData, bool mask) { }

	internal ulong get_ExactPayloadLength() { }

	public Byte[] get_ExtendedPayloadLength() { }

	internal int get_ExtendedPayloadLengthWidth() { }

	public Fin get_Fin() { }

	public bool get_IsBinary() { }

	public bool get_IsClose() { }

	public bool get_IsCompressed() { }

	public bool get_IsContinuation() { }

	public bool get_IsControl() { }

	public bool get_IsData() { }

	public bool get_IsFinal() { }

	public bool get_IsFragment() { }

	public bool get_IsMasked() { }

	public bool get_IsPing() { }

	public bool get_IsPong() { }

	public bool get_IsText() { }

	public ulong get_Length() { }

	public Mask get_Mask() { }

	public Byte[] get_MaskingKey() { }

	public Opcode get_Opcode() { }

	public PayloadData get_PayloadData() { }

	public byte get_PayloadLength() { }

	public Rsv get_Rsv1() { }

	public Rsv get_Rsv2() { }

	public Rsv get_Rsv3() { }

	[IteratorStateMachine(typeof(<GetEnumerator>d__86))]
	public override IEnumerator<Byte> GetEnumerator() { }

	private static WebSocketFrame processHeader(Byte[] header) { }

	private static WebSocketFrame readExtendedPayloadLength(Stream stream, WebSocketFrame frame) { }

	private static void readExtendedPayloadLengthAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error) { }

	internal static WebSocketFrame ReadFrame(Stream stream, bool unmask) { }

	internal static void ReadFrameAsync(Stream stream, bool unmask, Action<WebSocketFrame> completed, Action<Exception> error) { }

	private static WebSocketFrame readHeader(Stream stream) { }

	private static void readHeaderAsync(Stream stream, Action<WebSocketFrame> completed, Action<Exception> error) { }

	private static WebSocketFrame readMaskingKey(Stream stream, WebSocketFrame frame) { }

	private static void readMaskingKeyAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error) { }

	private static WebSocketFrame readPayloadData(Stream stream, WebSocketFrame frame) { }

	private static void readPayloadDataAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public Byte[] ToArray() { }

	private string toDumpString() { }

	private string toString() { }

	public virtual string ToString() { }

	internal string ToString(bool dump) { }

	internal void Unmask() { }

}

