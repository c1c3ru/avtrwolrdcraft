namespace Game.Store;

public class StoreAvatarPassStatusViewer : MonoBehaviour
{
	[CompilerGenerated]
	private struct <>c__DisplayClass11_0
	{
		public StoreAvatarPassStatusViewer <>4__this; //Field offset: 0x0
		public string localizationKey; //Field offset: 0x8

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public StoreAvatarPassStatusViewer <>4__this; //Field offset: 0x10
		public Action<StoreAvatarPassNextRewardStatusCloudResponse> onFinish; //Field offset: 0x18
		public string op; //Field offset: 0x20

		public <>c__DisplayClass9_0() { }

		internal void <Init>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <SyncAvailableInDurationTimer>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public StoreAvatarPassStatusViewer <>4__this; //Field offset: 0x20
		public string localizationKey; //Field offset: 0x28
		private <>c__DisplayClass11_0 <>8__1; //Field offset: 0x30
		private WaitForSeconds <wait>5__2; //Field offset: 0x40
		private float <timeBefore>5__3; //Field offset: 0x48

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
		public <SyncAvailableInDurationTimer>d__11(int <>1__state) { }

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
	private sealed class <WaitForData>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public StoreAvatarPassStatusViewer <>4__this; //Field offset: 0x20
		private WaitForSeconds <waitOneSecond>5__2; //Field offset: 0x28
		private string <text>5__3; //Field offset: 0x30

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
		public <WaitForData>d__10(int <>1__state) { }

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

	[SerializeField]
	private TextMeshProUGUI _timerText; //Field offset: 0x20
	[SerializeField]
	private AFCLocalizedTextMeshPro _timerTextAFCLocalizedTextMeshPro; //Field offset: 0x28
	[SerializeField]
	private TextMeshProUGUI _nextRewardText; //Field offset: 0x30
	[SerializeField]
	private GameObject _rewardDescription; //Field offset: 0x38
	[SerializeField]
	private GameObject _pendingRenewDescription; //Field offset: 0x40
	[SerializeField]
	private GameObject _weeklyStarsRewardGroup; //Field offset: 0x48
	[SerializeField]
	private GameObject _nextRewardStarsObject; //Field offset: 0x50
	private TimeSpan _availableInDuration; //Field offset: 0x58
	private Coroutine _timerCoroutine; //Field offset: 0x60

	public StoreAvatarPassStatusViewer() { }

	[CompilerGenerated]
	private void <SyncAvailableInDurationTimer>g__SyncText|11_0(ref <>c__DisplayClass11_0 unnamed_param_0) { }

	public void Init(Action<StoreAvatarPassNextRewardStatusCloudResponse> onFinish) { }

	private void OnDestroy() { }

	[IteratorStateMachine(typeof(<SyncAvailableInDurationTimer>d__11))]
	private IEnumerator SyncAvailableInDurationTimer(string localizationKey) { }

	[IteratorStateMachine(typeof(<WaitForData>d__10))]
	private IEnumerator WaitForData() { }

}

