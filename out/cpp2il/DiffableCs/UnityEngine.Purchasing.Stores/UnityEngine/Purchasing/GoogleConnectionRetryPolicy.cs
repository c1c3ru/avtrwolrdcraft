namespace UnityEngine.Purchasing;

internal class GoogleConnectionRetryPolicy : IRetryPolicy
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		private struct <<Invoke>g__WaitAndRetry|0>d : IAsyncStateMachine
		{
			public int <>1__state; //Field offset: 0x0
			public AsyncVoidMethodBuilder <>t__builder; //Field offset: 0x8
			public <>c__DisplayClass4_0 <>4__this; //Field offset: 0x28
			private TaskAwaiter <>u__1; //Field offset: 0x30

			private override void MoveNext() { }

			[DebuggerHidden]
			private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

		}

		public int currentRetryDelay; //Field offset: 0x10
		public GoogleConnectionRetryPolicy <>4__this; //Field offset: 0x18
		[Nullable(new IL2CPP_TYPE_U1[] {0, 1})]
		public Action<Action> actionToTry; //Field offset: 0x20
		public Action onRetryAction; //Field offset: 0x28
		public int retryAttempts; //Field offset: 0x30

		public <>c__DisplayClass4_0() { }

		[AsyncStateMachine(typeof(<<Invoke>g__WaitAndRetry|0>d))]
		internal void <Invoke>g__WaitAndRetry|0() { }

	}

	private readonly int m_BaseRetryDelay; //Field offset: 0x10
	private readonly int m_MaxRetryDelay; //Field offset: 0x14
	private readonly int m_ExponentialFactor; //Field offset: 0x18

	public GoogleConnectionRetryPolicy(int baseRetryDelay = 2000, int maxRetryDelay = 30000, int exponentialFactor = 2) { }

	private int AdjustDelay(int delay) { }

	[NullableContext(1)]
	public override void Invoke(Action<Action> actionToTry, Action onRetryAction) { }

}

