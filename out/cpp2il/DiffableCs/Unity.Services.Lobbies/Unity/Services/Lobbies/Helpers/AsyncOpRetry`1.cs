namespace Unity.Services.Lobbies.Helpers;

internal class AsyncOpRetry
{
	[CompilerGenerated]
	private sealed class <Run>d__35 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private object <>2__current; //Field offset: 0x0
		public AsyncOpRetry<T> <>4__this; //Field offset: 0x0
		private T <asyncOp>5__2; //Field offset: 0x0
		private int <attempt>5__3; //Field offset: 0x0

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 40
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 40
		}

		[DebuggerHidden]
		public <Run>d__35(int <>1__state) { }

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
	private uint <MaxRetries>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private float <JitterMagnitude>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private float <DelayScale>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private float <MaxDelayTime>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private Func<Int32, T> <CreateOperation>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private Func<T, Boolean> <RetryCondition>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private Action<T> <OnComplete>k__BackingField; //Field offset: 0x0

	private Func<Int32, T> CreateOperation
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private float DelayScale
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private float JitterMagnitude
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private float MaxDelayTime
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private uint MaxRetries
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private Action<T> OnComplete
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private Func<T, Boolean> RetryCondition
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	private AsyncOpRetry`1(Func<Int32, T> createAsyncOp) { }

	private static float AddJitter(float number, float magnitude) { }

	private static float CalculateDelay(int attemptNumber, float maxDelayTime, float delayScale, float jitterMagnitude) { }

	public static AsyncOpRetry<T> FromCreateAsync(Func<Int32, T> op) { }

	[CompilerGenerated]
	private Func<Int32, T> get_CreateOperation() { }

	[CompilerGenerated]
	private float get_DelayScale() { }

	[CompilerGenerated]
	private float get_JitterMagnitude() { }

	[CompilerGenerated]
	private float get_MaxDelayTime() { }

	[CompilerGenerated]
	private uint get_MaxRetries() { }

	[CompilerGenerated]
	private Action<T> get_OnComplete() { }

	[CompilerGenerated]
	private Func<T, Boolean> get_RetryCondition() { }

	private static float Pow2(float exponent, float scale) { }

	[IteratorStateMachine(typeof(<Run>d__35))]
	public IEnumerator Run() { }

	[CompilerGenerated]
	private void set_CreateOperation(Func<Int32, T> value) { }

	[CompilerGenerated]
	private void set_DelayScale(float value) { }

	[CompilerGenerated]
	private void set_JitterMagnitude(float value) { }

	[CompilerGenerated]
	private void set_MaxDelayTime(float value) { }

	[CompilerGenerated]
	private void set_MaxRetries(uint value) { }

	[CompilerGenerated]
	private void set_OnComplete(Action<T> value) { }

	[CompilerGenerated]
	private void set_RetryCondition(Func<T, Boolean> value) { }

	public AsyncOpRetry<T> WhenComplete(Action<T> onComplete) { }

	public AsyncOpRetry<T> WithRetryCondition(Func<T, Boolean> shouldRetry) { }

}

