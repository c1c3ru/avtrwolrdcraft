namespace PWC.FTUE;

[DisallowMultipleComponent]
public class FTUEUIButton : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <TimeCheckCoroutine>d__17 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public FTUEUIButton <>4__this; //Field offset: 0x20

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
		public <TimeCheckCoroutine>d__17(int <>1__state) { }

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

	public const string BUTTON_PRESS_PLAYER_PREFS_KEY_PREFIX = "FTUEUIButtonPress_"; //Field offset: 0x0
	public const string TIMER_PLAYER_PREFS_KEY_PREFIX = "FTUEUITimer_"; //Field offset: 0x0
	[SerializeField]
	private float _ftueTime; //Field offset: 0x20
	[SerializeField]
	private bool _useWiggle; //Field offset: 0x24
	[SerializeField]
	private bool _useSpotlight; //Field offset: 0x25
	[SerializeField]
	private float _minSpotlightRadius; //Field offset: 0x28
	private float _timer; //Field offset: 0x2C
	private int _wiggleTweenID; //Field offset: 0x30
	private bool _isTimerRunning; //Field offset: 0x34
	private FTUESpotlight _currentSpotlight; //Field offset: 0x38
	private GraphicRaycaster _sceneGraphicRaycaster; //Field offset: 0x40
	[HideInInspector]
	public string ftueGuid; //Field offset: 0x48
	public Func<Boolean> TrySpecificTimerConditionAction; //Field offset: 0x50

	public float FTUETime
	{
		 get { } //Length: 8
	}

	public FTUEUIButton() { }

	[CompilerGenerated]
	private void <WiggleSetActive>b__19_0() { }

	public float get_FTUETime() { }

	private string GetIsPressedKey() { }

	private string GetTimerKey() { }

	public bool IsPressed() { }

	private void OnDestroy() { }

	private void OnTimeReached() { }

	private void OnWiggleSetActiveFalse() { }

	public void ResetTimer() { }

	public void SetFTUEGuid(string s) { }

	public void SetFTUETime(float time) { }

	public void SetMinSpotlightRadius(float radius) { }

	private void SetOnlyClickable(bool value) { }

	public void SetPressed() { }

	public void SetUseSpotlight(bool value) { }

	public void SetUseWiggle(bool value) { }

	private void Start() { }

	private void StartTimer() { }

	private void StopTimer() { }

	[IteratorStateMachine(typeof(<TimeCheckCoroutine>d__17))]
	private IEnumerator TimeCheckCoroutine() { }

	private void WiggleSetActive(bool value) { }

}

