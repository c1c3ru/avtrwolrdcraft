namespace Unity.Services.Relay.ErrorMitigation;

internal class RetryPolicyConfig
{
	[CompilerGenerated]
	private sealed class <>c__17
	{
		public static readonly <>c__17<TException> <>9; //Field offset: 0x0
		public static ExceptionPredicate <>9__17_0; //Field offset: 0x0

		private static <>c__17`1() { }

		public <>c__17`1() { }

		internal Exception <HandleException>b__17_0(Exception exception) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public Func<TException, Boolean> condition; //Field offset: 0x0

		public <>c__DisplayClass18_0`1() { }

		internal Exception <HandleException>b__0(Exception exception) { }

	}

	private float _jitterMagnitude; //Field offset: 0x10
	private float _delayScale; //Field offset: 0x14
	private float _maxDelayTime; //Field offset: 0x18
	private List<ExceptionPredicate> _exceptionsToHandle; //Field offset: 0x20
	[CompilerGenerated]
	private uint <MaxRetries>k__BackingField; //Field offset: 0x28

	public float DelayScale
	{
		 get { } //Length: 8
		 set { } //Length: 32
	}

	public float JitterMagnitude
	{
		 get { } //Length: 8
		 set { } //Length: 32
	}

	public float MaxDelayTime
	{
		 get { } //Length: 8
		 set { } //Length: 36
	}

	public uint MaxRetries
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public RetryPolicyConfig() { }

	public float get_DelayScale() { }

	public float get_JitterMagnitude() { }

	public float get_MaxDelayTime() { }

	[CompilerGenerated]
	public uint get_MaxRetries() { }

	public void HandleException() { }

	public void HandleException(Func<TException, Boolean> condition) { }

	public bool IsHandledException(Exception e) { }

	public void set_DelayScale(float value) { }

	public void set_JitterMagnitude(float value) { }

	public void set_MaxDelayTime(float value) { }

	[CompilerGenerated]
	public void set_MaxRetries(uint value) { }

}

