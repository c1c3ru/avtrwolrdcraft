namespace Unity.Services.Qos.V2.ErrorMitigation;

internal class RetryPolicy : IRetryPolicy<T>
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public Func<Task`1<T>> createAsyncOp; //Field offset: 0x0

		public <>c__DisplayClass10_0() { }

		internal Task<T> <.ctor>b__0(int _) { }

	}

	[CompilerGenerated]
	private struct <RunAsync>d__23 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<T> <>t__builder; //Field offset: 0x0
		public RetryPolicyConfig retryPolicyConfig; //Field offset: 0x0
		public RetryPolicy<T> <>4__this; //Field offset: 0x0
		private T <opResult>5__2; //Field offset: 0x0
		private int <attempt>5__3; //Field offset: 0x0
		private TaskAwaiter<T> <>u__1; //Field offset: 0x0
		private TaskAwaiter<Boolean> <>u__2; //Field offset: 0x0
		private TaskAwaiter <>u__3; //Field offset: 0x0

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private RetryPolicyConfig _retryPolicyConfig; //Field offset: 0x0
	[CompilerGenerated]
	private Func<Int32, Task`1<T>> <CreateOperation>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private Func<T, Task`1<Boolean>> <RetryCondition>k__BackingField; //Field offset: 0x0

	private Func<Int32, Task`1<T>> CreateOperation
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private Func<T, Task`1<Boolean>> RetryCondition
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private RetryPolicy`1(Func<Int32, Task`1<T>> createAsyncOp) { }

	private RetryPolicy`1(Func<Task`1<T>> createAsyncOp) { }

	private static float AddJitter(float number, float magnitude) { }

	private static float CalculateDelay(int attemptNumber, float maxDelayTime, float delayScale, float jitterMagnitude) { }

	public static RetryPolicy<T> ForOperation(Func<Task`1<T>> operation) { }

	public static RetryPolicy<T> ForOperation(Func<Int32, Task`1<T>> operation) { }

	[CompilerGenerated]
	private Func<Int32, Task`1<T>> get_CreateOperation() { }

	[CompilerGenerated]
	private Func<T, Task`1<Boolean>> get_RetryCondition() { }

	public override IRetryPolicy<T> HandleException() { }

	public override IRetryPolicy<T> HandleException(Func<TException, Boolean> condition) { }

	private static float Pow2(float exponent, float scale) { }

	[AsyncStateMachine(typeof(<RunAsync>d__23))]
	public override Task<T> RunAsync(RetryPolicyConfig retryPolicyConfig = null) { }

	[CompilerGenerated]
	private void set_CreateOperation(Func<Int32, Task`1<T>> value) { }

	[CompilerGenerated]
	private void set_RetryCondition(Func<T, Task`1<Boolean>> value) { }

	public override IRetryPolicy<T> UptoMaximumRetries(uint amount) { }

	public override IRetryPolicy<T> WithDelayScale(float scale) { }

	public override IRetryPolicy<T> WithJitterMagnitude(float magnitude) { }

	public override IRetryPolicy<T> WithMaxDelayTime(float time) { }

	public override IRetryPolicy<T> WithRetryCondition(Func<T, Task`1<Boolean>> shouldRetry) { }

}

