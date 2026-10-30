namespace PazuCore.AF.TimeLimit;

public class TimeLimitManager : AddressablesFeatureBase
{
	[CompilerGenerated]
	private sealed class <DestroyErrorMessageIfNeeded>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public TimeLimitManager <>4__this; //Field offset: 0x20
		private float <timeoutTimer>5__2; //Field offset: 0x28

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
		public <DestroyErrorMessageIfNeeded>d__8(int <>1__state) { }

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
	private static TimeLimitManager <Instance>k__BackingField; //Field offset: 0x0
	private Message _errorMessage; //Field offset: 0x78

	public private static TimeLimitManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public TimeLimitManager() { }

	protected virtual void Awake() { }

	[IteratorStateMachine(typeof(<DestroyErrorMessageIfNeeded>d__8))]
	private IEnumerator DestroyErrorMessageIfNeeded() { }

	[CompilerGenerated]
	public static TimeLimitManager get_Instance() { }

	protected virtual string GetFallbackResourcesPath() { }

	protected virtual string GetFeatureCloudResponseKey() { }

	protected virtual string GetFeatureKey() { }

	public virtual AddressablesFeatureType GetFeatureType() { }

	public void LoadTimeLimitView(string trigger) { }

	private void OnDayPassedGameplay() { }

	protected virtual void OnDestroy() { }

	public virtual void OnGameResumeAfterTryGetAddressablesData() { }

	private void OnTimeLimitReached() { }

	[CompilerGenerated]
	private static void set_Instance(TimeLimitManager value) { }

}

