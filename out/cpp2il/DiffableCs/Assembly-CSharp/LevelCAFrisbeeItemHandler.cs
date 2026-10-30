//Type is in global namespace

public class LevelCAFrisbeeItemHandler : LevelCAItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public Vector2 src; //Field offset: 0x10
		public Vector2 dst; //Field offset: 0x18
		public bool strongThrow; //Field offset: 0x20
		public bool caught; //Field offset: 0x21
		public LevelCAFrisbeeItemHandler <>4__this; //Field offset: 0x28
		public bool didOtherCatchAnimation; //Field offset: 0x30

		public <>c__DisplayClass12_0() { }

		internal void <ThrowFrisbee>b__0(float t) { }

		internal void <ThrowFrisbee>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <ThrowFrisbee>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCAFrisbeeItemHandler <>4__this; //Field offset: 0x20
		private <>c__DisplayClass12_0 <>8__1; //Field offset: 0x28

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
		public <ThrowFrisbee>d__12(int <>1__state) { }

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
	protected float _flightSpeed; //Field offset: 0x88
	[SerializeField]
	private float _strongThrowCatchAnimationOffset; //Field offset: 0x8C
	[SerializeField]
	private float _catchAnimationOffset; //Field offset: 0x90
	[SerializeField]
	private float _missAnimationOffset; //Field offset: 0x94
	protected LevelCharacter _currentCharacter; //Field offset: 0x98
	protected LevelCharacter _closestCharacter; //Field offset: 0xA0
	protected int _throwTweenID; //Field offset: 0xA8
	protected bool _isThrowing; //Field offset: 0xAC
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB0

	public LevelCAFrisbeeItemHandler() { }

	private void CatchFrisbee(bool didOtherCatchingSucceeded, bool strongThrow) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	private float GetProperAnimationOffset(bool caught, bool strongThrow) { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	[IteratorStateMachine(typeof(<ThrowFrisbee>d__12))]
	protected IEnumerator ThrowFrisbee() { }

}

