namespace Game.Level.ContextualAnimation;

public class LevelCARampSnowboardDropAreaHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <RouteCoroutine>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelCARampSnowboardDropAreaHandler <>4__this; //Field offset: 0x20
		public LevelRamp ramp; //Field offset: 0x28

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
		public <RouteCoroutine>d__9(int <>1__state) { }

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

	private const string MOUNT_ANIMATION_NAME = "Skateboard_Cycle_Mount"; //Field offset: 0x0
	public static Action OnRouteStart; //Field offset: 0x0
	protected LevelSkateboardItemHandlerBase _skateboardHandler; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCARampSnowboardDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	protected override string GetMountAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public void Init(LevelSkateboardItemHandlerBase handler) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	[IteratorStateMachine(typeof(<RouteCoroutine>d__9))]
	private IEnumerator RouteCoroutine(LevelRamp ramp) { }

}

