namespace Game.Level;

public class LevelPeriodicSpine : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <ChangeToNextAnimationAfterIdle>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelPeriodicSpine <>4__this; //Field offset: 0x20

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
		public <ChangeToNextAnimationAfterIdle>d__11(int <>1__state) { }

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
	private bool _isRandom; //Field offset: 0x20
	[SerializeField]
	protected float _minPeriod; //Field offset: 0x24
	[SerializeField]
	protected float _maxPeriod; //Field offset: 0x28
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x30
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _idleAnimationName; //Field offset: 0x38
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _periodicAnimationsNames; //Field offset: 0x40
	private Animation _idleAnimation; //Field offset: 0x48
	private int _currentAnimationIndex; //Field offset: 0x50

	public LevelPeriodicSpine() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<ChangeToNextAnimationAfterIdle>d__11))]
	private IEnumerator ChangeToNextAnimationAfterIdle() { }

	private void OnDestroy() { }

	private void OnLevelPostInitAction() { }

	private void SetAnimation(int animationIndex) { }

}

