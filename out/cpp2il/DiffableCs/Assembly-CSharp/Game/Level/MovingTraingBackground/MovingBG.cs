namespace Game.Level.MovingTraingBackground;

public class MovingBG : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Movement>d__35 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MovingBG <>4__this; //Field offset: 0x20
		private Material <bgMaterial>5__2; //Field offset: 0x28
		private float <xOffset>5__3; //Field offset: 0x30

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
		public <Movement>d__35(int <>1__state) { }

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

	private class Sprite2DArray
	{
		public Sprite[] Array; //Field offset: 0x10

		public Sprite2DArray() { }

	}

	[SerializeField]
	private SpriteRenderer _bgSpriteRenderer; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer[] _stationSpriteRenderers; //Field offset: 0x28
	[SerializeField]
	private Sprite[] _movingSprites; //Field offset: 0x30
	[SerializeField]
	private Sprite2DArray[] _stationsSprites; //Field offset: 0x38
	[SerializeField]
	private float _mainSpeed; //Field offset: 0x40
	[SerializeField]
	private float _transitionTime; //Field offset: 0x44
	[SerializeField]
	private float _driveTime; //Field offset: 0x48
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x50
	[SerializeField]
	private string _arrivesSoundName; //Field offset: 0x58
	[SerializeField]
	private string _departureSoundName; //Field offset: 0x60
	[SerializeField]
	private bool _isBackwards; //Field offset: 0x68
	private int _tweenID; //Field offset: 0x6C
	private int _currentBgIndex; //Field offset: 0x70
	private float _moveSpeed; //Field offset: 0x74
	private bool _isMoving; //Field offset: 0x78
	[CompilerGenerated]
	private Action OnTransitionEndStartAction; //Field offset: 0x80
	[CompilerGenerated]
	private Action OnTransitionEndStopAction; //Field offset: 0x88
	[CompilerGenerated]
	private Action OnStopMovingAction; //Field offset: 0x90
	[CompilerGenerated]
	private Action OnSlowDownStartAction; //Field offset: 0x98

	public event Action OnSlowDownStartAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action OnStopMovingAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action OnTransitionEndStartAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action OnTransitionEndStopAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public MovingBG() { }

	[CompilerGenerated]
	private void <SpeedUp>b__29_0(float value) { }

	[CompilerGenerated]
	private void <StartMoving>b__28_0() { }

	[CompilerGenerated]
	private void <StopMoving>b__32_0(float value) { }

	[CompilerGenerated]
	private void <StopMoving>b__32_1() { }

	[CompilerGenerated]
	private void <TransitionMovement>b__36_0() { }

	[CompilerGenerated]
	private void <TransitionMovement>b__36_1() { }

	[CompilerGenerated]
	public void add_OnSlowDownStartAction(Action value) { }

	[CompilerGenerated]
	public void add_OnStopMovingAction(Action value) { }

	[CompilerGenerated]
	public void add_OnTransitionEndStartAction(Action value) { }

	[CompilerGenerated]
	public void add_OnTransitionEndStopAction(Action value) { }

	public void Editor_PerformDiagnosticsTest(bool isInScene) { }

	private float MoveBGSpeed() { }

	[IteratorStateMachine(typeof(<Movement>d__35))]
	private IEnumerator Movement() { }

	public bool MoveToCurrentStation(int stationIndex) { }

	[CompilerGenerated]
	public void remove_OnSlowDownStartAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnStopMovingAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnTransitionEndStartAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnTransitionEndStopAction(Action value) { }

	private void SetMovingBackground(int index) { }

	public void SetStation(int index) { }

	private void SpeedUp() { }

	private void StartMoving() { }

	public void StopInStation() { }

	private void StopMoving() { }

	private void TransitionMovement(bool isStart) { }

}

