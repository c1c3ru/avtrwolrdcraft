namespace PWC.QA.RTA;

public static class RTATasksUtils
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		private struct <<WaitUntilAsync>g__CheckPredicates|0>d : IAsyncStateMachine
		{
			public int <>1__state; //Field offset: 0x0
			public AsyncTaskMethodBuilder<Boolean> <>t__builder; //Field offset: 0x8
			public <>c__DisplayClass1_0 <>4__this; //Field offset: 0x20
			private TaskAwaiter<Boolean> <>u__1; //Field offset: 0x28

			private override void MoveNext() { }

			[DebuggerHidden]
			private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

		}

		public Func<Boolean> predicate; //Field offset: 0x10
		public Func<Task`1<Boolean>> predicateAsync; //Field offset: 0x18

		public <>c__DisplayClass1_0() { }

		[AsyncStateMachine(typeof(<<WaitUntilAsync>g__CheckPredicates|0>d))]
		internal Task<Boolean> <WaitUntilAsync>g__CheckPredicates|0() { }

	}

	[CompilerGenerated]
	private struct <SafeDelayAsync>d__0 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public float miliseconds; //Field offset: 0x20
		private float <seconds>5__2; //Field offset: 0x24
		private float <elapsed>5__3; //Field offset: 0x28
		private YieldAwaiter <>u__1; //Field offset: 0x2C
		private TaskAwaiter <>u__2; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <WaitUntilAsync>d__1 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Boolean> <>t__builder; //Field offset: 0x8
		public Func<Boolean> predicate; //Field offset: 0x20
		public Func<Task`1<Boolean>> predicateAsync; //Field offset: 0x28
		public int checkIntervalMilliseconds; //Field offset: 0x30
		private <>c__DisplayClass1_0 <>8__1; //Field offset: 0x38
		public float timeout; //Field offset: 0x40
		private float <timer>5__2; //Field offset: 0x44
		private float <step>5__3; //Field offset: 0x48
		private TaskAwaiter<Boolean> <>u__1; //Field offset: 0x50
		private TaskAwaiter <>u__2; //Field offset: 0x58

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}


	[AsyncStateMachine(typeof(<SafeDelayAsync>d__0))]
	public static Task SafeDelayAsync(float miliseconds) { }

	[AsyncStateMachine(typeof(<WaitUntilAsync>d__1))]
	public static Task<Boolean> WaitUntilAsync(float timeout, Func<Boolean> predicate = null, Func<Task`1<Boolean>> predicateAsync = null, int checkIntervalMilliseconds = 10) { }

}

