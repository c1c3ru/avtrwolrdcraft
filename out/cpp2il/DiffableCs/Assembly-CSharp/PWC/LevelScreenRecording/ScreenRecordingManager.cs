namespace PWC.LevelScreenRecording;

public class ScreenRecordingManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<Animation> <>9__28_0; //Field offset: 0x8
		public static Func<Boolean> <>9__41_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <PreviewControllerCoroutine>b__41_0() { }

		internal bool <Start>b__28_0(Animation animation) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		public Color blackCoverColor; //Field offset: 0x10
		public ScreenRecordingManager <>4__this; //Field offset: 0x20
		public Action <>9__4; //Field offset: 0x28
		public Action <>9__6; //Field offset: 0x30
		public Action <>9__3; //Field offset: 0x38
		public Action <>9__2; //Field offset: 0x40

		public <>c__DisplayClass31_0() { }

		internal void <StartCountdown>b__0(float alphaValue) { }

		internal void <StartCountdown>b__1() { }

		internal void <StartCountdown>b__2() { }

		internal void <StartCountdown>b__3() { }

		internal void <StartCountdown>b__4() { }

		internal void <StartCountdown>b__6() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_1
	{
		public Color color; //Field offset: 0x10
		public <>c__DisplayClass31_0 CS$<>8__locals1; //Field offset: 0x20

		public <>c__DisplayClass31_1() { }

		internal void <StartCountdown>b__5(float alphaValue) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public bool value; //Field offset: 0x10
		public ScreenRecordingManager <>4__this; //Field offset: 0x18

		public <>c__DisplayClass32_0() { }

		internal void <AnimateUI>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <PreviewControllerCoroutine>d__41 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private float <timer>5__2; //Field offset: 0x20

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
		public <PreviewControllerCoroutine>d__41(int <>1__state) { }

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
	private sealed class <Timer>d__34 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ScreenRecordingManager <>4__this; //Field offset: 0x20
		private float <elapsedTime>5__2; //Field offset: 0x28

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
		public <Timer>d__34(int <>1__state) { }

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
	private sealed class <WaitForRecordingToBeAvailableForPreview>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ScreenRecordingManager <>4__this; //Field offset: 0x20
		private float <timer>5__2; //Field offset: 0x28

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
		public <WaitForRecordingToBeAvailableForPreview>d__40(int <>1__state) { }

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

	private static class ReplayKit
	{

		public static bool APIAvailable
		{
			 get { } //Length: 8
		}

		public static bool isPreviewControllerActive
		{
			 get { } //Length: 8
		}

		public static bool isRecording
		{
			 get { } //Length: 8
		}

		public static bool recordingAvailable
		{
			 get { } //Length: 8
		}

		public static bool Discard() { }

		public static bool get_APIAvailable() { }

		public static bool get_isPreviewControllerActive() { }

		public static bool get_isRecording() { }

		public static bool get_recordingAvailable() { }

		public static bool Preview() { }

		public static bool StartRecording(bool a, bool b) { }

		public static bool StopRecording() { }

	}

	[CompilerGenerated]
	private static Action OnCountdownAction; //Field offset: 0x0
	private const float BAR_FILL_INITIAL_X_ANCHORED_POSITION = -110; //Field offset: 0x0
	private const float UI_ANIMATION_TIME = 0,2; //Field offset: 0x0
	private const float MAX_RECORDING_TIME = 120; //Field offset: 0x0
	private const float BLACK_COVER_ALPHA_VALUE = 0,7; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnStartRecordingAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action OnStopRecordingAction; //Field offset: 0x10
	[CompilerGenerated]
	private static Action OnCancelRecordingAction; //Field offset: 0x18
	public static bool IsRecordingStatic; //Field offset: 0x20
	public static float ElapsedTimeStatic; //Field offset: 0x24
	[SerializeField]
	private GameObject _recordingUI; //Field offset: 0x20
	[SerializeField]
	private RectTransform _barFill; //Field offset: 0x28
	[SerializeField]
	private Text _timer; //Field offset: 0x30
	[SerializeField]
	private Image _blackCover; //Field offset: 0x38
	[SerializeField]
	private SkeletonGraphic _skeletonGraphic; //Field offset: 0x40
	private bool _toRecordAfterPhoneAnimate; //Field offset: 0x48
	private bool _didCheckRecordingState; //Field offset: 0x49
	private bool _didPauseWhileRecording; //Field offset: 0x4A
	private float _clapperAnimationDuration; //Field offset: 0x4C

	public static event Action OnCancelRecordingAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event Action OnCountdownAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public static event Action OnStartRecordingAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event Action OnStopRecordingAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public ScreenRecordingManager() { }

	[CompilerGenerated]
	private void <Timer>b__34_0(float anchoredXPosition) { }

	[CompilerGenerated]
	public static void add_OnCancelRecordingAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnCountdownAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnStartRecordingAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnStopRecordingAction(Action value) { }

	private void AnimateUI(bool value, bool isImmediate = false) { }

	private void Awake() { }

	public static bool IsAPIAvailable() { }

	private void OnApplicationClick(Application application) { }

	private void OnApplicationPause(bool pause) { }

	private void OnDestroy() { }

	private void OnPhoneEndAnimation(bool value) { }

	public void OnRecordingUIPress() { }

	private void PreformEndOfRecordingActions() { }

	[IteratorStateMachine(typeof(<PreviewControllerCoroutine>d__41))]
	private IEnumerator PreviewControllerCoroutine() { }

	[CompilerGenerated]
	public static void remove_OnCancelRecordingAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnCountdownAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnStartRecordingAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnStopRecordingAction(Action value) { }

	private void ResetParameters() { }

	private void Start() { }

	private void StartCountdown() { }

	private void StopRecording() { }

	private void StopTimer() { }

	[IteratorStateMachine(typeof(<Timer>d__34))]
	private IEnumerator Timer() { }

	private bool TryPreviewRecording() { }

	private bool TryStartRecording() { }

	private bool TryStopRecording() { }

	[IteratorStateMachine(typeof(<WaitForRecordingToBeAvailableForPreview>d__40))]
	private IEnumerator WaitForRecordingToBeAvailableForPreview() { }

}

