namespace PWC.Multiplayer;

public abstract class MPRelayConnectionBase : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public string op; //Field offset: 0x10
		public CustomIDSignInData data; //Field offset: 0x18
		public TaskCompletionSource<CustomIDSignInData> result; //Field offset: 0x20

		public <>c__DisplayClass32_0() { }

		internal void <SigninToPazuCloud>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass33_0
	{
		public TaskCompletionSource<Boolean> result; //Field offset: 0x10

		public <>c__DisplayClass33_0() { }

		internal void <GetGooglePlayIntegrityToken>b__0() { }

	}

	[CompilerGenerated]
	private struct <EnsureInitServices>d__30 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		private TaskAwaiter <>u__1; //Field offset: 0x20

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <EnsureSignIn>d__34 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public MPRelayConnectionBase <>4__this; //Field offset: 0x20
		private TaskAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <Init>d__22 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
		public MPRelayConnectionBase <>4__this; //Field offset: 0x28
		public Action<Boolean> onFinish; //Field offset: 0x30
		private TaskAwaiter <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <InitInternal>d__23 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public MPRelayConnectionBase <>4__this; //Field offset: 0x20
		private TaskAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private sealed class <SendMessagesForUser>d__27 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MPRelayConnectionBase <>4__this; //Field offset: 0x20
		public int playerUID; //Field offset: 0x28
		public Queue<Message> messagesQueue; //Field offset: 0x30
		private Message <message>5__2; //Field offset: 0x38

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
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
		public <SendMessagesForUser>d__27(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private struct <SignUserWithCustomTokenWithAutoRefresh>d__31 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public MPRelayConnectionBase <>4__this; //Field offset: 0x20
		private TaskAwaiter <>u__1; //Field offset: 0x28
		private TaskAwaiter<CustomIDSignInData> <>u__2; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	internal class CustomIDSignInData
	{
		public bool isSuccess; //Field offset: 0x10
		public string accessToken; //Field offset: 0x18
		public string sessionToken; //Field offset: 0x20

		public CustomIDSignInData() { }

	}

	internal class Message
	{
		public WaitForSecondsRealtime wait; //Field offset: 0x10
		public Byte[] bytes; //Field offset: 0x18
		public ICollection<Int32> uids; //Field offset: 0x20

		public Message() { }

	}

	protected const int PAYLOAD_CAPACITY = 44000; //Field offset: 0x0
	private const int MAX_MESSAGE_LEGTH = 10000; //Field offset: 0x0
	private readonly HashSet<Int32> _runningQueues; //Field offset: 0x20
	private readonly Dictionary<Int32, List`1<Byte[]>> _bigMessageParts; //Field offset: 0x28
	private int _lastSentMessageFrame; //Field offset: 0x30
	[CompilerGenerated]
	private int <PlayerUID>k__BackingField; //Field offset: 0x34
	[CompilerGenerated]
	private string <UnityServicePlayerID>k__BackingField; //Field offset: 0x38
	public Action<MPDataBase> OnReceivedDataAction; //Field offset: 0x40
	[CompilerGenerated]
	private string <JoinCode>k__BackingField; //Field offset: 0x48
	public readonly Dictionary<Int32, Queue`1<Message>> _messagesQueues; //Field offset: 0x50
	public Action OnRelayConnectionStatusGoneBadAction; //Field offset: 0x58

	public string JoinCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public int PlayerUID
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public private string UnityServicePlayerID
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	protected MPRelayConnectionBase() { }

	public void DisconnectAndDestroy() { }

	protected abstract void DisconnectAndDestroy_Implementation() { }

	[AsyncStateMachine(typeof(<EnsureInitServices>d__30))]
	private Task EnsureInitServices() { }

	private void EnsureRunningQueues() { }

	[AsyncStateMachine(typeof(<EnsureSignIn>d__34))]
	private Task EnsureSignIn() { }

	[CompilerGenerated]
	public string get_JoinCode() { }

	[CompilerGenerated]
	public int get_PlayerUID() { }

	[CompilerGenerated]
	public string get_UnityServicePlayerID() { }

	private Task GetGooglePlayIntegrityToken() { }

	[AsyncStateMachine(typeof(<Init>d__22))]
	public void Init(Action<Boolean> onFinish = null) { }

	[AsyncStateMachine(typeof(<InitInternal>d__23))]
	protected override Task InitInternal() { }

	protected abstract void ReceiveData(MPDataBase data, int connectionIndex) { }

	[IteratorStateMachine(typeof(<SendMessagesForUser>d__27))]
	private IEnumerator SendMessagesForUser(int playerUID, Queue<Message> messagesQueue) { }

	public void SendMessageToNetwork(T data, ICollection<Int32> uids = null, bool assignSourcePlayerUID = true) { }

	protected abstract void SendMessageToNetwork_Implementation(Byte[] data, ICollection<Int32> uids = null) { }

	[CompilerGenerated]
	protected void set_JoinCode(string value) { }

	[CompilerGenerated]
	public void set_PlayerUID(int value) { }

	[CompilerGenerated]
	private void set_UnityServicePlayerID(string value) { }

	private Task<CustomIDSignInData> SigninToPazuCloud() { }

	[AsyncStateMachine(typeof(<SignUserWithCustomTokenWithAutoRefresh>d__31))]
	protected Task SignUserWithCustomTokenWithAutoRefresh() { }

	protected bool TryReceiveDataFromStream(DataStreamReader stream, int connectionIndex) { }

}

