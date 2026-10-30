namespace Unity.Services.Wire.Internal;

internal class Subscription : IChannel, IDisposable
{
	[CompilerGenerated]
	private struct <RetrieveTokenAsync>d__38 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<String> <>t__builder; //Field offset: 0x8
		public Subscription <>4__this; //Field offset: 0x20
		private TaskAwaiter<ChannelToken> <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private Action<String> MessageReceived; //Field offset: 0x10
	[CompilerGenerated]
	private Action<Byte[]> BinaryMessageReceived; //Field offset: 0x18
	[CompilerGenerated]
	private Action KickReceived; //Field offset: 0x20
	[CompilerGenerated]
	private Action<SubscriptionState> NewStateReceived; //Field offset: 0x28
	[CompilerGenerated]
	private Action<TaskCompletionSource`1<Boolean>> UnsubscribeReceived; //Field offset: 0x30
	[CompilerGenerated]
	private Action<TaskCompletionSource`1<Boolean>> SubscribeReceived; //Field offset: 0x38
	[CompilerGenerated]
	private Action<String> ErrorReceived; //Field offset: 0x40
	[CompilerGenerated]
	private Action DisposeReceived; //Field offset: 0x48
	public string Channel; //Field offset: 0x50
	public ulong Offset; //Field offset: 0x58
	public string Epoch; //Field offset: 0x60
	private SubscriptionState m_State; //Field offset: 0x68
	private IChannelTokenProvider m_TokenProvider; //Field offset: 0x70
	private bool m_Disposed; //Field offset: 0x78

	public override event Action<Byte[]> BinaryMessageReceived
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action DisposeReceived
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public override event Action<String> ErrorReceived
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override event Action KickReceived
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public override event Action<String> MessageReceived
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override event Action<SubscriptionState> NewStateReceived
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<TaskCompletionSource`1<Boolean>> SubscribeReceived
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<TaskCompletionSource`1<Boolean>> UnsubscribeReceived
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	private string ChannelDisplay
	{
		private get { } //Length: 88
	}

	public bool IsConnected
	{
		 get { } //Length: 16
	}

	public private SubscriptionState SubscriptionState
	{
		 get { } //Length: 8
		private set { } //Length: 44
	}

	public Subscription(IChannelTokenProvider tokenProvider) { }

	[CompilerGenerated]
	public override void add_BinaryMessageReceived(Action<Byte[]> value) { }

	[CompilerGenerated]
	public void add_DisposeReceived(Action value) { }

	[CompilerGenerated]
	public override void add_ErrorReceived(Action<String> value) { }

	[CompilerGenerated]
	public override void add_KickReceived(Action value) { }

	[CompilerGenerated]
	public override void add_MessageReceived(Action<String> value) { }

	[CompilerGenerated]
	public override void add_NewStateReceived(Action<SubscriptionState> value) { }

	[CompilerGenerated]
	public void add_SubscribeReceived(Action<TaskCompletionSource`1<Boolean>> value) { }

	[CompilerGenerated]
	public void add_UnsubscribeReceived(Action<TaskCompletionSource`1<Boolean>> value) { }

	internal void Dispose(bool disposing) { }

	public override void Dispose() { }

	protected virtual void Finalize() { }

	private string get_ChannelDisplay() { }

	public bool get_IsConnected() { }

	public SubscriptionState get_SubscriptionState() { }

	public void OnConnectivityChangeReceived(bool connected) { }

	internal void OnError(string reason) { }

	public void OnKickReceived() { }

	internal void OnUnsubscriptionComplete() { }

	internal void ProcessPublication(Publication publication) { }

	[CompilerGenerated]
	public override void remove_BinaryMessageReceived(Action<Byte[]> value) { }

	[CompilerGenerated]
	public void remove_DisposeReceived(Action value) { }

	[CompilerGenerated]
	public override void remove_ErrorReceived(Action<String> value) { }

	[CompilerGenerated]
	public override void remove_KickReceived(Action value) { }

	[CompilerGenerated]
	public override void remove_MessageReceived(Action<String> value) { }

	[CompilerGenerated]
	public override void remove_NewStateReceived(Action<SubscriptionState> value) { }

	[CompilerGenerated]
	public void remove_SubscribeReceived(Action<TaskCompletionSource`1<Boolean>> value) { }

	[CompilerGenerated]
	public void remove_UnsubscribeReceived(Action<TaskCompletionSource`1<Boolean>> value) { }

	[AsyncStateMachine(typeof(<RetrieveTokenAsync>d__38))]
	public Task<String> RetrieveTokenAsync() { }

	private void set_SubscriptionState(SubscriptionState value) { }

	internal void SetState(SubscriptionState state) { }

	public override Task SubscribeAsync() { }

	public override Task UnsubscribeAsync() { }

	private void ValidateTokenData(string channel, string token) { }

}

