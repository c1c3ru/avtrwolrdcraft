namespace WebSocketSharp.Server;

[DefaultMember("Item")]
public class WebSocketSessionManager
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public WebSocketSessionManager <>4__this; //Field offset: 0x10
		public Opcode opcode; //Field offset: 0x18
		public Byte[] data; //Field offset: 0x20
		public Action completed; //Field offset: 0x28

		public <>c__DisplayClass32_0() { }

		internal void <broadcastAsync>b__0(object state) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass33_0
	{
		public WebSocketSessionManager <>4__this; //Field offset: 0x10
		public Opcode opcode; //Field offset: 0x18
		public Stream stream; //Field offset: 0x20
		public Action completed; //Field offset: 0x28

		public <>c__DisplayClass33_0() { }

		internal void <broadcastAsync>b__0(object state) { }

	}

	[CompilerGenerated]
	private sealed class <get_ActiveIDs>d__13 : IEnumerable<String>, IEnumerable, IEnumerator<String>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x10
		private string <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public WebSocketSessionManager <>4__this; //Field offset: 0x28
		private Enumerator<String, Boolean> <>s__1; //Field offset: 0x30
		private KeyValuePair<String, Boolean> <res>5__2; //Field offset: 0x58

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
		public <get_ActiveIDs>d__13(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <get_InactiveIDs>d__19 : IEnumerable<String>, IEnumerable, IEnumerator<String>, IDisposable, IEnumerator
	{
		private int <>1__state; //Field offset: 0x10
		private string <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public WebSocketSessionManager <>4__this; //Field offset: 0x28
		private Enumerator<String, Boolean> <>s__1; //Field offset: 0x30
		private KeyValuePair<String, Boolean> <res>5__2; //Field offset: 0x58

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
		public <get_InactiveIDs>d__19(int <>1__state) { }

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

	private object _forSweep; //Field offset: 0x10
	private bool _keepClean; //Field offset: 0x18
	private Logger _log; //Field offset: 0x20
	private Dictionary<String, IWebSocketSession> _sessions; //Field offset: 0x28
	private ServerState _state; //Field offset: 0x30
	private bool _sweeping; //Field offset: 0x34
	private Timer _sweepTimer; //Field offset: 0x38
	private object _sync; //Field offset: 0x40
	private TimeSpan _waitTime; //Field offset: 0x48

	public IEnumerable<String> ActiveIDs
	{
		[IteratorStateMachine(typeof(<get_ActiveIDs>d__13))]
		 get { } //Length: 124
	}

	public int Count
	{
		 get { } //Length: 260
	}

	public IEnumerable<String> IDs
	{
		 get { } //Length: 568
	}

	public IEnumerable<String> InactiveIDs
	{
		[IteratorStateMachine(typeof(<get_InactiveIDs>d__19))]
		 get { } //Length: 124
	}

	public IWebSocketSession Item
	{
		 get { } //Length: 192
	}

	public bool KeepClean
	{
		 get { } //Length: 24
		 set { } //Length: 240
	}

	public IEnumerable<IWebSocketSession> Sessions
	{
		 get { } //Length: 568
	}

	internal ServerState State
	{
		internal get { } //Length: 24
	}

	public TimeSpan WaitTime
	{
		 get { } //Length: 8
		 set { } //Length: 404
	}

	internal WebSocketSessionManager(Logger log) { }

	[CompilerGenerated]
	private void <setSweepTimer>b__37_0(object sender, ElapsedEventArgs e) { }

	internal string Add(IWebSocketSession session) { }

	private void broadcast(Opcode opcode, Byte[] data, Action completed) { }

	private void broadcast(Opcode opcode, Stream stream, Action completed) { }

	internal void Broadcast(Opcode opcode, Stream stream, Dictionary<CompressionMethod, Stream> cache) { }

	public void Broadcast(Stream stream, int length) { }

	public void Broadcast(string data) { }

	public void Broadcast(Byte[] data) { }

	internal void Broadcast(Opcode opcode, Byte[] data, Dictionary<CompressionMethod, Byte[]> cache) { }

	private void broadcastAsync(Opcode opcode, Byte[] data, Action completed) { }

	private void broadcastAsync(Opcode opcode, Stream stream, Action completed) { }

	public void BroadcastAsync(Stream stream, int length, Action completed) { }

	public void BroadcastAsync(string data, Action completed) { }

	public void BroadcastAsync(Byte[] data, Action completed) { }

	private Dictionary<String, Boolean> broadping(Byte[] frameAsBytes) { }

	internal Dictionary<String, Boolean> Broadping(Byte[] frameAsBytes, TimeSpan timeout) { }

	private bool canSet() { }

	public void CloseSession(string id, CloseStatusCode code, string reason) { }

	public void CloseSession(string id, ushort code, string reason) { }

	public void CloseSession(string id) { }

	private static string createID() { }

	[IteratorStateMachine(typeof(<get_ActiveIDs>d__13))]
	public IEnumerable<String> get_ActiveIDs() { }

	public int get_Count() { }

	public IEnumerable<String> get_IDs() { }

	[IteratorStateMachine(typeof(<get_InactiveIDs>d__19))]
	public IEnumerable<String> get_InactiveIDs() { }

	public IWebSocketSession get_Item(string id) { }

	public bool get_KeepClean() { }

	public IEnumerable<IWebSocketSession> get_Sessions() { }

	internal ServerState get_State() { }

	public TimeSpan get_WaitTime() { }

	public bool PingTo(string id) { }

	public bool PingTo(string message, string id) { }

	internal bool Remove(string id) { }

	public void SendTo(Stream stream, int length, string id) { }

	public void SendTo(string data, string id) { }

	public void SendTo(Byte[] data, string id) { }

	public void SendToAsync(Stream stream, int length, string id, Action<Boolean> completed) { }

	public void SendToAsync(string data, string id, Action<Boolean> completed) { }

	public void SendToAsync(Byte[] data, string id, Action<Boolean> completed) { }

	public void set_KeepClean(bool value) { }

	public void set_WaitTime(TimeSpan value) { }

	private void setSweepTimer(double interval) { }

	internal void Start() { }

	private void stop(PayloadData payloadData, bool send) { }

	internal void Stop(ushort code, string reason) { }

	public void Sweep() { }

	private bool tryGetSession(string id, out IWebSocketSession session) { }

	public bool TryGetSession(string id, out IWebSocketSession session) { }

}

